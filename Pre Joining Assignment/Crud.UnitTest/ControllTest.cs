using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using crud.Controllers;
using crud.Models;
using System.Web;
namespace Crud.UnitTest
{


  
    [TestClass]
    public class ControllTest
    {
        [TestMethod]
        public void Create()
        {
            //Arrange
            HomeController controller = new HomeController();

            //act
            ViewResult result=controller.Create()  as ViewResult;

            //assert

            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void Index()
        {
            //Arrange
            LoginController controller = new LoginController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert

            Assert.IsNotNull(result);

        }

 

    }
}
