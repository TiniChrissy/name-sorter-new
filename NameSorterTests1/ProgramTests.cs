using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void nonTxtFileReturnsFalse()
        {
            // Arrange
            string fileName = "test.doc";
            // Act
            bool test = NameSorter.CheckIfTxtFile(fileName);
            // Assert
            Assert.IsFalse(test);
        }

        [TestMethod()]
        public void txtFileReturnsTrue()
        {
            // Arrange
            string fileName = "test.txt";
            // Act
            bool test = NameSorter.CheckIfTxtFile(fileName);
            // Assert
            Assert.IsTrue(test);
        }
    }
}