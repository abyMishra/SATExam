using System.Globalization;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContentService.Models
{
    [BsonIgnoreExtraElements]
    public class Country
    {
        [BsonId]
        [DataMember]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int SegmentId { get; set; }
        public string CallingCode { get; set; }
        public int MobNoMinLength { get; set; }
        public int MobNoMaxLength { get; set; }
        public bool IsInboundCountry { get; set; }
        public bool HasIslandTransport { get; set; }
        public List<string> Languages { get; set; }
        public string TimeZone { get; set; }
        public bool Status { get; set; }
        public CountryImages CountryImages { get; set; }
        public ThingsToDo ThingsToDo { get; set; }
        public SeoDetail SeoDetail { get; set; }
        public BestFood BestFood { get; set; }
        public WhatToPack WhatToPack { get; set; }
        public AuditDetail AuditDetail { get; set; }
        public CultureInfo CultureInfo { get; set; }
    }


    public class CountryImages
    {
        public string ItineraryImageDescription { get; set; }
        public string ImageURL { get; set; }
        public string ImageName { get; set; }
        public bool IsHeroImage { get; set; }
        public bool DisplayItinerarySlider { get; set; }
    }

    public class ThingsToDo
    {
        public string URLSlug { get; set; }
        public string PageURL { get; set; }
        public string CanonicalURL { get; set; }
        public string ImageURL { get; set; }
        public string SubText { get; set; }
        public string Description { get; set; }
    }

    public class SeoDetail
    {
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaName { get; set; }
    }

    public class BestFood
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }

    public class WhatToPack
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class AuditDetail
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }

    public class CultureInfo
    {
        public string Country { get; set; }
        public string CultureName { get; set; }
        public string WritingSystem { get; set; }
        public string TimeZone { get; set; }
        public string Format { get; set; }
    }
}
