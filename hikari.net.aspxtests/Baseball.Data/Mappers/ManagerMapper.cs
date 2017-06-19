using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hikari.net.aspxtests.Baseball.Data.Mappers
{
    public class ManagerMapper
    {
        public static Entities.ManagerEntity DataRowToEntity(DataRow row)
        {
            Entities.ManagerEntity entity = new Entities.ManagerEntity();

            entity.managerID = row["managerID"] != DBNull.Value ? (string)row["managerID"] : null;
            entity.yearID = row["yearID"] != DBNull.Value ? (int)row["yearID"] : (int?)null;
            entity.teamID = row["teamID"] != DBNull.Value ? (string)row["teamID"] : null;
            entity.lgID = row["lgID"] != DBNull.Value ? (string)row["lgID"] : null;
            entity.inseason = row["inseason"] != DBNull.Value ? (int)row["inseason"] : (int?)null;
            entity.G = row["G"] != DBNull.Value ? (int)row["G"] : (int?)null;
            entity.W = row["W"] != DBNull.Value ? (int)row["W"] : (int?)null;
            entity.L = row["L"] != DBNull.Value ? (int)row["L"] : (int?)null;
            entity.rank = row["rank"] != DBNull.Value ? (int)row["rank"] : (int?)null;
            entity.plyrMgr = row["plyrMgr"] != DBNull.Value ? (string)row["plyrMgr"] : null;

            return entity;
        }
        public static List<Entities.ManagerEntity> DataTableToEntities(DataTable rows)
        {
            List<Entities.ManagerEntity> entities = new List<Entities.ManagerEntity>();

            if (rows != null)
            {
                if (rows.Rows.Count > 0)
                {
                    foreach (DataRow row in rows.Rows)
                    {
                        Entities.ManagerEntity tmp = DataRowToEntity(row);
                        entities.Add(tmp);
                    }
                }
            }

            return entities;
        }
    }
}
