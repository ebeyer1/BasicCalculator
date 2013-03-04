namespace BasicCalculator
{
   public class CalculateHelper
   {
      public Operation Operation
      {
         get;
         set;
      }

      public double Operand1
      {
         get;
         set;
      }

      public double Operand2
      {
         get;
         set;
      }

      private double Add()
      {
         return Operand1 + Operand2;
      }

      private double Subtract()
      {
         return Operand1 - Operand2;
      }

      private double Multiply()
      {
         return Operand1 * Operand2;
      }

      private double Divide()
      {
         return Operand1 / Operand2;
      }

      public string UpdateOperands()
      {
         Operand1 = Calculate();
         Operand2 = 0;
         var number = Operand1.ToString();
         //if ( number[0].Equals( '-' ) )
         //{
         //   number = string.Format( "{0}-", number.Substring( 1 ) );
         //}
         return number;
      }

      public double Calculate()
      {
         switch ( Operation )
         {
            case Operation.Add:
            {
               return Add();
            }
            case Operation.Subtract:
            {
               return Subtract();
            }
            case Operation.Multiply:
            {
               return Multiply();
            }
            case Operation.Divide:
            {
               return Divide();
            }
            case Operation.None:
            {
               return Operand1;
            }
            default:
            {
               return 0;
            }
         }
      }
   }
}
