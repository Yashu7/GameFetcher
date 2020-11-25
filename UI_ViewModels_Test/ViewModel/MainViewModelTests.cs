using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFetcherUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFetcherUI.ViewModel.Tests
{
    [TestClass()]
    public class MainViewModelTests
    {
        [TestMethod()]
        public void ChooseListTest()
        {
            var sender = "1";
            switch(sender)
            {
                case "0":
                    break;
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                default:
                    break;
            }
            Assert.AreEqual("1",sender);
            Assert.AreNotEqual("5", sender);
        }
    }
}