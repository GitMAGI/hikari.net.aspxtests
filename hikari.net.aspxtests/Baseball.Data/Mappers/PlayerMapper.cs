using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace hikari.net.aspxtests.Baseball.Data.Mappers
{
    public class PlayerMapper
    {
        public static Entities.PlayerEntity DataRowToEntity(DataRow row)
        {
            Entities.PlayerEntity entity = new Entities.PlayerEntity();

            entity.lahmanID = row["lahmanID"] != DBNull.Value ? (int)row["lahmanID"] : (int?)null;
            entity.playerID = row["playerID"] != DBNull.Value ? (string)row["playerID"] : null;
            entity.managerID = row["managerID"] != DBNull.Value ? (string)row["managerID"] : null;
            entity.hofID = row["hofID"] != DBNull.Value ? (string)row["hofID"] : null;
            entity.birthYear = row["birthYear"] != DBNull.Value ? (int)row["birthYear"] : (int?)null;
            entity.birthMonth = row["birthMonth"] != DBNull.Value ? (int)row["birthMonth"] : (int?)null;
            entity.birthDay = row["birthDay"] != DBNull.Value ? (int)row["birthDay"] : (int?)null;
            entity.birthCountry = row["birthCountry"] != DBNull.Value ? (string)row["birthCountry"] : null;
            entity.birthState = row["birthState"] != DBNull.Value ? (string)row["birthState"] : null;
            entity.birthCity = row["birthCity"] != DBNull.Value ? (string)row["birthCity"] : null;
            entity.deathYear = row["deathYear"] != DBNull.Value ? (int)row["deathYear"] : (int?)null;
            entity.deathMonth = row["deathMonth"] != DBNull.Value ? (int)row["deathMonth"] : (int?)null;
            entity.deathDay = row["deathDay"] != DBNull.Value ? (int)row["deathDay"] : (int?)null;
            entity.deathCountry = row["deathCountry"] != DBNull.Value ? (string)row["deathCountry"] : null;
            entity.deathState = row["deathState"] != DBNull.Value ? (string)row["deathState"] : null;
            entity.deathCity = row["deathCity"] != DBNull.Value ? (string)row["deathCity"] : null;
            entity.nameFirst = row["nameFirst"] != DBNull.Value ? (string)row["nameFirst"] : null;
            entity.nameLast = row["nameLast"] != DBNull.Value ? (string)row["nameLast"] : null;
            entity.nameNote = row["nameNote"] != DBNull.Value ? (string)row["nameNote"] : null;
            entity.nameGiven = row["nameGiven"] != DBNull.Value ? (string)row["nameGiven"] : null;
            entity.nameNick = row["nameNick"] != DBNull.Value ? (string)row["nameNick"] : null;
            entity.weight = row["weight"] != DBNull.Value ? (int)row["weight"] : (int?)null;
            entity.height = row["height"] != DBNull.Value ? (int)row["height"] : (int?)null;
            entity.bats = row["bats"] != DBNull.Value ? (string)row["bats"] : null;
            entity.throws = row["throws"] != DBNull.Value ? (string)row["throws"] : null;
            entity.debut = row["debut"] != DBNull.Value ? (string)row["debut"] : null;
            entity.finalGame = row["finalGame"] != DBNull.Value ? (string)row["finalGame"] : null;
            entity.college = row["college"] != DBNull.Value ? (string)row["college"] : null;
            entity.lahman40ID = row["lahman40ID"] != DBNull.Value ? (string)row["lahman40ID"] : null;
            entity.lahman45ID = row["lahman45ID"] != DBNull.Value ? (string)row["lahman45ID"] : null;
            entity.retroID = row["retroID"] != DBNull.Value ? (string)row["retroID"] : null;
            entity.holtzID = row["holtzID"] != DBNull.Value ? (string)row["holtzID"] : null;
            entity.bbrefID = row["bbrefID"] != DBNull.Value ? (string)row["bbrefID"] : null;

            return entity;
        }
        public static List<Entities.PlayerEntity> DataTableToEntities(DataTable rows)
        {
            List<Entities.PlayerEntity> entities = new List<Entities.PlayerEntity>();

            if (rows != null)
            {
                if (rows.Rows.Count > 0)
                {
                    foreach (DataRow row in rows.Rows)
                    {
                        Entities.PlayerEntity tmp = DataRowToEntity(row);
                        entities.Add(tmp);
                    }
                }
            }

            return entities;
        }
    }
}
