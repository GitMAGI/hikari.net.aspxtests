using hikari.net.aspxtests.DataBaseUtilities.EntityAttributes;

namespace hikari.net.aspxtests.Baseball.Data.Entities
{
    public class ManagerEntity
    {
        [PrimaryKey]
        public string managerID { get; set; }
        [PrimaryKey]
        public int? yearID { get; set; }
        [PrimaryKey]
        public string teamID { get; set; }
        [PrimaryKey]
        public string lgID { get; set; }
        public int? inseason { get; set; }
        public int? G { get; set; }
        public int? W { get; set; }
        public int? L { get; set; }
        public int? rank { get; set; }
        public string plyrMgr { get; set; }

    }
}
