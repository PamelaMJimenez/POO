using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace pmunoz_Lab3.Utilidades
{
    public class util
    {
        public static void validarSoloLetras(TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Solo se permiten letras!", "Advertencia", MessageBoxButton.OK);
                e.Handled = true;
            }
        }

        public static void validarNumerosyLetras(TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));

            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122) || (character >= 48 && character <= 57))
            {
                e.Handled = false;
            }

            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y letras", "ADVERTENCIA", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


    }
}
