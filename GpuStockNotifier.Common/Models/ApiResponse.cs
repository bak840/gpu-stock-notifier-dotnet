using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GpuStockNotifier.Common
{
    public class FilterValue
    {
        [JsonPropertyName("dispValue")]
        public string DispValue { get; set; }

        [JsonPropertyName("dispValueDesription")]
        public object DispValueDesription { get; set; }

        [JsonPropertyName("groupType")]
        public object GroupType { get; set; }

        [JsonPropertyName("units")]
        public int Units { get; set; }

        [JsonPropertyName("checked")]
        public bool Checked { get; set; }

        [JsonPropertyName("imageURL")]
        public object ImageURL { get; set; }

        [JsonPropertyName("isValidate")]
        public bool IsValidate { get; set; }
    }

    public class Filter
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("filterField")]
        public string FilterField { get; set; }

        [JsonPropertyName("displayMaxValues")]
        public string DisplayMaxValues { get; set; }

        [JsonPropertyName("fieldType")]
        public string FieldType { get; set; }

        [JsonPropertyName("selectedMinRangeVal")]
        public int? SelectedMinRangeVal { get; set; }

        [JsonPropertyName("selectedMaxRangeVal")]
        public int? SelectedMaxRangeVal { get; set; }

        [JsonPropertyName("defaultMinRangeVal")]
        public int? DefaultMinRangeVal { get; set; }

        [JsonPropertyName("defaultMaxRangeVal")]
        public int? DefaultMaxRangeVal { get; set; }

        [JsonPropertyName("unitsOfMeasure")]
        public string UnitsOfMeasure { get; set; }

        [JsonPropertyName("checked")]
        public bool Checked { get; set; }

        [JsonPropertyName("units")]
        public object Units { get; set; }

        [JsonPropertyName("filterValues")]
        public List<FilterValue> FilterValues { get; set; }

        [JsonPropertyName("dataType")]
        public string DataType { get; set; }

        [JsonPropertyName("showCount")]
        public bool ShowCount { get; set; }

        [JsonPropertyName("filterDisplayOrder")]
        public int FilterDisplayOrder { get; set; }
    }

    public class Sort
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }

    public class Pagination
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("totalRecords")]
        public int TotalRecords { get; set; }

        [JsonPropertyName("featuredProductIncludedInCount")]
        public bool FeaturedProductIncludedInCount { get; set; }
    }

    public class Retailer
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productTitle")]
        public string ProductTitle { get; set; }

        [JsonPropertyName("logoUrl")]
        public string LogoUrl { get; set; }

        [JsonPropertyName("isAvailable")]
        public bool IsAvailable { get; set; }

        [JsonPropertyName("salePrice")]
        public string SalePrice { get; set; }

        [JsonPropertyName("directPurchaseLink")]
        public object DirectPurchaseLink { get; set; }

        [JsonPropertyName("purchaseLink")]
        public string PurchaseLink { get; set; }

        [JsonPropertyName("hasOffer")]
        public bool HasOffer { get; set; }

        [JsonPropertyName("offerText")]
        public object OfferText { get; set; }

        [JsonPropertyName("partnerId")]
        public string PartnerId { get; set; }

        [JsonPropertyName("storeId")]
        public string StoreId { get; set; }

        [JsonPropertyName("upc")]
        public string Upc { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("stock")]
        public int Stock { get; set; }

        [JsonPropertyName("retailerName")]
        public string RetailerName { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }
    }

    public class ProductInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class CompareProductInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class FeaturedProduct
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("productID")]
        public int ProductID { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }

        [JsonPropertyName("productTitle")]
        public string ProductTitle { get; set; }

        [JsonPropertyName("digitialRiverID")]
        public string DigitialRiverID { get; set; }

        [JsonPropertyName("productSKU")]
        public string ProductSKU { get; set; }

        [JsonPropertyName("productUPC")]
        public string ProductUPC { get; set; }

        [JsonPropertyName("productUPCOriginal")]
        public string ProductUPCOriginal { get; set; }

        [JsonPropertyName("productPrice")]
        public string ProductPrice { get; set; }

        [JsonPropertyName("productAvailable")]
        public bool ProductAvailable { get; set; }

        [JsonPropertyName("productRating")]
        public object ProductRating { get; set; }

        [JsonPropertyName("customerReviewCount")]
        public object CustomerReviewCount { get; set; }

        [JsonPropertyName("isFounderEdition")]
        public bool IsFounderEdition { get; set; }

        [JsonPropertyName("isFeaturedProduct")]
        public bool IsFeaturedProduct { get; set; }

        [JsonPropertyName("certified")]
        public bool Certified { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("isFeaturedProdcutFoundInSecondSearch")]
        public bool IsFeaturedProdcutFoundInSecondSearch { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("gpu")]
        public string Gpu { get; set; }

        [JsonPropertyName("purchaseOption")]
        public string PurchaseOption { get; set; }

        [JsonPropertyName("prdStatus")]
        public string PrdStatus { get; set; }

        [JsonPropertyName("minShipDays")]
        public object MinShipDays { get; set; }

        [JsonPropertyName("maxShipDays")]
        public object MaxShipDays { get; set; }

        [JsonPropertyName("shipInfo")]
        public object ShipInfo { get; set; }

        [JsonPropertyName("isOffer")]
        public bool IsOffer { get; set; }

        [JsonPropertyName("offerText")]
        public string OfferText { get; set; }

        [JsonPropertyName("retailers")]
        public List<Retailer> Retailers { get; set; }

        [JsonPropertyName("productInfo")]
        public List<ProductInfo> ProductInfo { get; set; }

        [JsonPropertyName("compareProductInfo")]
        public List<CompareProductInfo> CompareProductInfo { get; set; }
    }

    public class ProductDetail
    {
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("productID")]
        public int ProductID { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }

        [JsonPropertyName("productTitle")]
        public string ProductTitle { get; set; }

        [JsonPropertyName("digitialRiverID")]
        public object DigitialRiverID { get; set; }

        [JsonPropertyName("productSKU")]
        public string ProductSKU { get; set; }

        [JsonPropertyName("productUPC")]
        public string ProductUPC { get; set; }

        [JsonPropertyName("productUPCOriginal")]
        public string ProductUPCOriginal { get; set; }

        [JsonPropertyName("productPrice")]
        public string ProductPrice { get; set; }

        [JsonPropertyName("productAvailable")]
        public bool ProductAvailable { get; set; }

        [JsonPropertyName("productRating")]
        public object ProductRating { get; set; }

        [JsonPropertyName("customerReviewCount")]
        public object CustomerReviewCount { get; set; }

        [JsonPropertyName("isFounderEdition")]
        public bool IsFounderEdition { get; set; }

        [JsonPropertyName("isFeaturedProduct")]
        public bool IsFeaturedProduct { get; set; }

        [JsonPropertyName("certified")]
        public bool Certified { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("isFeaturedProdcutFoundInSecondSearch")]
        public bool IsFeaturedProdcutFoundInSecondSearch { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("gpu")]
        public string Gpu { get; set; }

        [JsonPropertyName("purchaseOption")]
        public string PurchaseOption { get; set; }

        [JsonPropertyName("prdStatus")]
        public string PrdStatus { get; set; }

        [JsonPropertyName("minShipDays")]
        public object MinShipDays { get; set; }

        [JsonPropertyName("maxShipDays")]
        public object MaxShipDays { get; set; }

        [JsonPropertyName("shipInfo")]
        public object ShipInfo { get; set; }

        [JsonPropertyName("isOffer")]
        public bool IsOffer { get; set; }

        [JsonPropertyName("offerText")]
        public string OfferText { get; set; }

        [JsonPropertyName("retailers")]
        public List<Retailer> Retailers { get; set; }

        [JsonPropertyName("productInfo")]
        public List<ProductInfo> ProductInfo { get; set; }

        [JsonPropertyName("compareProductInfo")]
        public List<CompareProductInfo> CompareProductInfo { get; set; }
    }

    public class SearchedProducts
    {
        [JsonPropertyName("totalProducts")]
        public int TotalProducts { get; set; }

        [JsonPropertyName("featuredProductIncludedInCount")]
        public bool FeaturedProductIncludedInCount { get; set; }

        [JsonPropertyName("featuredProductsFlag")]
        public bool FeaturedProductsFlag { get; set; }

        [JsonPropertyName("featuredProduct")]
        public FeaturedProduct FeaturedProduct { get; set; }

        [JsonPropertyName("productDetails")]
        public List<ProductDetail> ProductDetails { get; set; }

        [JsonPropertyName("suggestedProductDetails")]
        public List<object> SuggestedProductDetails { get; set; }
    }

    public class Disclaimer
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class ApiResponse
    {
        [JsonPropertyName("categories")]
        public object Categories { get; set; }

        [JsonPropertyName("filters")]
        public List<Filter> Filters { get; set; }

        [JsonPropertyName("filterGroups")]
        public object FilterGroups { get; set; }

        [JsonPropertyName("search")]
        public object Search { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("sort")]
        public List<Sort> Sort { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonPropertyName("searchedProducts")]
        public SearchedProducts SearchedProducts { get; set; }

        [JsonPropertyName("disclaimer")]
        public Disclaimer Disclaimer { get; set; }
    }


}
