using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace test_app1.Models
{
    public class StudentBLSQLServer : IStudentBL
    {
        private string conString = "Data Source=.;Initial Catalog=University;Integrated Security=True";

        public List<Student> show()
        {
            using (IDbConnection db = new SqlConnection(conString))
            {
                List<Student> students = new List<Student>();
                return db.Query<Student>("AllStudent").ToList();
            }
        }

        public void insert(Student stu)
        {
            using (IDbConnection db = new SqlConnection(conString))
            {
                db.Query<Student>("InsertStudent", new { Name = stu.Name, Family = stu.Family, Age = stu.Age, Address = stu.Address }, commandType: CommandType.StoredProcedure);
            }
        }
        public Student find(int id)
        {
            using (IDbConnection db = new SqlConnection(conString))
            {
                return db.Query<Student>("FindStudent", new { id = id }, commandType: CommandType.StoredProcedure).Single();
            }
        }

        public bool update(Student stu)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    var res = db.Query<Student>(
                        "EditeStudent",
                        stu,
                        commandType: CommandType.StoredProcedure
                    ).FirstOrDefault();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void delete(int id)
        {
            using (IDbConnection db = new SqlConnection(conString))
            {
                db.Query<Student>("DeleteStudent", new { id = id }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}