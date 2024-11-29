using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class CherishOrder
{
    public int CherishId { get; set; }

    public int GiverUserId { get; set; }

    public DateOnly EndDate { get; set; }

    public byte IngredAttributeId { get; set; }

    public short IngredientId { get; set; }

    public short Quantity { get; set; }

    public string ObtainSource { get; set; } = null!;

    public DateOnly ObtainDate { get; set; }

    public DateOnly SubmitDate { get; set; }

    public DateTime? ReserveDate { get; set; }

    public byte TradeStateCode { get; set; }

    public virtual CherishOrderCheck? CherishOrderCheck { get; set; }

    public virtual CherishOrderInfo? CherishOrderInfo { get; set; }

    public virtual ICollection<CherishTradeTime> CherishTradeTimes { get; set; } = new List<CherishTradeTime>();

    public virtual UserSecretInfo GiverUser { get; set; } = null!;

    public virtual IngredAttribute IngredAttribute { get; set; } = null!;

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual CherishTradeState TradeStateCodeNavigation { get; set; } = null!;
}
