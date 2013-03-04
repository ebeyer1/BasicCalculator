using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCalculator.Test
{
   [TestClass]
   public class CalculatorAppTest
   {
      [TestInitialize]
      public void Initialize()
      {
      }

      [TestMethod]
      public void CalculatorApp_MultipleOperations_ReturnsCorrectResult()
      {
         // 5 * 2 + 6 = 16
         var calculatorForm = new CalculatorApp();
         calculatorForm.btnFive.PerformClick();
         calculatorForm.btnMultiply.PerformClick();
         calculatorForm.btnTwo.PerformClick();
         calculatorForm.btnAdd.PerformClick();

         Assert.AreEqual( "10", calculatorForm.displayBox.Text );

         calculatorForm.btnSix.PerformClick();
         calculatorForm.btnCalculate.PerformClick();

         Assert.AreEqual( "16", calculatorForm.displayBox.Text );
      }
   }
}
