namespace GetBooksFromOpenBd
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class Book
    {
        [JsonProperty("onix")]
        public Onix Onix { get; set; }

        [JsonProperty("hanmoto")]
        public Hanmoto Hanmoto { get; set; }

        [JsonProperty("summary")]
        public Summary Summary { get; set; }
    }

    public class Summary
    {
        [JsonProperty("isbn")]
        public string Isbn { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("volume")]
        public string Volume { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("publisher")]
        public string Publisher { get; set; }

        [JsonProperty("pubdate")]
        public string Pubdate { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }

    public class Onix
    {
        [JsonProperty("RecordReference")]
        public string RecordReference { get; set; }

        [JsonProperty("NotificationType")]
        public string NotificationType { get; set; }

        [JsonProperty("ProductIdentifier")]
        public ProductIdentifier ProductIdentifier { get; set; }

        [JsonProperty("DescriptiveDetail")]
        public DescriptiveDetail DescriptiveDetail { get; set; }

        [JsonProperty("CollateralDetail")]
        public CollateralDetail CollateralDetail { get; set; }

        [JsonProperty("PublishingDetail")]
        public PublishingDetail PublishingDetail { get; set; }

        [JsonProperty("ProductSupply")]
        public ProductSupply ProductSupply { get; set; }
    }

    public class PublishingDetail
    {
        [JsonProperty("Imprint")]
        public Imprint Imprint { get; set; }

        [JsonProperty("Publisher")]
        public Publisher Publisher { get; set; }

        [JsonProperty("PublishingDate")]
        public List<PublishingDate> PublishingDate { get; set; }
    }

    public class PublishingDate
    {
        [JsonProperty("PublishingDateRole")]
        public string PublishingDateRole { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }
    }

    public class Publisher
    {
        [JsonProperty("PublishingRole")]
        public string PublishingRole { get; set; }

        [JsonProperty("PublisherIdentifier")]
        public List<PublisherIdentifier> PublisherIdentifier { get; set; }

        [JsonProperty("PublisherName")]
        public string PublisherName { get; set; }
    }

    public class PublisherIdentifier
    {
        [JsonProperty("PublisherIDType")]
        public string PublisherIdType { get; set; }

        [JsonProperty("IDValue")]
        public string IdValue { get; set; }
    }

    public class Imprint
    {
        [JsonProperty("ImprintIdentifier")]
        public List<ImprintIdentifier> ImprintIdentifier { get; set; }

        [JsonProperty("ImprintName")]
        public string ImprintName { get; set; }
    }

    public class ImprintIdentifier
    {
        [JsonProperty("ImprintIDType")]
        public string ImprintIdType { get; set; }

        [JsonProperty("IDValue")]
        public string IdValue { get; set; }
    }

    public class ProductSupply
    {
        [JsonProperty("SupplyDetail")]
        public SupplyDetail SupplyDetail { get; set; }
    }

    public class SupplyDetail
    {
        [JsonProperty("ReturnsConditions")]
        public ReturnsConditions ReturnsConditions { get; set; }

        [JsonProperty("ProductAvailability")]
        public string ProductAvailability { get; set; }

        [JsonProperty("Price")]
        public List<Price> Price { get; set; }
    }

    public class ReturnsConditions
    {
        [JsonProperty("ReturnsCodeType")]
        public string ReturnsCodeType { get; set; }

        [JsonProperty("ReturnsCode")]
        public string ReturnsCode { get; set; }
    }

    public class Price
    {
        [JsonProperty("PriceType")]
        public string PriceType { get; set; }

        [JsonProperty("PriceAmount")]
        public string PriceAmount { get; set; }

        [JsonProperty("CurrencyCode")]
        public string CurrencyCode { get; set; }
    }

    public class ProductIdentifier
    {
        [JsonProperty("ProductIDType")]
        public string ProductIdType { get; set; }

        [JsonProperty("IDValue")]
        public string IdValue { get; set; }
    }

    public class DescriptiveDetail
    {
        [JsonProperty("ProductComposition")]
        public string ProductComposition { get; set; }

        [JsonProperty("ProductForm")]
        public string ProductForm { get; set; }

        [JsonProperty("ProductFormDetail")]
        public string ProductFormDetail { get; set; }

        [JsonProperty("Collection")]
        public Collection Collection { get; set; }

        [JsonProperty("TitleDetail")]
        public TitleDetail TitleDetail { get; set; }

        [JsonProperty("Contributor")]
        public List<Contributor> Contributor { get; set; }

        [JsonProperty("Language")]
        public List<Language> Language { get; set; }

        [JsonProperty("Extent")]
        public List<Extent> Extent { get; set; }

        [JsonProperty("Subject")]
        public List<Subject> Subject { get; set; }
    }

    public class TitleDetail
    {
        [JsonProperty("TitleType")]
        public string TitleType { get; set; }

        [JsonProperty("TitleElement")]
        public TitleElement TitleElement { get; set; }
    }

    public class TitleElement
    {
        [JsonProperty("TitleElementLevel")]
        public string TitleElementLevel { get; set; }

        [JsonProperty("TitleText")]
        public TitleText TitleText { get; set; }

        [JsonProperty("Subtitle")]
        public TitleText Subtitle { get; set; }
    }

    public class Subject
    {
        [JsonProperty("SubjectSchemeIdentifier")]
        public string SubjectSchemeIdentifier { get; set; }

        [JsonProperty("SubjectCode")]
        public string SubjectCode { get; set; }
    }

    public class Language
    {
        [JsonProperty("LanguageRole")]
        public string LanguageRole { get; set; }

        [JsonProperty("LanguageCode")]
        public string LanguageCode { get; set; }

        [JsonProperty("CountryCode")]
        public string CountryCode { get; set; }
    }

    public class Extent
    {
        [JsonProperty("ExtentType")]
        public string ExtentType { get; set; }

        [JsonProperty("ExtentValue")]
        public string ExtentValue { get; set; }

        [JsonProperty("ExtentUnit")]
        public string ExtentUnit { get; set; }
    }

    public class Contributor
    {
        [JsonProperty("SequenceNumber")]
        public string SequenceNumber { get; set; }

        [JsonProperty("ContributorRole")]
        public List<string> ContributorRole { get; set; }

        [JsonProperty("PersonName")]
        public TitleText PersonName { get; set; }
    }

    public class TitleText
    {
        [JsonProperty("collationkey")]
        public string Collationkey { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Collection
    {
        [JsonProperty("CollectionType")]
        public string CollectionType { get; set; }
    }

    public class CollateralDetail
    {
        [JsonProperty("TextContent")]
        public List<TextContent> TextContent { get; set; }
    }

    public class TextContent
    {
        [JsonProperty("TextType")]
        public string TextType { get; set; }

        [JsonProperty("ContentAudience")]
        public string ContentAudience { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }
    }

    public class Hanmoto
    {
        [JsonProperty("datemodified")]
        public string Datemodified { get; set; }

        [JsonProperty("datecreated")]
        public string Datecreated { get; set; }

        [JsonProperty("datekoukai")]
        public DateTime Datekoukai { get; set; }
    }
}
