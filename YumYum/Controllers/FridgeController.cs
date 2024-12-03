using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using System.Linq;
using YumYum.Models;
using YumYum.Models.ViewModels;

namespace YumYum.Controllers
{
    public class FridgeController : Controller
    {
        private readonly YumYumDbContext _context;

        public FridgeController(YumYumDbContext context)
        {
            _context = context;
        }

        private int? UserId { get; set; }


        public IActionResult Index()
        {
            var fridgeItemData = GetFridgeItemData();
            var ingredientData = GetIngredientData(UserId);

            var viewModel = new FridgeViewModel
            {
                RefrigeratorData = fridgeItemData,
                IngredientData = ingredientData
            };

            return View(viewModel);
        }

        public IActionResult Edit()
        {
            var fridgeItemData = GetFridgeItemData();
            var ingredientData = GetIngredientData(UserId);
            var ingredAttributeData = GetIngredAttributeData();

            var viewModel = new FridgeViewModel
            {
                RefrigeratorData = fridgeItemData,
                IngredientData = ingredientData,
                IngredAttributeData = ingredAttributeData
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UpdateRefrigeratorStore(List<FridgeItemViewModel> RefrigeratorItems, List<FridgeItemViewModel> NewRefrigeratorItems)
        {
            UserId = HttpContext.Session.GetInt32("userId");

            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(new { seccess = false, message = "錯誤資料格式。" });
            }

            if(RefrigeratorItems.Count > 0)
            {
                IQueryable<int> Newstoreid = RefrigeratorItems
                    .Where(o => o.StoreID.HasValue) // 過濾掉 null
                    .Select(o => o.StoreID!.Value)   // 取出值
                    .AsQueryable();

                IQueryable<int> ExsistStoreid = _context.RefrigeratorStores.Where(r => r.UserId == (int)UserId!).Select(r => r.StoreId);

                // 舊的比新的還多出的 => 要刪除的

                var delItems = ExsistStoreid.Except(Newstoreid).ToList();

                // 要修改ㄉ
                var UpdateItems = ExsistStoreid.Where(r => !delItems.Contains(r)).ToList();

                // Update existing items 1. 舊有食材
                foreach (var item in _context.RefrigeratorStores.Where(r => UpdateItems.Contains(r.StoreId!)))
                {
                    var UpItem = RefrigeratorItems.Where(r => r.StoreID == item.StoreId).First();
                    if (UpItem != null)
                    {
                        item.UnitId = Convert.ToInt16(UpItem.UnitName);
                        item.Quantity = UpItem.Quantity!;
                        item.ValidDate = UpItem.ValidDate;
                    }
                }

                // Delete No items 2. 刪除
                foreach (var item in _context.RefrigeratorStores.Where(r => delItems.Contains((int)r.StoreId!)))
                {
                    _context.RefrigeratorStores.Remove(item!);
                }
            }
            else
            {
                foreach (var item in _context.RefrigeratorStores.Where( r => r.UserId == (int)UserId!))
                {
                    _context.RefrigeratorStores.Remove(item!);
                }
            }
            

            // Add new items  3. a.原有食材 b.客製化食材
            foreach (var newItem in NewRefrigeratorItems)
            {
                if (newItem.NewIngredientCreate is null)
                {
                    var newRecord = new RefrigeratorStore
                    {
                        UserId = (int)UserId!,
                        IngredientId = newItem.IngredientID,
                        Quantity = newItem.Quantity!,
                        UnitId = Convert.ToInt16(newItem.UnitName),
                        ValidDate = newItem.ValidDate
                    };
                    _context.RefrigeratorStores.Add(newRecord);
                }
                else if (newItem.NewIngredientCreate.Length > 0)
                {
                    var newIg = _context.Ingredients.Add(new Ingredient
                    {
                        IngredientName = newItem.NewIngredientCreate,
                        IngredientIcon = "/img/icon/EmptyTag.svg",
                        AttributionId = 9
                    });
                    _context.RefrigeratorStores.Add(new RefrigeratorStore
                    {
                        UserId = (int)UserId!,
                        Ingredient = newIg.Entity,
                        Quantity = newItem.Quantity!,
                        UnitId = Convert.ToInt16(newItem.UnitID),
                        ValidDate = newItem.ValidDate
                    });
                }
            }
            _context.SaveChanges();
            var fridgeItemData = GetFridgeItemData();
            var ingredientData = GetIngredientData(UserId);

            var viewModel = new FridgeViewModel
            {
                RefrigeratorData = fridgeItemData,
                IngredientData = ingredientData
            };
            return View("Index", viewModel);// Redirect back to the main view after saving changes
        }




        [HttpGet]
        public IActionResult GetOtherUnits()
        {
            var otherUnits = _context.Units
                .Where(u => u.IngredAttributeId == 9)
                .OrderBy(u => u.UnitId)
                .Select(u => new
                {
                    UnitId = u.UnitId,
                    UnitName = u.UnitName
                }).ToList();

            return Json(otherUnits);
        }

        [HttpGet]
        public IActionResult GetUnitsByIngredientName(string ingredientName)
        {
            var unitsList = (
                from u in _context.Units
                join i in _context.Ingredients on u.IngredAttributeId equals i.AttributionId
                where i.IngredientName == ingredientName
                orderby i.AttributionId
                select new
                {
                    UnitId = u.UnitId,
                    UnitName = u.UnitName
                }
                ).ToList();

            return Json(unitsList);
        }

        [HttpPost]
        public JsonResult FilterIngredients([FromBody] List<int> selectedIds)
        {
            var filteredIngredients = _context.Ingredients.AsQueryable();
            if (selectedIds != null && selectedIds.Any())
            {
                filteredIngredients = filteredIngredients.Where(i => selectedIds.Contains(i.AttributionId));
            }

            var result = filteredIngredients
                .Select(i => new
                {
                    IngredientName = i.IngredientName,
                    IngredientID = i.IngredientId,
                    IngredientIcon = Url.Content($"~{i.IngredientIcon}")
                }).ToList();

            return Json(result);
        }

        public IActionResult SearchIngredients(string searchKeyword)
        {
            var allIngredients = GetIngredientData(UserId);

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                allIngredients = allIngredients
                    .Where(i => i.IngredientName!.Contains(searchKeyword, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            return PartialView("_IngredientListPartial", allIngredients);
        }

        private List<FridgeItemViewModel> GetFridgeItemData()
        {
            UserId = HttpContext.Session.GetInt32("userId");
            
            return (from fridge in _context.RefrigeratorStores
                    join unit in _context.Units on fridge.UnitId equals unit.UnitId
                    where fridge.UserId == UserId
                    orderby fridge.ValidDate
                    select new FridgeItemViewModel
                    {
                        StoreID = fridge.StoreId,
                        UserID = fridge.UserId,
                        IngredientID = fridge.IngredientId,
                        IngredientName = fridge.Ingredient.IngredientName,
                        IngredientIcon = fridge.Ingredient.IngredientIcon,
                        Quantity = fridge.Quantity,
                        UnitName = unit.UnitName,
                        ValidDate = fridge.ValidDate,
                        IngredAttributeUnit = new SelectList(_context.Units.Where(u => u.IngredAttributeId == fridge.Ingredient.AttributionId).ToList(), "UnitId", "UnitName", fridge.UnitId)

                    }).ToList();
        }

        // Get left Ingredient/tag button list, filter if needed
        private List<IngredientViewModel> GetIngredientData(int? userId = null)
        {
            var ingredientsQuery = _context.Ingredients.AsQueryable();

            if (userId.HasValue)
            {
                var existingIngredientIds = _context.RefrigeratorStores
                                             .Where(store => store.UserId == userId.Value)
                                             .Select(store => store.IngredientId);
                ingredientsQuery = ingredientsQuery.Where(igd => !existingIngredientIds.Contains(igd.IngredientId));
            }

            return ingredientsQuery.Select(igd => new IngredientViewModel
            {
                IngredientID = igd.IngredientId,
                IngredientName = igd.IngredientName,
                IngredientIcon = igd.IngredientIcon,
            }).ToList();
        }

        // Get offcanvas IngredAttributes for filtering
        private List<IngredAttributeViewModel> GetIngredAttributeData()
        {
            return (from ia in _context.IngredAttributes
                    orderby ia.IngredAttributeId
                    select new IngredAttributeViewModel
                    {
                        IngredAttributeID = ia.IngredAttributeId,
                        IngredAttributeName = ia.IngredAttributeName,
                        IngredAttributePhoto = ia.IngredAttributePhoto,
                    }
                ).ToList();
        }
    }
}
