using Synel.DAL.Entities;
using Synel.DAL.Repositories;
using Synel.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Synel.Web.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeRepository repo;

        public HomeController()
        {
            repo = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost] 
        public JsonResult UploadFile()
        {
            HttpPostedFileBase file;

            try
            {
                file = Request.Files[0];

                // Accept only .csv files
                if (Path.GetExtension(file.FileName) != ".csv")
                {
                    string msg = "Error: Wrong file type = " + Path.GetExtension(file.FileName);
                    LogHelper.Error(msg);
                    Response.StatusCode = 400;
                    return Json(msg);
                }
            }
            catch (Exception e1)
            {
                LogHelper.Error(e1.Message);
                Response.StatusCode = 400;
                return Json("Error: File is not selected: " + e1.Message);
            }

            var employees = new List<Employee>();

            using (var reader = new StreamReader(file.InputStream))
            {
                string row;

                for (int i = 0; (row = reader.ReadLine()) != null; i++)
                {
                    // Ignore the headers in .csv file
                    if (i == 0)
                        continue;

                    var columns = row.Split(',');

                    // Ignore if not enough columns
                    if (columns.Length != 11)
                        continue;

                    try
                    {
                        Employee employee = new Employee();
                        employee.PayrollNumber = columns[0];

                        Employee emp = repo.GetByPayroll(employee.PayrollNumber);

                        // Ignore if record was already inserted
                        if (emp != null)
                            continue;

                        employee.FirstName = columns[1];
                        employee.LastName = columns[2];
                        employee.DateOfBirth = DateTime.Parse(columns[3]);
                        employee.PhoneNumber = columns[4];
                        employee.MobileNumber = columns[5];
                        employee.PrimaryAddress = columns[6];
                        employee.SecondaryAddress = columns[7];
                        employee.PostCode = columns[8];
                        employee.Email = columns[9];
                        employee.StartDate = DateTime.Parse(columns[10]);                            

                        repo.Insert(employee);
                        employees.Add(employee);
                        LogHelper.Info(string.Format("Employee with Payroll Number = {0} inserted", employee.PayrollNumber));

                    }
                    catch (Exception e1)
                    {
                        // Ignore invalid row
                        continue;
                    }
                }
            }
            return Json(employees.OrderBy(x => x.LastName).ToList());            
        }

    }
}