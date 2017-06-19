using log4net.Config;
using System.Collections.Generic;

namespace hikari.net.aspxtests.Baseball.Data.Test
{
    class Program
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger("main");
        static void Main(string[] args)
        {
            //Configure log4net
            XmlConfigurator.Configure();

            log.Debug("Test Starting ...");
            
            DAL dal = new DAL();

            //List<Entities.PlayerEntity> players = dal.PlayerDAL.GetAll();
            //List<Entities.SalaryEntity> salaries = dal.SalaryDAL.GetAll();
            //List<Entities.ManagerEntity> managers = dal.ManagerDAL.GetAll();           

            //List<string> pkManager = dal.ManagerDAL.primaryKey;
            //List<string> aiManager = dal.ManagerDAL.autoincrement;
            //List<string> pkPlayer = dal.PlayerDAL.primaryKey;
            //List<string> aiPlayer = dal.PlayerDAL.autoincrement;
            //List<string> pkSalary = dal.SalaryDAL.primaryKey;
            //List<string> aiSalary = dal.SalaryDAL.autoincrement;

            Entities.SalaryEntity salary = new Entities.SalaryEntity();
            salary.lgID = "NL";
            salary.playerID = "barkele01";
            salary.teamID = "ATL";
            salary.yearID = 2017;
            salary.salary = 765;

            //Entities.SalaryEntity inserted = dal.SalaryDAL.Add(salary);

            int rem = dal.SalaryDAL.RemoveByKey(new Dictionary<string, object>()
            {
                {"lgID", "NL" },
                {"playerID", "barkele01" },
                {"teamID", "ATL" },
                {"yearID", 2017 },
            });

            log.Debug("Test Done!");
        }
    }
}
