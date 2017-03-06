using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using NUnit.Framework;

namespace AlgorithmTests
{
    [TestFixture]
    public class HashtableTests
    {
        [Test]
        public void CanAdd()
        {
            var hashTable = new Hashtable<string>();
            hashTable.Add("Orange");
            hashTable.Add("Apple");
            hashTable.Add("Grapes");
            hashTable.Add("Pine Apples");
            hashTable.Add("Mangos");
            hashTable.Add("Papaya");
        }
    }
}
