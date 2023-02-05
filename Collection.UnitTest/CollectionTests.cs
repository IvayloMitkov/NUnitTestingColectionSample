using Collections;

namespace Collection.UnitTest
{
    public class CollectionTests
    {


        [Test]
        public void TestCollectionEmptyConstructor()
        {
            var coll = new Collection<int>();

            Assert.AreEqual(coll.ToString(), "[]");
        }

        [Test]
        public void TestCollectionConstructorSingleItem()
        {
            var coll = new Collection<int>(9);

            Assert.AreEqual(coll.ToString(), "[9]");
        }

        [Test]
        public void TestCollectionConstructorMultipleItems() 
        {
            var coll = new Collection<int>(5, 9, 7);

            Assert.AreEqual(coll.ToString(), "[5, 9, 7]");
        }

        [Test]
        public void TestCollectionAdd()
        {
            var coll = new Collection<string>("Gosho", "Pesho");

            coll.Add("Ivan");

            Assert.AreEqual(coll.ToString(), "[Gosho, Pesho, Ivan]");
        }

        [Test]
        public void TestCollectionGetByIndex()
        {
            var coll = new Collection<int>(9, 12, 45, 89, 78, 98, 125);
            var item = coll[5];

            Assert.That(item.ToString(), Is.EqualTo("98"));
        }

        [Test]

        public void TestcollectionSetByIndex()
        {
            var coll = new Collection<int>(78, 58, 62, 23);
            coll[2] = 128;

            Assert.That(coll.ToString(), Is.EqualTo("[78, 58, 128, 23]"));
        }

        [Test]

        public void TestCollectionAddRange()

        {
            var coll = new Collection<int>();
            var coll1 = new Collection<int>();
            coll.Add(1);
            coll.Add(2);
            coll.Add(5);
            coll.Add(6);
            coll1.AddRange(coll.Capacity);

            Assert.That(coll.ToString(), Is.EqualTo("[1, 2, 5, 6]"));
        }

        [Test]

        public void TestCollectionClear()
        {
            var coll = new Collection<int> (9, 8, 7, 6);
            coll.Clear();

            Assert.That(coll.ToString(), Is.EqualTo("[]"));
        }

        [Test]

        public void TestCollectionExchangeFirstLast()
        {
            var coll = new Collection<int>(122, 22, 36, 25, 2);

            var first = 0;
            var last = coll.Count - 1;

            coll.Exchange(first, last);

            Assert.AreEqual(coll.ToString(), "[2, 22, 36, 25, 122]");
        }

        [Test]

        public void TestCollectionExchangeMiddle()
        {
            var coll = new Collection<int>(122, 22, 36, 25, 2, 1);

            coll.Exchange((coll.Count / 2 -1), (coll.Count /2));

            Assert.AreEqual(coll.ToString(), "[122, 22, 25, 36, 2, 1]");
        }

        [Test]

        public void TestGetByInvalidIndex()
        {
            var coll = new Collection<int>(55, 56);

            Assert.That(() => { var item = coll[2]; },Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        [Test]

        public void TestCollectionInsertAtStart()
        {
            var coll = new Collection<int>(1000, 1001, 1002);

            coll.InsertAt(0, 999);

            Assert.That(coll.ToString(), Is.EqualTo("[999, 1000, 1001, 1002]"));
        }

        [Test]

        public void TestCollectionInsertAtEnd()
        {
            var coll = new Collection<String>("I started");

            coll.InsertAt(coll.Count, "Automation testing course");

            Assert.That(coll.ToString(), Is.EqualTo("[I started, Automation testing course]"));
        }

        [Test]

        public void TestCollectionInsertAtWithGrow()
        {
            var coll = new Collection<int>();
            int oldCapacity = coll.Capacity;
            var newcoll = Enumerable.Range(1, 2).ToArray();

            for (int i = 0; i < newcoll.Length; i++) 
            {
                coll.InsertAt(i, newcoll[i]);   
            }

            string expect = "[" + string.Join(", ", newcoll) + "]";

            Assert.That(coll.ToString(), Is.EqualTo(expect));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(coll.Capacity, Is.GreaterThanOrEqualTo(coll.Count));
        }

        [Test]

        public void TestCollectionCountAndCapacity()   
        {
            var coll = new Collection<int>(3, 4);

            var checkCapacity = Math.Max(2 * coll.Count, 16);

            Assert.That(coll.Capacity, Is.EqualTo(checkCapacity));
        }

    }
}
