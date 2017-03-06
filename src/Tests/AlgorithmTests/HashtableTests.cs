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
            var hashTable = new Hashtable<string, Fruit>();
            hashTable.Add("Orange", new Fruit("Orange"));
            hashTable.Add("Apple", new Fruit("Apple"));
            hashTable.Add("Grapes", new Fruit("Grapes"));
            hashTable.Add("Pine Apples", new Fruit("Pine Apples"));
            hashTable.Add("Mangos", new Fruit("Mangos"));
            hashTable.Add("Papaya", new Fruit("Papaya"));

            var removed = hashTable.Remove("Mangos");
            removed = hashTable.Remove("Papaya");
        }

        class Fruit
        {
            public string FruitName { get; set; }

            public Fruit(string fruitName)
            {
                FruitName = fruitName;
            }

            public override string ToString()
            {
                return "Name: " + FruitName;
            }
        }
    }
}
