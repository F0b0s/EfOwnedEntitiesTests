using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    [Owned]
    public class Settings
    {
        public bool StandartAccess { get; set; }
        public bool ExtendedAcces { get; set; }
        public bool Flag1 { get; set; }
        public string Name { get; set; }
    }
}
