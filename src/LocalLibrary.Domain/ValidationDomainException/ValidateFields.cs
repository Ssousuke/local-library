using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalLibrary.Domain.ValidationDomainException
{
    public static class ValidateFields
    {
        public static string CheckAndRemoveSpecialCharacters(string inputString)
        {
            var newString = string.Empty;
            if (!string.IsNullOrEmpty(inputString))
            {
                // Caracteres a serem removidos
                char[] caracteresEspeciais = { '-', '/', '\\', '.', ';', '@', '$' };

                // Verifica e remove os caracteres especiais
                foreach (char c in inputString)
                {
                    if (!caracteresEspeciais.Contains(c))
                    {
                        newString += c;
                    }
                }
            }

            return newString;
        }
    }
}
