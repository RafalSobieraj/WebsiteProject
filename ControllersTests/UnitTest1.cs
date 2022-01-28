using Castle.Core.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebsiteProject.Controllers;
using WebsiteProject.Data;
using WebsiteProject.Models;
using Microsoft.Extensions.Configuration;


namespace ControllersTests
{
    [TestClass]
    public class UnitTest1
    {
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get; }


        [TestMethod]
        public void LoginViewTest()
        {
            LoginController _unitTesting = new LoginController(null, null);

            var result = _unitTesting.Login() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CameraViewTest()
        {
            string connectionString = Configuration.GetConnectionString("Default");

            var options = new DbContextOptionsBuilder<MyDbContext>().UseMySQL(connectionString).Options;

            var context = new MyDbContext(options);

            CamerasController cameras = new CamerasController(context);

            var list = context.Cameras.ToList();

            var result = cameras.Index() as ViewResult;

            Assert.AreEqual("~/Views/Cameras/CameraView.cshtml", list);
        }
    }
}
