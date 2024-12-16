using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using yum_admin.Models;
using yum_admin.Models.DataTransferObject;

namespace yum_admin.Controllers
{
    public class CherishOrdersController(YumyumdbContext context, IAntiforgery antiforgery) : Controller
    {
        private readonly YumyumdbContext _context = context;
        private readonly IAntiforgery _antiforgery = antiforgery;


        // GET: CherishOrders
        [HttpGet]
        public async Task<IActionResult> Cherish()
        {
            List<int> cherishAttr = [1,4,5,6];
            
            ViewBag.Attr = new SelectList(
                _context.IngredAttributes.Where(i => cherishAttr.Contains(i.IngredAttributeId)), 
                "IngredAttributeId", 
                "IngredAttributeName"
                );

            var cherishOrders = _context.CherishOrders
                .Where(c=>cherishAttr.Contains(c.IngredAttributeId))
                .OrderBy(c=>c.TradeStateCode)
                .ThenBy(c=>c.CherishOrderCheck!.ModifyDate)
                .Select(c=>new CherishIndexDto
                {
                    CherishId = c.CherishId,
                    TradeStateDescript = c.TradeStateCodeNavigation.TradeStateDescript,
                    TradeStateCode = c.TradeStateCodeNavigation.TradeStateCode,
                    IngredientName = c.Ingredient.IngredientName,
                    IngredAttributeName = c.IngredAttribute.IngredAttributeName,
                    ReasonText = c.CherishOrderCheck!.RejectText,
                    SubmitDate = c.SubmitDate,
                    ReserveDate = c.ReserveDate,
                    ModifyDate = c.CherishOrderCheck.ModifyDate
                });

            
            return View(await cherishOrders.ToListAsync());
        }

        // GET: CherishOrders
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Sort([FromBody] CherishSortDto s)
        {
            List<byte> orderStatus = [99,0,1,3,4];
            //Console.WriteLine(s.attrId);
            if(!orderStatus.Any(o => o == s.tradeCode))
            {
                return new BadRequestObjectResult(new { sucess = false, message = "傳入錯誤的訂單狀態" });
            }

            IQueryable<CherishOrder> query = _context.CherishOrders;
            List<int> cherishAttr = [1, 4, 5, 6];

            query = query.Where(o => cherishAttr.Contains(o.IngredAttributeId));
            if(s.tradeCode == 0)
            {
                query = query.Where(o => o.TradeStateCode == 2 || o.TradeStateCode == 0);
            }
            else
            {
                query = query.Where(o => s.tradeCode == 99 || o.TradeStateCode == s.tradeCode);
            }
            var cherishOrders = query.OrderBy(o=>o.CherishOrderCheck!.ModifyDate).Select(c => new CherishIndexDto
            {
                CherishId = c.CherishId,
                TradeStateDescript = c.TradeStateCodeNavigation.TradeStateDescript,
                TradeStateCode = c.TradeStateCodeNavigation.TradeStateCode,
                IngredientName = c.Ingredient.IngredientName,
                IngredAttributeName = c.IngredAttribute.IngredAttributeName,
                ReasonText = c.CherishOrderCheck!.RejectText,
                SubmitDate = c.SubmitDate,
                ReserveDate = c.ReserveDate,
                ModifyDate = c.CherishOrderCheck.ModifyDate
            });



            return PartialView("_PartialView_FilterOders",await cherishOrders.ToListAsync());
        }


        
        
        // GET: CherishOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cherishOrder = await _context.CherishOrders
                .Include(c => c.GiverUser)
                .Include(c => c.IngredAttribute)
                .Include(c => c.Ingredient)
                .Include(c => c.TradeStateCodeNavigation)
                .FirstOrDefaultAsync(m => m.CherishId == id);
            if (cherishOrder == null)
            {
                return NotFound();
            }

            return View(cherishOrder);
        }

        
        
        // GET: CherishOrders/Create
        public IActionResult Create()
        {
            ViewData["GiverUserId"] = new SelectList(_context.UserSecretInfos, "UserId", "UserId");
            ViewData["IngredAttributeId"] = new SelectList(_context.IngredAttributes, "IngredAttributeId", "IngredAttributeId");
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId");
            ViewData["TradeStateCode"] = new SelectList(_context.CherishTradeStates, "TradeStateCode", "TradeStateCode");
            return View();
        }

        // POST: CherishOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CherishId,GiverUserId,EndDate,IngredAttributeId,IngredientId,Quantity,ObtainSource,ObtainDate,SubmitDate,ReserveDate,TradeStateCode")] CherishOrder cherishOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cherishOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiverUserId"] = new SelectList(_context.UserSecretInfos, "UserId", "UserId", cherishOrder.GiverUserId);
            ViewData["IngredAttributeId"] = new SelectList(_context.IngredAttributes, "IngredAttributeId", "IngredAttributeId", cherishOrder.IngredAttributeId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", cherishOrder.IngredientId);
            ViewData["TradeStateCode"] = new SelectList(_context.CherishTradeStates, "TradeStateCode", "TradeStateCode", cherishOrder.TradeStateCode);
            return View(cherishOrder);
        }

        
        
        // GET: CherishOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            // 這裡是面交時間
            var timeSpan = await (from d in _context.CherishTradeTimes
                                  where d.CherishId == id
                                  select d).ToListAsync();
            
            ViewBag.Mon = timeSpan.Where(d => d.TradeTimeCode.Contains("Mon"));
            ViewBag.Tue = timeSpan.Where(d => d.TradeTimeCode.Contains("Tue"));
            ViewBag.Wes = timeSpan.Where(d => d.TradeTimeCode.Contains("Wes"));
            ViewBag.Thr = timeSpan.Where(d => d.TradeTimeCode.Contains("Thr"));
            ViewBag.Fri = timeSpan.Where(d => d.TradeTimeCode.Contains("Fri"));
            ViewBag.Sat = timeSpan.Where(d => d.TradeTimeCode.Contains("Sat"));
            ViewBag.Sun = timeSpan.Where(d => d.TradeTimeCode.Contains("Sun"));


            // 這裡是reasonText
            ViewBag.Reason = new SelectList(_context.CherishCheckReasons.Where(r => r.ReasonId != 4 && r.ReasonId != 5), "ReasonId", "ReasonText");


			var orderDetail = await (from c in _context.CherishOrders
                              where c.CherishId == id
                              select new Cherish_CheckDto
                              {
                                  CherishId = c.CherishId,
                                  IngredAttributeName = c.IngredAttribute.IngredAttributeName,
                                  IngredientName = c.Ingredient.IngredientName,
                                  Quantity = c.Quantity,
                                  EndDate = c.EndDate,
                                  ReserveDate = c.ReserveDate,
                                  ObtainSource = c.ObtainSource,
                                  ObtainDate = c.ObtainDate,
                                  CherishValidDate = c.CherishOrderCheck!.CherishValidDate,
                                  TradeStateCode = c.TradeStateCode,
                                  TradeStateDescript = c.TradeStateCodeNavigation.TradeStateDescript,
                                  ModifyDate = c.CherishOrderCheck.ModifyDate,
                                  ReasonText = c.CherishOrderCheck.Reason!.ReasonText,
                                  RejectText = c.CherishOrderCheck.RejectText,
                                  UserNickname = c.CherishOrderInfo!.UserNickname,
                                  CityName = c.CherishOrderInfo.TradeCityKeyNavigation.CityName,
                                  RegionName = c.CherishOrderInfo.TradeRegion.RegionName,
                                  ContactLine = c.CherishOrderInfo.ContactLine,
                                  ContactPhone = c.CherishOrderInfo.ContactPhone,
                                  ContactOther = c.CherishOrderInfo.ContactOther,
                                  CherishPhoto = c.CherishOrderCheck.CherishPhoto,
                                  OtherPhoto = c.CherishOrderCheck.OtherPhoto,
                                  ValidDatePhoto = c.CherishOrderCheck.ValidDatePhoto,
							  }).FirstAsync();


            return View(orderDetail);
        }

        
        
        // POST: CherishOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CherishId,GiverUserId,EndDate,IngredAttributeId,IngredientId,Quantity,ObtainSource,ObtainDate,SubmitDate,ReserveDate,TradeStateCode")] CherishOrder cherishOrder)
        {
            if (id != cherishOrder.CherishId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cherishOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CherishOrderExists(cherishOrder.CherishId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiverUserId"] = new SelectList(_context.UserSecretInfos, "UserId", "UserId", cherishOrder.GiverUserId);
            ViewData["IngredAttributeId"] = new SelectList(_context.IngredAttributes, "IngredAttributeId", "IngredAttributeId", cherishOrder.IngredAttributeId);
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "IngredientId", "IngredientId", cherishOrder.IngredientId);
            ViewData["TradeStateCode"] = new SelectList(_context.CherishTradeStates, "TradeStateCode", "TradeStateCode", cherishOrder.TradeStateCode);
            return View(cherishOrder);
        }

        
        
        // GET: CherishOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cherishOrder = await _context.CherishOrders
                .Include(c => c.GiverUser)
                .Include(c => c.IngredAttribute)
                .Include(c => c.Ingredient)
                .Include(c => c.TradeStateCodeNavigation)
                .FirstOrDefaultAsync(m => m.CherishId == id);
            if (cherishOrder == null)
            {
                return NotFound();
            }

            return View(cherishOrder);
        }

       
        
        // POST: CherishOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cherishOrder = await _context.CherishOrders.FindAsync(id);
            if (cherishOrder != null)
            {
                _context.CherishOrders.Remove(cherishOrder);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


		// POST：CherishOrders/EditStatus
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditStatus([FromBody] OrderStatus o)
        {
            Console.WriteLine($"{o.orderId}；{o.reasonId}；{o.rejectText}；{o.stateCode}");
            List<byte> accessStatus = [0, 1, 2, 3, 4, 5];
            List<byte> accessReeason = [1, 2, 3, 4, 5];
            if(o.orderId == 99)
            {
				return new BadRequestObjectResult(new { success = false, message = "請傳入訂單編號" });
			}
            if (o.stateCode == 1 || o.stateCode == 5 || o.stateCode == 0)
            {
                return new BadRequestObjectResult(new { success = false, message = "請選擇正確狀態" });
            }
            if (!accessStatus.Contains(o.stateCode))
            {
                return new BadRequestObjectResult(new { success = false, message = "錯誤的狀態值" });
            }
			if ((o.stateCode == 2) && (o.rejectText is not null || (o.reasonId is not null)))
			{
				return new BadRequestObjectResult(new { success = false, message = "傳遞包含其他訊息" });
			}
			if (o.stateCode == 3 && (o.rejectText is null || o.reasonId != 4)) 
			{
				return new BadRequestObjectResult(new { success = false, message = "請留言退回原因" });
			}

            //         order.CherishOrderCheck = _context.CherishOrderChecks.Where(ck => ck.CherishId == order.CherishId).First();


            
            switch (o.stateCode)
            {
                case (byte)2:
                    var order2 = _context.CherishOrders.Where(c => c.CherishId == o.orderId).First();
                    order2.CherishOrderCheck = _context.CherishOrderChecks.Where(ck => ck.CherishId == order2.CherishId).First();
                    //if(order2.ReserveDate <= DateTime.Now || order2.ReserveDate is null)
                    //{
                    //    order2.TradeStateCode = 0;
                    //}else if(order2.ReserveDate > DateTime.Now)
                    //{
                    //    order2.TradeStateCode = o.stateCode;
                    //}
                    order2.TradeStateCode = 0;
                    order2.CherishOrderCheck.ModifyDate = DateOnly.FromDateTime(DateTime.Now);
                    order2.CherishOrderCheck.ReasonId = null;
                    order2.CherishOrderCheck.RejectText = null;
                    await _context.SaveChangesAsync();
                    break;
                case (byte)3:
                    var order3 = _context.CherishOrders.Where(c => c.CherishId == o.orderId).First();
                    order3.CherishOrderCheck = _context.CherishOrderChecks.Where(ck => ck.CherishId == order3.CherishId).First();
                    order3.TradeStateCode = o.stateCode;
                    order3.CherishOrderCheck.ModifyDate = DateOnly.FromDateTime(DateTime.Now);
                    order3.CherishOrderCheck.ReasonId = o.reasonId;
                    order3.CherishOrderCheck.RejectText = o.rejectText;
                    await _context.SaveChangesAsync();
                    break;
                case (byte)4:
                    var order4 = _context.CherishOrders.Where(c => c.CherishId == o.orderId).First();
                    order4.CherishOrderCheck = _context.CherishOrderChecks.Where(ck => ck.CherishId == order4.CherishId).First();
                    order4.TradeStateCode = o.stateCode;
                    order4.CherishOrderCheck.ModifyDate = DateOnly.FromDateTime(DateTime.Now);
                    order4.CherishOrderCheck.ReasonId = o.reasonId;
                    order4.CherishOrderCheck.RejectText = null;
                    await _context.SaveChangesAsync();
                    break;
                default:
                    return new BadRequestObjectResult(new { seccess = false, message = "發生錯誤狀態" });
            }

			return Ok(new { redirectUrl = Url.Action("cherish"), message ="已修改訂單"});
        }

        // POST：CherishOrders/EditStatus
        [HttpPost]
        public IActionResult ValidDate(DateOnly? date,int cherishId)
        {
            if(cherishId == 0)
            {
                return new BadRequestObjectResult(new { success = false, message = "請傳入正確訂單編號！" });
            }
            if(date is null || date <= DateOnly.FromDateTime(DateTime.Now))
            {
                return new BadRequestObjectResult(new { success = false, message = "請傳入正確日期或者已臨近期限！" });
            }
            var o = _context.CherishOrders.Where(c => c.CherishId == cherishId).First();
            o.CherishOrderCheck = _context.CherishOrderChecks.Where(ck => ck.CherishId == o.CherishId).First();

            o.CherishOrderCheck.CherishValidDate = date;
            _context.SaveChanges();

            return Ok(new { message = "設置成功" });
        }





        private bool CherishOrderExists(int id)
        {
            return _context.CherishOrders.Any(e => e.CherishId == id);
        }

        [HttpGet]
        public  IActionResult GetToken()
        {
            var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
            return Ok(new { token = tokens.RequestToken });
        }

//[HttpGet]
//public async Task<IActionResult> test(int id)
//{


//    var orderSelect = await _context.CherishOrders.Where(o => o.CherishId == id).FirstAsync();


//    orderSelect.CherishOrderCheck = await _context.CherishOrderChecks.Where(o => o.CherishId == 6).FirstAsync();

//    orderSelect.CherishOrderCheck!.CherishPhoto = "/img/cherish/6.jpg";

//    await _context.SaveChangesAsync();

//    return RedirectToAction("cherish");
//}

    }
}
