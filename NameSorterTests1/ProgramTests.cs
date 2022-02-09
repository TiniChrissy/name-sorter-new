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

        [TestMethod()]
        public void reversesNames()
        {
            // Arrange
            string[] names = new String[] { "FirstName LastName", "John Smith"};
            List<string[]> test = new List<string[]>();

            test.Add(new String[] { "LastName", "FirstName" });
            test.Add(new String[] { "Smith", "John" });

            // Act
            List<string[]> reversed = NameSorter.ReverseNames(names);

            // Assert
            CollectionAssert.AreEquivalent(test[0], reversed[0]); // LastName FirstName 
            CollectionAssert.AreEquivalent(test[1], reversed[1]); // Smith John 
        }

    }
}