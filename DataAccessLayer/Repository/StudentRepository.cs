using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace DataAccessLayer.Repository
{
  public   class StudentRepository
    {
        private readonly string connectionstring;
        public StudentRepository()
        {
            connectionstring = @"Data source=DESKTOP-DDKSO40\SQLEXPRESS;Initial catalog=ReceiptEntry;User ID=sa;Password=Anaiyaan@123;";
        }

        public List<StudentModel> GetStudentDetail()
        {
            try
            {
                List<StudentModel> res = new List<StudentModel>();
                var connection = new SqlConnection(connectionstring);
                connection.Open();
                res = connection.Query<StudentModel>($"exec dbo.GetStudentDetails").ToList();
                return res;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StudentModel selectid(int id)
        {
            try
            {


                var connection = new SqlConnection(connectionstring);
                connection.Open();
                var result = connection.QueryFirst<StudentModel>($"exec dbo.GetStudentDetailsbyid {id}");
                connection.Close();

                return result;


            }
            catch (SqlException ep)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void InsertDetails(StudentModel emp)
        {
            try
            {

                SqlConnection con = new SqlConnection(connectionstring);

                con.Open();
                con.Execute($"exec dbo.InsertStudentDetails '{emp.Name}','{emp.Department}','{emp.FeesHeader}'");
                con.Close();

            }
            catch (SqlException Ex)
            {
                throw Ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void updatesp(StudentModel emp)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                connection.Execute($"exec updateStudentDetails  '{emp.Id}',' {emp.Name}','{emp.Department}','{emp.FeesHeader}'");



                connection.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void deletesp(int id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                connection.Execute($"exec  deletesp  {id}");
                connection.Close();

            }
            catch (SqlException e)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

