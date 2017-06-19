using hikari.net.aspxtests.DataBaseUtilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace hikari.net.aspxtests.Baseball.Data.DAO
{
    public class AbstractDAO<T>
    {
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger("main");
        protected string DBConnectionString = null;
        protected string DBTabName = null;

        protected Func<DataTable, List<T>> MapperDataTableToEntities;
        protected Func<DataRow, T> MapperDataRowToEntity;

        public List<string> primaryKey { get; }
        public List<string> autoincrement { get; }

        public AbstractDAO()
        {
            Type type = typeof(T);
            List<string> pks = type.GetProperties().Where(prop => prop.IsDefined(typeof(DataBaseUtilities.EntityAttributes.PrimaryKey), false)).Select(p => p.Name).ToList();
            primaryKey = pks.Count() == 0 ? null : pks;
            List<string> ais = type.GetProperties().Where(prop => prop.IsDefined(typeof(DataBaseUtilities.EntityAttributes.Autoincrement), false)).Select(p => p.Name).ToList();
            autoincrement = ais.Count() == 0 ? null : ais;
        }

        // GetAll
        public List<T> GetAll()
        {
            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Retrieving procedure ..."));

            List<T> entities = null;
            try
            {
                string connectionString = this.DBConnectionString;

                string table = this.DBTabName;

                DataTable data = DBSQL.SelectOperation(connectionString, table, null);
                log.Info(string.Format("DBSQL Query Executed! Retrieved {0} record!", LibString.ItemsNumber(data)));
                if (data != null)
                {
                    entities = MapperDataTableToEntities.Invoke(data);
                    log.Info(string.Format("{0} Records mapped to {1}", LibString.ItemsNumber(entities), LibString.TypeName(entities)));
                }
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return entities;
        }

        // GetByAttribute
        // GetByAttributes

        // Add
        public T Add(T item)
        {
            T written = default(T);

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Adding procedure ..."));

            if (item == null)
                throw new ArgumentNullException("Unable to add NULL entities!");

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;
                if (primaryKey == null)
                {
                    throw new Exception(string.Format("No Primary Key has been defined for the entity '{0}'. Use an adding procedure without an Inserted Item returning!", typeof(T).Name));
                }
                // INSERT NUOVA
                DataTable res = DBSQL.InsertBackOperation(connectionString, table, item, primaryKey, autoincrement);
                if (res != null)
                    if (res.Rows.Count > 0)
                    {
                        log.Info(string.Format("Added a New record!"));
                        written = MapperDataRowToEntity.Invoke(res.Rows[0]);
                        log.Info(string.Format("New record has been Mapped!"));
                    }
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return written;
        }
        public List<T> Add(List<T> items)
        {
            List<T> writtens = null;

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Adding procedure ..."));

            if (items == null || items.Count == 0)
                throw new ArgumentNullException("Unable to add NULL entities!");

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;
                if (primaryKey == null)
                {
                    throw new Exception(string.Format("No Primary Key has been defined for the entity '{0}'. Use an adding procedure without an Inserted Item returning!", typeof(T).Name));
                }
                // INSERT NUOVE
                DataTable res = DBSQL.MultiInsertBackOperation(connectionString, table, items, primaryKey, autoincrement);
                if (res != null && res.Rows.Count > 0)
                {
                    log.Info(string.Format("Added {0} New records!", res.Rows.Count));
                    writtens = (List<T>)MapperDataTableToEntities.Invoke(res);
                    log.Info(string.Format("{0} New records have been Mapped!", res.Rows.Count));
                }
                else
                {
                    log.Info(string.Format("No records Inserted!"));
                }
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return writtens;
        }

        // Update
        public T Update(T item)
        {
            T written = default(T);

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Updating procedure ..."));

            if (item == null)
                throw new ArgumentNullException("Unable to update NULL entity!");

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;
                if (primaryKey == null)
                {
                    throw new Exception(string.Format("No Primary Key has been defined for the entity '{0}'. Use an updating procedure with declared conditions!", typeof(T).Name));
                }
                int i = 0;
                bool hasNext = true;
                Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                foreach (string k in primaryKey)
                {
                    object v = item.GetType().GetProperty(k).GetValue(item, null);

                    if (i == primaryKey.Count - 1)
                        hasNext = false;
                    string condName = "cond" + i;
                    DBSQL.QueryCondition condValue = new DBSQL.QueryCondition()
                    {
                        Key = k,
                        Value = v,
                        Op = DBSQL.Op.Equal,
                        Conj = hasNext ? DBSQL.Conj.And : DBSQL.Conj.None,
                    };
                    conditions.Add(condName, condValue);
                    i++;
                }
                int result = DBSQL.UpdateOperation(connectionString, table, item, conditions, this.autoincrement);
                log.Info(string.Format("Updated {0} records!", result));

                //Retrieve Item By Condition to give it back as result!
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return written;
        }
        public List<T> Update(List<T> items)
        {
            List<T> writtens = null;

            return writtens;
        }

        // Delete by Attributes
        public int RemoveByKey(Dictionary<string, object> key)
        {
            int result = 0;

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Deleting procedure ..."));

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;
                
                // DELETE
                if(key != null)
                {
                    int i = 0;
                    bool hasNext = true;
                    Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                    foreach (KeyValuePair<string, object> kvPair in key)
                    {
                        if (i == key.Count - 1)
                            hasNext = false;
                        string condName = "cond" + i;
                        DBSQL.QueryCondition condValue = new DBSQL.QueryCondition()
                        {
                            Key = kvPair.Key,
                            Value = kvPair.Value,
                            Op = DBSQL.Op.Equal,
                            Conj = hasNext ? DBSQL.Conj.And : DBSQL.Conj.None,
                        };
                        conditions.Add(condName, condValue);
                        i++;
                    }
                    result = DBSQL.DeleteOperation(connectionString, table, conditions);
                }               
                
                log.Info(string.Format("Deleted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return result;
        }
        // Delete by Attributes
        public int RemoveByKeys(List<Dictionary<string, object>> keys)
        {
            int result = 0;

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Deleting procedure ..."));

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;

                // DELETE
                if (keys != null)
                {
                    int i = 0;
                    Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                    foreach (Dictionary<string, object> key in keys)
                    {
                        foreach (KeyValuePair<string, object> kvPair in key)
                        {
                            int j = 0;
                            bool hasNext = true;
                            if(i == keys.Count - 1)
                            {
                                if (j == key.Count - 1)
                                    hasNext = false;
                            }
                            
                            string condName = "cond" + i;
                            DBSQL.QueryCondition condValue = new DBSQL.QueryCondition()
                            {
                                Key = kvPair.Key,
                                Value = kvPair.Value,
                                Op = DBSQL.Op.Equal,
                                Conj = hasNext ? DBSQL.Conj.And : DBSQL.Conj.None,
                            };
                            conditions.Add(condName, condValue);
                            i++;
                            j++;
                        }
                    }                    
                    result = DBSQL.DeleteOperation(connectionString, table, conditions);
                }

                log.Info(string.Format("Deleted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return result;
        }
        // Delete by Entity
        public int Remove(T item)
        {
            int result = 0;

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Deleting procedure ..."));

            if (item == null)
                throw new ArgumentNullException("Unable to delete NULL entity!");

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;
                if (primaryKey == null)
                {
                    throw new Exception(string.Format("No Primary Key has been defined for the entity '{0}'. Use a removing procedure based on conditions!", typeof(T).Name));
                }
                Dictionary<string, object> key = new Dictionary<string, object>();
                foreach(string k in this.primaryKey)
                {
                    object v = item.GetType().GetProperty(k).GetValue(item, null);
                    key.Add(k, v);
                }
                // DELETE
                if (key != null)
                {
                    int i = 0;
                    bool hasNext = true;
                    Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                    foreach (KeyValuePair<string, object> kvPair in key)
                    {
                        if (i == key.Count - 1)
                            hasNext = false;
                        string condName = "cond" + i;
                        DBSQL.QueryCondition condValue = new DBSQL.QueryCondition()
                        {
                            Key = kvPair.Key,
                            Value = kvPair.Value,
                            Op = DBSQL.Op.Equal,
                            Conj = hasNext ? DBSQL.Conj.And : DBSQL.Conj.None,
                        };
                        conditions.Add(condName, condValue);
                        i++;
                    }
                    result = DBSQL.DeleteOperation(connectionString, table, conditions);
                }

                log.Info(string.Format("Deleted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return result;
        }
        // Delete by Entities
        public int Remove(List<T> items)
        {
            int result = 0;

            Stopwatch tw = new Stopwatch();
            tw.Start();

            log.Info(string.Format("Starting Deleting procedure ..."));

            if(items==null || items.Count == 0)
                throw new ArgumentNullException("Unable to delete NULL entities!");

            string table = this.DBTabName;

            try
            {
                string connectionString = this.DBConnectionString;
                if (primaryKey == null)
                {
                    throw new Exception(string.Format("No Primary Key has been defined for the entity '{0}'. Use a removing procedure based on conditions!", typeof(T).Name));
                }

                List<Dictionary<string, object>> keys = new List<Dictionary<string, object>>();
                foreach(T item in items){
                    Dictionary<string, object> key = new Dictionary<string, object>();
                    foreach (string k in this.primaryKey)
                    {
                        object v = item.GetType().GetProperty(k).GetValue(item, null);
                        key.Add(k, v);
                    }
                    keys.Add(key);
                }

                // DELETE
                if (keys != null)
                {
                    int i = 0;
                    Dictionary<string, DBSQL.QueryCondition> conditions = new Dictionary<string, DBSQL.QueryCondition>();
                    foreach (Dictionary<string, object> key in keys)
                    {
                        foreach (KeyValuePair<string, object> kvPair in key)
                        {
                            int j = 0;
                            bool hasNext = true;
                            if (i == keys.Count - 1)
                            {
                                if (j == key.Count - 1)
                                    hasNext = false;
                            }

                            string condName = "cond" + i;
                            DBSQL.QueryCondition condValue = new DBSQL.QueryCondition()
                            {
                                Key = kvPair.Key,
                                Value = kvPair.Value,
                                Op = DBSQL.Op.Equal,
                                Conj = hasNext ? DBSQL.Conj.And : DBSQL.Conj.None,
                            };
                            conditions.Add(condName, condValue);
                            i++;
                            j++;
                        }
                    }
                    result = DBSQL.DeleteOperation(connectionString, table, conditions);
                }

                log.Info(string.Format("Deleted {0} records!", result));
            }
            catch (Exception ex)
            {
                string msg = "An Error occured! Exception detected!";
                log.Info(msg);
                throw ex;
            }
            finally
            {
                tw.Stop();
                log.Info(string.Format("Completed! Elapsed time {0}", LibString.TimeSpanToTimeHmsms(tw.Elapsed)));
            }

            return result;
        }

    }
}
