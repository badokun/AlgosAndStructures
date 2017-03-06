using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Lists;
using NUnit.Framework;

namespace AlgorithmTests.Lists
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void CanEnumerate()
        {
            // Arrange
            var list = CreateList();

            // Act
            var items = list.ToList();

            // Assert
            Assert.AreEqual(3, items.Count);
        }

        [Test]
        public void RemoveFirst()
        {
            // Arrange
            var list = CreateList();

            // Act
            list.RemoveFirst();
            var items = list.ToList();

            // Assert
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual(15, items[0]);
            Assert.AreEqual(20, items[1]);
        }

        [Test]
        public void RemoveLast()
        {
            // Arrange
            var list = CreateList();

            // Act
            list.RemoveLast();
            var items = list.ToList();

            // Assert
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual(10, items[0]);
            Assert.AreEqual(15, items[1]);
        }

        private static MyLinkedList<int> CreateList()
        {
            var list = new MyLinkedList<int>();
            list.Add(10);
            list.Add(15);
            list.Add(20);
            return list;
        }
    }
}
