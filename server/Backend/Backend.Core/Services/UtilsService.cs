using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Backend.Core.Interfaces;

namespace Backend.Core.Services
{
    public class UtilsService : IUtilsService
    {
        public bool ValidarCnpfcnpj(string cpfcnpj)
        {
            if (string.IsNullOrEmpty(cpfcnpj))
                return false;
            else
            {
                var d = new int[14];
                var v = new int[2];
                int j, i, soma;

                var soNumero = Regex.Replace(cpfcnpj, "[^0-9]", string.Empty);

                if (new string(soNumero[0], soNumero.Length) == soNumero) return false;


                if (soNumero.Length == 11)
                {
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(soNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                }

                if (soNumero.Length != 14)
                    return false;

                const string sequencia = "6543298765432";
                for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(soNumero.Substring(i, 1));
                for (i = 0; i <= 1; i++)
                {
                    soma = 0;
                    for (j = 0; j <= 11 + i; j++)
                        soma += d[j] * Convert.ToInt32(sequencia.Substring(j + 1 - i, 1));

                    v[i] = (soma * 10) % 11;
                    if (v[i] == 10) v[i] = 0;
                }
                return (v[0] == d[12] & v[1] == d[13]);
            }
        }
    }
}
