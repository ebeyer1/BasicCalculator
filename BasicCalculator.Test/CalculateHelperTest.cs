using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCalculator.Test
{
   [TestClass]
   public class CalculateHelperTest
   {
      [TestMethod]
      public void Calculate_AddingTwoValidWholeNumbers_ReturnsCorrectSum()
      {
         var calculateHelper = new CalculateHelper
         {
            Operation = Operation.Add,
            Operand1 = 2,
            Operand2 = 3
         };
         Assert.AreEqual( 5, calculateHelper.Calculate() );
      }

      [TestMethod]
      public void Calculate_SubtractingTwoValidWholeNumbers_ReturnsCorrectDifference()
      {
         var calculateHelper = new CalculateHelper
         {
            Operation = Operation.Subtract,
            Operand1 = 4,
            Operand2 = 6
         };
         Assert.AreEqual( -2, calculateHelper.Calculate() );
      }

      [TestMethod]
      public void Calculate_MultiplyingTwoValidWholeNumbers_ReturnsCorrectProduct()
      {
         var calculateHelper = new CalculateHelper
         {
            Operation = Operation.Multiply,
            Operand1 = -4,
            Operand2 = 2
         };
         Assert.AreEqual( -8, calculateHelper.Calculate() );
      }

      [TestMethod]
      public void Calculate_DividingTwoValidWholeNumbers_ReturnsCorrectQuotient()
      {
         var calculateHelper = new CalculateHelper
         {
            Operation = Operation.Divide,
            Operand1 = 5,
            Operand2 = 2
         };
         Assert.AreEqual( 2.5, calculateHelper.Calculate(), 0.01 );
      }

      [TestMethod]
      public void Calculate_MultipleOperationChain_ReturnsCorrectAnswer()
      {
         // 5 * 2 + 6  = 16
         var calculateHelper = new CalculateHelper
         {
            Operand1 = 5,
            Operand2 = 2,
            Operation = Operation.Multiply
         };
         calculateHelper.UpdateOperands();
         calculateHelper.Operand2 = 6;
         calculateHelper.Operation = Operation.Add;
         var result = calculateHelper.UpdateOperands();
         Assert.AreEqual( "16", result );
      }
   }
}
