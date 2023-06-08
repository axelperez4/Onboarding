using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnboardingRrhh;
using OnboardingRrhh.Controllers;
using OnboardingRrhh.DbContext;

namespace OnboardingRrhh.Tests.Controllers
{
    [TestClass]
    public class SkillsControllerTest
    {
        [TestMethod]
        public void VerificarSkillMethodFalso()
        {
            //Se espera falla al comprobar una entidad inválida

            // Arrange
            SkillsController controller = new SkillsController();
            ORTSkill skillAPrueba = new ORTSkill();
            skillAPrueba.UsuarioCreacion = 0;

            // Act
            bool resultado = controller.ValidarSkill(skillAPrueba);

            // Assert
            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void VerificarSkillMethodVerdadero()
        {
            //Se espera verdadero al comprobar una entidad válida

            // Arrange
            SkillsController controller = new SkillsController();
            ORTSkill skillAPrueba = new ORTSkill();
            skillAPrueba.UsuarioCreacion = 1000;
            skillAPrueba.IdRamaSkill = 1;

            // Act
            bool resultado = controller.ValidarSkill(skillAPrueba);

            // Assert
            Assert.IsTrue(resultado);
        }

    }
}
