using hikari.net.aspxtests.DataBaseUtilities;
using System.Configuration;

namespace hikari.net.aspxtests.Baseball.Data.DAO
{
    public class PlayerDAO : AbstractDAO<Entities.PlayerEntity>
    {
        public PlayerDAO(string connectionString, string tabName)
        {
            // Set Connection String
            this.DBConnectionString = connectionString;
            // Set Table Name
            this.DBTabName = tabName;
            // Set Delegates for Entity Mappings
            this.MapperDataTableToEntities = Mappers.PlayerMapper.DataTableToEntities;
            this.MapperDataRowToEntity = Mappers.PlayerMapper.DataRowToEntity;
        }
        public PlayerDAO()
        {
            // Set Connection String
            this.DBConnectionString = ConfigurationManager.ConnectionStrings["BaseballConnectionString"].ConnectionString;
            // Set Table Name
            this.DBTabName = ConfigurationManager.AppSettings["playerTabName"]; ;
            // Set Delegates for Entity Mappings
            this.MapperDataTableToEntities = Mappers.PlayerMapper.DataTableToEntities;
            this.MapperDataRowToEntity = Mappers.PlayerMapper.DataRowToEntity;
        }

        // GetByAttribute
        // GetByAttributes

        // Add
        // Update
        // Delete
    }
}
