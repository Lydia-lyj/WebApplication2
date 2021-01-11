using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SqlConnection conn = new SqlConnection(String.Format("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", Path.GetFullPath("C:/Users/vsdiagtester/source/repos/WebApplication2/WebApplication2/DatabaseSQLDb.mdf")));

            // Create a new table statement
            SqlCommand createTable = new SqlCommand("CREATE TABLE ADONetTableeer (ID int, RandomField varchar(255));", conn);

            // Insert statement
            SqlCommand insertCmd = new SqlCommand("INSERT INTO ADONetTableeer (ID, RandomField) VALUES ('1', 'SOME_DATA');", conn);

            // Select data
            SqlCommand selectCmd = new SqlCommand("SELECT * FROM ADONetTableeer", conn);

            // Drop table
            SqlCommand deleteTable = new SqlCommand("DROP TABLE ADONetTableeer", conn);
            conn.Open();
            createTable.ExecuteNonQuery();
            insertCmd.ExecuteNonQuery();

      

            SqlDataReader reader = selectCmd.ExecuteReader();
            reader.Close();
            deleteTable.ExecuteNonQuery();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
