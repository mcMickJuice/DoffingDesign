namespace DoffingDesign.Service.Security
{
    public class DbAccess
    {
        public string ServerName { get; set; }
        public string DbName { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public DbEnvironment Environment { get; set; }
    }

    public enum DbEnvironment
    {
        Development = 1,
        Test = 2,
        Production = 3
    }
}