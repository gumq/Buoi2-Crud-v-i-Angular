using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TranLeQuyen_5951071088_THbuoi2.Models;

namespace TranLeQuyen_5951071088_THbuoi2.Controllers
{
    public class StudentController : ApiController
    {
        private SqlConnection _conn;
        private SqlDataAdapter _adapter;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-9R3VIFH\SQLEXPRESS;
            Initial Catalog=Nawab;Persist Security Info=True;User ID=sa;Password=123456");

            DataTable dt = new DataTable();
            var query = "select * from Student";
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)

            };
            _adapter.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecocord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecocord));
                }
            }
            return students;
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-9R3VIFH\SQLEXPRESS;
            Initial Catalog=Nawab;Persist Security Info=True;User ID=sa;Password=123456");

            DataTable dt = new DataTable();
            var query = "select * from Student where id=" + id;
            _adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)

            };
            _adapter.Fill(dt);
            List<Student> students = new List<Models.Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow studentRecocord in dt.Rows)
                {
                    students.Add(new ReadStudent(studentRecocord));
                }
            }
            return students;

        }

        // POST api/<controller>
        public string Post([FromBody] CreateStudent value)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-9R3VIFH\SQLEXPRESS;
            Initial Catalog=Nawab;Persist Security Info=True;User ID=sa;Password=123456");

            var query = "insert into student (f_name,m_name,l_name,address,birthDate,score) value (@f_name,@m_name,@l_name,@address,@birthDate,@score)";
            SqlCommand insertCommand = new SqlCommand(query, _conn);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "Them thanh cong";
            }
            else
            {
                return "Them that bai";
            }
        }

        // PUT api/<controller>/5
        public String Put(int id, [FromBody] CreateStudent value)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-9R3VIFH\SQLEXPRESS;
            Initial Catalog=Nawab;Persist Security Info=True;User ID=sa;Password=123456");

            var query = "update student set f_name=@f_name,m_name=@m_name,l_name=l_name,address=@address,birthDate=@birthDate,score=@score where id=" + id;
            SqlCommand insertCommand = new SqlCommand(query, _conn);
            insertCommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertCommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertCommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertCommand.Parameters.AddWithValue("@address", value.address);
            insertCommand.Parameters.AddWithValue("@birthDate", value.birthDate);
            insertCommand.Parameters.AddWithValue("@score", value.score);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "update thanh cong";
            }
            else
            {
                return "update that bai";
            }
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            _conn = new SqlConnection(@"Data Source=DESKTOP-9R3VIFH\SQLEXPRESS;
            Initial Catalog=Nawab;Persist Security Info=True;User ID=sa;Password=123456");

            var query = "delete from student where id=" + id;
            SqlCommand insertCommand = new SqlCommand(query, _conn);

            _conn.Open();
            int result = insertCommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "xoa thanh cong";
            }
            else
            {
                return "xoa that bai";
            }
        }
    }
}