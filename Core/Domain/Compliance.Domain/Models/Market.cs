using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Compliance.Domain.Models
{
    /// <summary>
    /// Market
    /// </summary>
    public partial class Market
    {
        public int Id { get; set; }
        public string MarketName { get; set; } = string.Empty;

        public string MarketDescription { get; set; } = string.Empty;
        public string MarketCurrency { get; set; }
        public string CurrencySymbol { get; set; }
        public int? Primarywarehouse { get; set; }
        public int? Secondarywarehouse { get; set; }
        public short? TimeZone { get; set; }
        public string DefaultCultureInfo { get; set; }
        public string Shippingcurrency { get; set; }
        public string MerchantCurrency { get; set; }
        public int? CountryId { get; set; }
        public string Companycode { get; set; }
        public short? Isnfr { get; set; }
        public short? Settaxintegration { get; set; }
        public short? MaxamountNfr { get; set; }
        public decimal? MaxamountlimitNfr { get; set; }
        public short? MaxvolumeNfr { get; set; }
        public decimal? MaxvolumelimitNfr { get; set; }
        public short? MaxcurrencyNfr { get; set; }
        public decimal? MaxcurrencylimitNfr { get; set; }
        public string Nfrcompanycode { get; set; }
        public string Nfrcurrency { get; set; }
        public short? StageNfr { get; set; }
        public short? Setcompanydetail { get; set; }
        public string Companyphone { get; set; }
        public int? Companyaddressid { get; set; }
        public string Companyemail { get; set; }
        public byte? MinAge { get; set; }
        public int? OrderSubscriptionType { get; set; }
        public int? AutoshipSubscriptionType { get; set; }
        public short Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? ShowFlagStatus { get; set; }
        public string TranslationKey { get; set; }

        //public virtual ICollection<ComplianceSourceTypeMarkets> ComplianceSourceTypeMarkets { get; set; }
    }
}
