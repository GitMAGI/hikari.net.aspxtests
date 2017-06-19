using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace hikari.net.aspxtests.DataBaseUtilities
{
    public static class LibString
    {
        static public string TimeSpanToTimeHmsms(TimeSpan ts)
        {
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                ts.Hours,
                ts.Minutes,
                ts.Seconds,
                ts.Milliseconds);

            return elapsedTime;
        }
        static public bool IsNumericType(this object o)
        {
            bool result = false;
            var type = Type.GetTypeCode(o.GetType());
            switch (type)
            {
                case TypeCode.DateTime:
                    result = false;
                    break;
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    result = true;
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }
        static public string SQLCommand2String(SqlCommand cmd)
        {
            string result = "";
            if (cmd.CommandType == System.Data.CommandType.StoredProcedure)
            {
                result = SQLCommandSP2String(cmd);
            }
            else
            {
                result = SQLCommandQuery2String(cmd);
            }
            return result;
        }
        static private string SQLCommandQuery2String(SqlCommand cmd)
        {
            string result = "";

            result = cmd.CommandText;
            foreach (SqlParameter p in cmd.Parameters)
            {
                string val_ = "NULL";
                if (p.Value != DBNull.Value && p.Value != null)
                    val_ = p.Value.IsNumericType() ? p.Value.ToString() : string.Format("'{0}'", p.Value.ToString());
                string par_ = "@" + p.ParameterName;

                result = ReplaceFirstOccurrance(result, par_, val_);
            }
            return result;
        }
        static private string SQLCommandSP2String(SqlCommand cmd)
        {
            string result = "";

            result = "exec " + cmd.CommandText + " ";
            int _l = 1;
            foreach (SqlParameter p in cmd.Parameters)
            {
                string pv = "NULL";
                if (p.Value != DBNull.Value && p.Value != null)
                    pv = p.Value.IsNumericType() ? p.ParameterName + " = " + p.Value.ToString() : p.ParameterName + " = '" + p.Value.ToString() + "'";
                result += pv;
                if (_l < cmd.Parameters.Count)
                    result += ", ";
                _l++;
            }
            return result;
        }
        static public string ReplaceFirstOccurrance(string original, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(original))
                return string.Empty;
            if (string.IsNullOrEmpty(oldValue))
                return original;
            if (string.IsNullOrEmpty(newValue))
                newValue = string.Empty;
            int loc = original.IndexOf(oldValue);
            if (loc == -1)
                return original;
            return original.Remove(loc, oldValue.Length).Insert(loc, newValue);
        }
        static public string XML2String(XmlDocument xmlDoc)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                xmlDoc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
        static public List<string> GetAllValuesSegments(string data, string value)
        {
            List<string> res = null;

            List<int> indexesStart = new List<int>();
            List<int> indexesEnd = new List<int>();
            for (int indexStart = 0; ; indexStart += value.Length)
            {
                indexStart = data.IndexOf(value, indexStart);
                if (indexStart == -1)
                    break;
                indexesStart.Add(indexStart);

                int indexEnd = data.IndexOf("\r\n", indexStart);
                if (indexEnd == -1)
                {
                    indexEnd = data.IndexOf('\n', indexStart);
                    if (indexEnd == -1)
                        indexEnd = data.Length;
                }
                indexesEnd.Add(indexEnd);
            }

            for (int i = 0; i < indexesStart.Count; i++)
            {
                string tmp = data.Substring(indexesStart[i], indexesEnd[i] - indexesStart[i]);
                if (res == null)
                    res = new List<string>();
                res.Add(tmp);
            }

            return res;
        }
        static public string TypeName<T>(T obj)
        {
            if (typeof(T).IsArray)
            {
                return typeof(T).Name;
            }
            if(typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                string containerTypeName = typeof(T).Name.Replace("`2", "");
                Type keyType = typeof(T).GetGenericArguments()[0];
                Type valueType = typeof(T).GetGenericArguments()[1];
                string itemTypeName1 = keyType.Name;
                string itemTypeName2 = valueType.Name;               

                return string.Format("{0}<{1}, {2}>", containerTypeName, itemTypeName1, itemTypeName2);
            }
            if (typeof(T).GetInterface("IEnumerable") != null)
            {
                // Is a List
                string containerTypeName = typeof(T).Name.Replace("`1", "");
                Type itemType = typeof(T).GetGenericArguments().Single();
                string itemTypeName = itemType.Name;

                return string.Format("{0}<{1}>", containerTypeName, itemTypeName);
            }
            else
            {
                return typeof(T).Name;
            }  
        }       
        static public int ItemsNumber<T>(T obj)
        {
            int res = 0;

            if (obj != null)
            {
                if (typeof(T).GetInterface("IEnumerable") != null)
                {
                    int c = 0;
                    System.Collections.IEnumerator e = ((System.Collections.IEnumerable)obj).GetEnumerator();
                    while (e.MoveNext())
                        c++;
                    res = c;
                }
                else
                {
                    res = 1;
                }
                if (typeof(T) == typeof(System.Data.DataTable))
                {
                    System.Data.DataTable dt = obj as System.Data.DataTable;
                    res = dt.Rows.Count;
                }
            }

            return res;
        }
    }
}
