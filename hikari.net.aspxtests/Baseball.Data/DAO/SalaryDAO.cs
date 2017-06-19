using System.Collections.Generic;
using System.Configuration;

namespace hikari.net.aspxtests.Baseball.Data.DAO
{
    public class SalaryDAO : AbstractDAO<Entities.SalaryEntity>
    {
        public SalaryDAO(string connectionString, string tabName)
        {
            // Set Connection String
            this.DBConnectionString = connectionString;
            // Set Table Name
            this.DBTabName = tabName;
            // Set Delegates for Entity Mappings
            this.MapperDataTableToEntities = Mappers.SalaryMapper.DataTableToEntities;
            this.MapperDataRowToEntity = Mappers.SalaryMapper.DataRowToEntity;
        }
        public SalaryDAO()
        {
            // Set Connection String
            this.DBConnectionString = ConfigurationManager.ConnectionStrings["BaseballConnectionString"].ConnectionString;
            // Set Table Name
            this.DBTabName = ConfigurationManager.AppSettings["salaryTabName"]; ;
            // Set Delegates for Entity Mappings
            this.MapperDataTableToEntities = Mappers.SalaryMapper.DataTableToEntities;
            this.MapperDataRowToEntity = Mappers.SalaryMapper.DataRowToEntity;
        }

        // GetByAttribute
        // GetByAttributes

        // Add
        // Update
        // Delete
    }
}
