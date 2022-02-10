using MvcNetFramework.Models.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcNetFramework.Databases
{
    public class DbContext
    {
        private string _dbConnectString;
        public DbContext()
        {
            _dbConnectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        public DbContext(string dbConnectionString)
        {
            _dbConnectString = dbConnectionString;
        }
        public IEnumerable<DemoPerson> GetDemoPersonList()
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                try
                {
                    var res = new List<DemoPerson>();
                    using (SqlCommand cmd = new SqlCommand("uspGetDemoPersonList", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            res.Add(new DemoPerson
                            {
                                Id = Guid.Parse(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                Remark = reader["Remark"].ToString(),
                                Created = DateTime.Parse(reader["Created"].ToString()),
                                Updated = DateTime.Parse(reader["Updated"].ToString())
                            });
                        }
                    }

                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            return null;
        }
        public DemoPerson AddDemoPerson(Guid id, string name, string remark, DateTime created, DateTime updated)
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspAddDemoPerson", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;
                        cmd.Parameters.Add("@Created", SqlDbType.DateTime).Value = created;
                        cmd.Parameters.Add("@Updated", SqlDbType.DateTime).Value = updated;

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return new DemoPerson { Id = id, Name = name, Remark = remark, Created = created, Updated = updated };
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            return null;
        }

        public DemoPerson GetDemoPersonById(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                try
                {
                    var res = new DemoPerson();
                    using (SqlCommand cmd = new SqlCommand("uspGetDemoPersonById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            res.Id = Guid.Parse(reader["Id"].ToString());
                            res.Name = reader["Name"].ToString();
                            res.Remark = reader["Remark"].ToString();
                            res.Created = DateTime.Parse(reader["Created"].ToString());
                            res.Updated = DateTime.Parse(reader["Updated"].ToString());
                        }
                    }

                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            return null;
        }

        public DemoPerson UpdateDemoPerson(Guid id, string name, string remark, DateTime updated)
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                try
                {
                    var res = new DemoPerson();
                    using (SqlCommand cmd = new SqlCommand("uspUpdateDemoPerson", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@Remark", SqlDbType.VarChar).Value = remark;
                        cmd.Parameters.Add("@Updated", SqlDbType.DateTime).Value = updated;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            res.Id = Guid.Parse(reader["Id"].ToString());
                            res.Name = reader["Name"].ToString();
                            res.Remark = reader["Remark"].ToString();
                            res.Created = DateTime.Parse(reader["Created"].ToString());
                            res.Updated = DateTime.Parse(reader["Updated"].ToString());
                        }
                    }

                    return res;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            return null;
        }
        public bool DeleteDemoPerson(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_dbConnectString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("uspDeleteDemoPerson", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }

            return false;
        }
    }
}
