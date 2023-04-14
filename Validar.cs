using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfOnBreak
{
    class Validar
    {
        private void txtnum_PreviewTextInput(object sender, TextCompositionEventArgs e)

        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 48 && ascci <= 57) e.Handled = false;

            else e.Handled = true;

            }
        }
    }

