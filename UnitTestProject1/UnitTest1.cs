using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HongYangDataBase;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DBContext.SetConn();
        }
    }
}
