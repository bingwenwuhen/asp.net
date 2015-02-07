using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using miniLib.Model;
using miniLib.DAL;

namespace miniLib.DAL
{
    public class LibraryDAL
    {
        public int Update(Library model) {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("update Library set ");
            sbStr.Append("LCurator=@LCurator,");
            sbStr.Append("LPhone=@LPhone,");
            sbStr.Append("LAddress=@LAddress,");
            sbStr.Append("LEmail=@LEmail,");
            sbStr.Append("LSite=@LSite,");
            sbStr.Append("LCreateTime=@LCreateTime,");
            sbStr.Append("LIntroduce=@LIntroduce ");
            sbStr.Append(" where LName=@LName;");
            SqlParameter[] paras = { 
                                        new SqlParameter("LName",model.LName),
                                        new SqlParameter("LCurator",model.LCurator),
                                        new SqlParameter("LPhone",model.LPhone),
                                        new SqlParameter("LAddress",model.LAddress),
                                        new SqlParameter("LEmail",model.LEmail),
                                        new SqlParameter("LSite",model.LSite),
                                        new SqlParameter("LCreatetime",model.LCreateTime),
                                        new SqlParameter("LIntroduce",model.LIntroduce)
                                   };
            return SqlHelper.ExcuteNonQuery(sbStr.ToString(),paras);
        }

        public Library Get() {
            string sql = "select * from Library;";
            using (SqlDataReader reader = SqlHelper.ExcuteDataReader(sql)) {
                if (reader.Read())
                {
                    return ToModel(reader);
                }
                else {
                    return null;
                }
            }
        }

        public Library ToModel(SqlDataReader reader) {
            Library model = new Library();
            model.LName = (string)ToModelValue(reader,"LName");
            model.LCurator = (string)ToModelValue(reader,"LCurator");
            model.LPhone = (string)ToModelValue(reader,"LPhone");
            model.LAddress = (string)ToModelValue(reader,"LAddress");
            model.LEmail = (string)ToModelValue(reader,"LEmail");
            model.LSite = (string)ToModelValue(reader,"LSite");
            model.LCreateTime = Convert.ToDateTime(ToModelValue(reader,"LCreateTime"));
            model.LIntroduce = (string)ToModelValue(reader,"LIntroduce");
            return model;
        }

        public object ToModelValue(SqlDataReader reader, string columnName) {
            if (reader.IsDBNull(reader.GetOrdinal(columnName)))
            {
                return null;
            }
            else { 
            return reader[columnName];
            }
        }
    }
}