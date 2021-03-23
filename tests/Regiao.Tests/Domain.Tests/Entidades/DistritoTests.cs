using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regiao.Domain.Entidades;

namespace Regiao.Tests.Domain.Tests.Entidades
{
    [TestClass]
    public class DistritoTests
    {
        [TestCategory("Validar Mome Ditrito")]
        [TestMethod("Requer que o nome do destrito não seja nulo")]
        public void NomeObrigatorio()
        {
            var distrito = new Distrito(1, "");

            Assert.AreEqual(false, distrito.IsValid);
            Assert.AreEqual(distrito.Notifications.Count, 2);
        }

        [TestCategory("Validar Municipio Ditrito")]
        [TestMethod("Requer que o seja selecionado um municipio")]
        public void MunicipioObrigatorio()
        {
            var distrito = new Distrito(0, "Viana");

            Assert.AreEqual(false, distrito.IsValid);
            Assert.AreEqual(distrito.Notifications.Count, 1);
        }
    }
}
