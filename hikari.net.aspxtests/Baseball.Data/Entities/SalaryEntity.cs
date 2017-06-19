using hikari.net.aspxtests.DataBaseUtilities.EntityAttributes;

namespace hikari.net.aspxtests.Baseball.Data.Entities
{
    public class SalaryEntity
    {
        [PrimaryKey]
        public int? yearID { get; set; }
        [PrimaryKey]
        public string teamID { get; set; }
        [PrimaryKey]
        public string lgID { get; set; }
        [PrimaryKey]
        public string playerID { get; set; }
        public int? salary { get; set; }
    }
}
