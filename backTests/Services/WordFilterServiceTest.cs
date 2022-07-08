using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using back.Services.Interfaces;
using back.Services;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace backTests.Services
{
    [TestClass()]
    public class WordFilterServiceTest
    {
        private IWordFilterService _service;

        [TestInitialize]
        public void Init()
        {
            _service = new WordFilterService();
        }

        [TestMethod()]
        public void ContainsBadWork_Test_OK()
        {
            Assert.IsTrue(_service.ContainsBadWord("@brut!"));
            Assert.IsFalse(_service.ContainsBadWord("tête"));

            Assert.IsTrue(_service.ContainsBadWord("c'est une chaine qui doit être débile ! ou @brut!"));
            Assert.IsFalse(_service.ContainsBadWord("ceci est une phrase tout ce qui est normal sans soucis !"));
        }

        [TestMethod()]
        public void ReplaceWord_Test_ShouldReplace()
        {
            string textWithReplacement = "c'est une chaine débile! @brut!";

            if (_service.ContainsBadWord(textWithReplacement))
            {
                Assert.AreEqual("c'est une chaine d****e! @****!", _service.ReplaceWord(textWithReplacement));
            }

            if(!_service.ContainsBadWord("no replacement !"))
            {
                Assert.AreEqual("no replacement !", _service.ReplaceWord("no replacement !"));
            }
        }

        [TestMethod()]
        public void TestAndReplace_Test()
        {
            string textWithReplacement = "c'est une chaine débile! @brut!";

            Assert.AreEqual("c'est une chaine d****e! @****!", _service.TestAndReplace(textWithReplacement));
            Assert.AreEqual("no replacement !", _service.TestAndReplace("no replacement !"));
        }
    }
}
