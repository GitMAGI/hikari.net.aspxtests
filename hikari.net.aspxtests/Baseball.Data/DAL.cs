using hikari.net.aspxtests.Baseball.Data.DAO;
using System.Configuration;

namespace hikari.net.aspxtests.Baseball.Data
{
    public class DAL
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger("main");

        protected readonly static string BaseballConnectionString = ConfigurationManager.ConnectionStrings["BaseballConnectionString"].ConnectionString;

        protected readonly static string playerTabName = ConfigurationManager.AppSettings["playerTabName"];
        protected readonly static string managerTabName = ConfigurationManager.AppSettings["managerTabName"];
        protected readonly static string salaryTabName = ConfigurationManager.AppSettings["salaryTabName"];
        protected readonly static string schoolTabName = ConfigurationManager.AppSettings["schoolTabName"];

        public PlayerDAO PlayerDAL { get; }
        public SalaryDAO SalaryDAL { get; }
        public ManagerDAO ManagerDAL { get; }

        public DAL()
        {
            this.PlayerDAL = new PlayerDAO(BaseballConnectionString, playerTabName);
            this.SalaryDAL = new SalaryDAO(BaseballConnectionString, salaryTabName);
            this.ManagerDAL = new ManagerDAO(BaseballConnectionString, managerTabName);
        }

    }
}
