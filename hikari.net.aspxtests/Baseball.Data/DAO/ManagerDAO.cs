using hikari.net.aspxtests.DataBaseUtilities;
using System.Configuration;

namespace hikari.net.aspxtests.Baseball.Data.DAO
{
    public class ManagerDAO : AbstractDAO<Entities.ManagerEntity>
    {
        public ManagerDAO(string connectionString, string tabName)
        {
            this.DBConnectionString = connectionString;
            this.DBTabName = tabName;
            this.MapperDataTableToEntities = Mappers.ManagerMapper.DataTableToEntities;
            this.MapperDataRowToEntity = Mappers.ManagerMapper.DataRowToEntity;
        }
        public ManagerDAO()
        {
            // Set Connection String
            this.DBConnectionString = ConfigurationManager.ConnectionStrings["BaseballConnectionString"].ConnectionString;
            // Set Table Name
            this.DBTabName = ConfigurationManager.AppSettings["managerTabName"]; ;
            // Set Delegates for Entity Mappings
            this.MapperDataTableToEntities = Mappers.ManagerMapper.DataTableToEntities;
            this.MapperDataRowToEntity = Mappers.ManagerMapper.DataRowToEntity;
        }
        
        // GetByAttribute
        // GetByAttributes

        // Add
        // Update
        // Delete
    }
}
