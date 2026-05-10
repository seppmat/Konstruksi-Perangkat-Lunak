using tpModul12;

namespace tpModul12_Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestNegatif()
        {
            Helper helper = new Helper();

            Assert.AreEqual("Negatif",
                helper.CariTandaBilangan(-1));
        }

        [TestMethod]
        public void TestPositif()
        {
            Helper helper = new Helper();

            Assert.AreEqual("Positif",
                helper.CariTandaBilangan(5));
        }

        [TestMethod]
        public void TestNol()
        {
            Helper helper = new Helper();

            Assert.AreEqual("Nol",
                helper.CariTandaBilangan(0));
        }
    }
}
