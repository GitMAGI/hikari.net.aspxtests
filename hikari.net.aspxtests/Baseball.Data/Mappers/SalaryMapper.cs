using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hikari.net.aspxtests.Baseball.Data.Mappers
{
    public class SalaryMapper
    {
        public static Entities.SalaryEntity DataRowToEntity(DataRow row)
        {
            Entities.SalaryEntity entity = new Entities.SalaryEntity();

            entity.yearID = row["yearID"] != DBNull.Value ? (int)row["yearID"] : (int?)null;
            entity.teamID = row["teamID"] != DBNull.Value ? (string)row["teamID"] : null;
            entity.lgID = row["lgID"] != DBNull.Value ? (string)row["lgID"] : null;
            entity.playerID = row["playerID"] != DBNull.Value ? (string)row["playerID"] : null;
            entity.salary = row["salary"] != DBNull.Value ? (int)row["salary"] : (int?)null;

            return entity;
        }
        public static List<Entities.SalaryEntity> DataTableToEntities(DataTable rows)
        {
            List<Entities.SalaryEntity> entities = new List<Entities.SalaryEntity>();

            if (rows != null)
            {
                if (rows.Rows.Count > 0)
                {
                    foreach (DataRow row in rows.Rows)
                    {
                        Entities.SalaryEntity tmp = DataRowToEntity(row);
                        entities.Add(tmp);
                    }
                }
            }

            return entities;
        }
    }
}
