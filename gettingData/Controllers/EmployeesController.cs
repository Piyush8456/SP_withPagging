using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using gettingData.Services;
using gettingData.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace gettingData.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly _empServices _db;

        public EmployeesController()
        {
            _db = new _empServices(); 
        }
 
        public ActionResult Index()
        {
            var employees = _db.Database.SqlQuery<employeeEntity>("EXEC getData_SP").ToList();

           

            return View(employees);
        }

        [HttpPost]
        public JsonResult AjaxMethod(int pageIndex, string searchTerm)
        {
            employeeEntityModel model = new employeeEntityModel();
            model.PageIndex = pageIndex;
            model.PageSize = 10;

            List<employeeEntity> employees = new List<employeeEntity>();
            string constring = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("GetCustomersPageWise", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", model.PageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", model.PageSize);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        employees.Add(new employeeEntity
                        {
                            employeeId = (int)sdr["employeeId"],
                            firstName = sdr["firstName"].ToString(),
                            lastName = sdr["lastName"].ToString(),
                            mobileNumber = sdr["mobileNumber"].ToString()
                        });
                    }
                    con.Close();

                    model.employees  = employees;
                }
            }

            return Json(model);
        }
    }

}
