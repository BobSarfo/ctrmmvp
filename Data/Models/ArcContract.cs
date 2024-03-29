﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ctrmmvp.Data.Models
{
    public class ArcContract
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CompanyID { get; set; }
        public int BranchID { get; set; }
        public string ContractNbr { get; set; }
        public DateTime? ContractDate { get; set; }
        public string ContractType { get; set; }
        public string PurchaseSale { get; set; }
        public int? CommodityType { get; set; }
        public int? ProfitCentre { get; set; }
        public string ProductCode { get; set; }
        public string Origin { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? DifferentialRatioValue { get; set; }
        public int? Crop { get; set; }
        public int? Season { get; set; }
        public string ClientReference { get; set; }
        public string ClientReference2 { get; set; }
        public string Insurance { get; set; }
        public decimal? Franchise { get; set; }
        public decimal? Tolerance { get; set; }
        public int? FormType { get; set; }
        public int NoOfSplits { get; set; }
        public int? Packaging { get; set; }
        public string Notes { get; set; }
        public int? LineCntr { get; set; }
        public int? CommodityTypeID { get; set; }
        public int? ProductTypeID { get; set; }
        public int? QualityID { get; set; }
        public int? PackagingID { get; set; }
        public int? StockItemID { get; set; }
        public int? ProductCategoryID { get; set; }
        public string UOM { get; set; }
        public string CuryID { get; set; }
        public int? PriceTermID { get; set; }
        public string TermsID { get; set; }
        public int? CounterpartyID { get; set; }
        public string CounterpartyRef1 { get; set; }
        public string CounterpartyRef2 { get; set; }
        public int? IncoTermID { get; set; }
        public int? LocationID { get; set; }
        public int? ShipFromID { get; set; }
        public int? AccoutID { get; set; }
        public int? SubID { get; set; }
        public int? DocTypeID { get; set; }
        public string DiffCuryID { get; set; }
        public string ContractCurrency { get; set; }
        public int? Clause1 { get; set; }
        public int? Clause2 { get; set; }
        public int? Clause3 { get; set; }
        public int? Clause4 { get; set; }
        public string ArbitrationLocation { get; set; }
        public string CompanyS { get; set; }
        public string Freight { get; set; }
        public int? SpecialClause { get; set; }
        public int? PackagingSizeID { get; set; }
        public string SustCertNum { get; set; }
        public string PackagingBrand { get; set; }
        public int? NumOfSubcontracts { get; set; }
        public decimal? OutrightPrice { get; set; }
        public int? MarketID { get; set; }
        public DateTime? ValuationMonth { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public int? PackagingBrandID { get; set; }
        public bool? SampleRequired { get; set; }
        public bool? ContractReceived { get; set; }
        public bool? ContractConfirmed { get; set; }
        public Guid? NoteID { get; set; }
        public string DiffCuryIDLabel { get; set; }
        public string DifferentialRatioValueLabel { get; set; }
        public int? WeightTerms { get; set; }
        public string PeriodStartDateS { get; set; }
        public string PeriodEndDateS { get; set; }
        public string ValuationMonthS { get; set; }
        public string CommodityCD { get; set; }
        public bool? Sel12 { get; set; }
        public byte[] tstamp { get; set; }
        public Guid? CreatedByID { get; set; }
        public string CreatedByScreenID { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public Guid? LastModifiedByID { get; set; }
        public string LastModifiedByScreenID { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool? MultiProduct { get; set; }
        public decimal? Lotsfield { get; set; }
        public string Status { get; set; }
        public DateTime? FixByDate { get; set; }
        public DateTime? FixAfterDate { get; set; }
        public string FixOption { get; set; }
        public string PricingType { get; set; }
        public decimal? Ratio { get; set; }
        public DateTime? UsrFixByDate { get; set; }
        public string UsrFixOption { get; set; }
        public DateTime? UsrFixAfterDate { get; set; }
        public string LCType { get; set; }
        public string LCNbr { get; set; }
        public DateTime? LCDeadline { get; set; }
        public string LCRemarks { get; set; }
        public int? BOLCntr { get; set; }
        public int? CTRMZoneID { get; set; }
        public string ShipTermsID { get; set; }
        public int? ItemClassID { get; set; }
        public string QualityTerms { get; set; }
        public string ContractContents { get; set; }
        public decimal? ContractContentsQty { get; set; }
        public bool? Hedge { get; set; }
        public decimal? HedgedQty { get; set; }
        public decimal? HedgedLots { get; set; }
        public string MarketCuryID { get; set; }
        public string MarketUOM { get; set; }
        public decimal? CuryRate { get; set; }
        public decimal? OutrightPriceCC { get; set; }
        public DateTime? BankDate { get; set; }
        public decimal? TrInterestChargesFL { get; set; }
        public decimal? TrInterestCharges { get; set; }
        public decimal? ImplBillCharges { get; set; }
        public decimal? PerfomanceGuaranteeCharges { get; set; }
        public decimal? OpeningAndAmendmCharges { get; set; }
        public decimal? BankCharges { get; set; }
        public decimal? ExtOtherDirect { get; set; }
        public decimal? ExtNegotiationCharges { get; set; }
        public decimal? ExtConfirmationCharges { get; set; }
        public decimal? BDInterestCharges { get; set; }
        public decimal? ShippedQtySalePurchase { get; set; }
        public string RelatedIBContractNbr { get; set; }
        public bool? InterCompanyBRRequired { get; set; }
        public int? ProjectID { get; set; }
        public string Bank { get; set; }
        public decimal? SwitchCost { get; set; }
        public int? LocationIDOP { get; set; }
        public string ShipmentContents { get; set; }
        public decimal? ShipmentContentsQty { get; set; }
        public bool? Transhipment { get; set; }
        public bool? PartialShipment { get; set; }
        public bool? Discounts { get; set; }
        public bool? Inspections { get; set; }
        public int? LineCntrForDocs { get; set; }
        public string DiscountsText { get; set; }
        public string InspectionsText { get; set; }
        public string FreeDays { get; set; }
        public int? CommodityID { get; set; }
        public int? WorkgroupID { get; set; }
        public bool? Hold { get; set; }
        public bool? Released { get; set; }
        public bool? Approved { get; set; }
        public string TradeConfirmationNbr { get; set; }
        public string FacilityType { get; set; }
        public string FacilityNbr { get; set; }
        public int? RepaymentNbr { get; set; }
        public string FinFacFutCuryCommContr { get; set; }
        public bool? PricingCCY { get; set; }
        public string BankName { get; set; }
        public int? BankBaccountID { get; set; }
        public int? OwnerID { get; set; }
        public bool? OutrightPriceEnabled { get; set; }
        public string UsrContractNbrNiche { get; set; }
        public string CropSeason { get; set; }
        public bool? UsrHideNumOfLotsOnPr { get; set; }
        public bool? UsrApproved { get; set; }
        public bool? UsrRejected { get; set; }
        public Guid? Trader { get; set; }
        public decimal? UsrContainerCapacity { get; set; }
        public DateTime? UsrPeriodStartDate { get; set; }
        public DateTime? UsrPeriodEndDate { get; set; }
    }
}