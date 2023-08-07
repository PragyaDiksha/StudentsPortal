using StudentsPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace StudentsPortal.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult StudentsForm()
        {
            return View("~/Views/Students/Students.cshtml");
        }

        [HttpPost]
        public ActionResult SaveStudents(Students students)
        {
            string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=MVC;Integrated Security=true;";

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand("SaveStudents", connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter para = new SqlParameter();
            para.ParameterName = "@Name";
            para.Value = students.Name;

            SqlParameter para1 = new SqlParameter();
            para1.ParameterName = "@Address";
            para1.Value = students.Address; 

            command.Parameters.Add(para);

            command.Parameters.Add(para1);

            connection.Open();

            int rowsAffected = 0;
            rowsAffected = command.ExecuteNonQuery();

            connection.Close();

            if (rowsAffected > 0)
            {
                Students obj = new Students();
                return View("~/Views/Students/Students.cshtml", obj);
            }
            return View("~/Views/Error.cshtml");
        }

        public ActionResult GetAllStudents()
        {
            return View("~/Views/Students/GetStudentsData.cshtml");
        }

    }
    
}