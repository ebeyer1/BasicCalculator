using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BasicCalculator
{
   public partial class CalculatorApp : Form
   {
      private static bool _signed;
      private static CalculateHelper _calculateHelper;
      private static bool _answered;
      private static bool _onFirstOperand = true;

      public CalculatorApp()
      {
         InitializeComponent();
         _calculateHelper = new CalculateHelper();
      }

      private void btnZero_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "0" );
      }

      private void btnOne_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "1" );
      }

      private void btnTwo_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "2" );
      }

      private void btnThree_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "3" );
      }

      private void btnFour_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "4" );
      }

      private void btnFive_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "5" );
      }

      private void btnSix_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "6" );
      }

      private void btnSeven_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "7" );
      }

      private void btnEight_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "8" );
      }

      private void btnNine_Click( object sender, EventArgs e )
      {
         AddToDisplayBox( "9" );
      }

      private void btnSign_Click( object sender, EventArgs e )
      {
         var length = displayBox.Text.Length;
         if ( length > 0 && !displayBox.Text.Equals("0") )
         {
            if ( displayBox.Text[0].Equals( '-' ) )
            {
               displayBox.Text = displayBox.Text.Substring( 1 );
               _signed = false;
            }
            else
            {
               _signed = true;
            }
            if ( _onFirstOperand )
            {
               _calculateHelper.Operand1 *= -1;
            }
            else
            {
               _calculateHelper.Operand2 *= -1;
            }
         }
         AddToDisplayBox( "" ); //Forces sign to be added or removed.
      }

      private void btnDot_Click( object sender, EventArgs e )
      {
         if ( !displayBox.Text.Contains( "." ) )
         {
            AddToDisplayBox( "." );
         }
      }

      private void btnClear_Click( object sender, EventArgs e )
      {
         ClearDisplayBox();
         _onFirstOperand = true;
         _answered = false;
         _calculateHelper = null;
         _calculateHelper = new CalculateHelper();
      }

      private void ClearDisplayBox()
      {
         displayBox.Text = string.Empty;
      }

      private void AddToDisplayBox( string s )
      {
         if ( displayBox.Text.Equals( "0" ) )
         {
            displayBox.Text = s;
         }
         else if ( _signed && displayBox.Text.Length > 0 )
         {
            displayBox.Text = string.Format( "-{0}", displayBox.Text );
         }
         else
         {
            if ( _answered )
            {
               displayBox.Text = s;
               _answered = false;
            }
            else
            {
               displayBox.Text += s;
            }
         }
      }

      private void btnAdd_Click( object sender, EventArgs e )
      {
         StoreOperand( displayBox.Text );
         StoreOperation( Operation.Add );
      }

      private void StoreOperation( Operation operation )
      {
         _calculateHelper.Operation = operation;
      }

      private void StoreOperand( string operand )
      {
         //if ( _signed )
         //{
         //   operand = string.Format( "-{0}", operand.Substring( 0, operand.Length - 1 ) );
         //}
         double number;
         double.TryParse( operand, out number );
         //if ( _calculateHelper.Operand1.Equals( 0 ) )
         if ( _onFirstOperand )
         {
            _calculateHelper.Operand1 = number;
            displayBox.Text = string.Empty;
            _onFirstOperand = false;
         }
         else
         {
            _calculateHelper.Operand2 = number;
            displayBox.Text = _calculateHelper.UpdateOperands();
            _answered = true;
            _onFirstOperand = true;
         }
      }

      private void btnSubtract_Click( object sender, EventArgs e )
      {
         StoreOperand( displayBox.Text );
         StoreOperation( Operation.Subtract );
      }

      private void btnMultiply_Click( object sender, EventArgs e )
      {
         StoreOperand( displayBox.Text );
         StoreOperation( Operation.Multiply );
      }

      private void btnDivide_Click( object sender, EventArgs e )
      {
         StoreOperand( displayBox.Text );
         StoreOperation( Operation.Divide );
      }

      private void btnCalculate_Click( object sender, EventArgs e )
      {
         StoreOperand( displayBox.Text );
         StoreOperation( Operation.None );
      }
   }
}
