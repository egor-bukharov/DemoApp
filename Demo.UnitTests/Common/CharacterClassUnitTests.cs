using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo.UnitTests.Common
{
    [TestClass]
    public class CharacterClassUnitTests
    {
        [TestMethod]
        public void SingleCharacter()
        {
            var cc = new SingleCharacter('a');
            Assert.AreEqual(1, cc.CharCount);
            Assert.AreEqual('a', cc[0]);
        }

        [TestMethod]
        public void CharactersRange()
        {
            var cc = new CharactersRange('a', 'b');
            Assert.AreEqual(2, cc.CharCount);
            Assert.AreEqual('a', cc[0]);
            Assert.AreEqual('b', cc[1]);
        }

        [TestMethod]
        public void CombinationOfSingleCharacters()
        {
            var cc = new SingleCharacter('a').Join('b');
            Assert.AreEqual(2, cc.CharCount);
            Assert.AreEqual('a', cc[0]);
            Assert.AreEqual('b', cc[1]);
        }

        [TestMethod]
        public void CombinationOfSingleCharactersAndCharactersRange()
        {
            var cc = new SingleCharacter('a').Join('b').Join('c', 'e');
            Assert.AreEqual(5, cc.CharCount);
            Assert.AreEqual('a', cc[0]);
            Assert.AreEqual('b', cc[1]);
            Assert.AreEqual('c', cc[2]);
            Assert.AreEqual('d', cc[3]);
            Assert.AreEqual('e', cc[4]);
        }

        [TestMethod]
        public void CombinationOfCharactersRanges()
        {
            var cc = new CharactersRange('a', 'c').Join('d', 'g');
            Assert.AreEqual(7, cc.CharCount);
            Assert.AreEqual('a', cc[0]);
            Assert.AreEqual('b', cc[1]);
            Assert.AreEqual('c', cc[2]);
            Assert.AreEqual('d', cc[3]);
            Assert.AreEqual('e', cc[4]);
            Assert.AreEqual('f', cc[5]);
            Assert.AreEqual('g', cc[6]);
        }
    }
}
