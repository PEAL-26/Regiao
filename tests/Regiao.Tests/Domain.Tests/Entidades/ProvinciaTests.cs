﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regiao.Domain.Entidades;

namespace Regiao.Tests.Domain.Tests.Entidades
{
    [TestClass]
    public class ProvinciaTests
    {
        [TestCategory("Validar Mome Ditrito")]
        [TestMethod("Requer que o nome do destrito não seja nulo")]
        public void NomeObrigatorio()
        {
            var obj = new Provincia(1, "");

            Assert.AreEqual(false, obj.IsValid);
            Assert.AreEqual(obj.Notifications.Count, 2);

            
        }
    }
}
