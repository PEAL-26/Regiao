using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regiao.Domain.Entidades;

namespace Regiao.Tests.Domain.Tests.Entidades
{
    [TestClass]
    public class PaisTests
    {
        [TestCategory("Validar Nome")]
        [TestMethod("")]
        public void Nome_Com_Espaco_Em_Branco_Invalido()
        {
            var obj = new Pais("AO", " ");

            Assert.AreEqual(false, obj.IsValid);
            Assert.AreEqual(1, obj.Notifications.Count);
            
        }

        [TestCategory("Validar Nome")]
        [TestMethod("")]
        public void Nome_Em_Branco_Invalido()
        {
            var obj = new Pais("AO", "");

            Assert.AreEqual(false, obj.IsValid);
            Assert.AreEqual(2, obj.Notifications.Count);
        }

        [TestCategory("Validar Nome")]
        [TestMethod("")]
        public void Nome_Com_Caracteres_Elevados_Invalido()
        {
            string nome = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012";
            var obj = new Pais("AO", nome);

            Assert.AreEqual(false, obj.IsValid);
            //Assert.AreEqual(1, obj.Notifications.Count);
        }    
        
        [TestCategory("Validar Nome")]
        [TestMethod("")]
        public void Nome_Valido()
        {
            var obj = new Pais("AO", "Angola");

            Assert.AreEqual(true, obj.IsValid);
        }
    }
}
