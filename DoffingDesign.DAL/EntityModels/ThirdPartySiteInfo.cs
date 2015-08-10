namespace DoffingDesign.DAL.EntityModels
{
    public class ThirdPartySiteInfo
    {
        public int Id { get; set; }
        public string SiteId  { get; set; }
        public ThirdPartySiteType ThirdPartySiteType { get; set; }
    }

    public enum ThirdPartySiteType
    {
        Society6 = 1,
        Amazon = 2
    }
}