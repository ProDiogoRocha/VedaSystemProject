using System;
using System.Collections.Generic;
using System.Text;

namespace VedaSystem.Application.Utils
{
    public static class Cripto<T>
    {
        public static string Criptografar(string valor)
        {
            string chaveCripto;
            byte[] cript = Encoding.ASCII.GetBytes(valor);
            chaveCripto = Convert.ToBase64String(cript);
            return chaveCripto;
        }

        public static string Descriptografar(string valor)
        {
            string chaveCripto;
            byte[] cript = Convert.FromBase64String(valor);
            chaveCripto = Encoding.ASCII.GetString(cript);
            return chaveCripto;
        }

        public static T CriptografarDadosSigilosos(T obj)
        {
            List<string> comparativos = ListarComparativos();

            foreach (var o in obj.GetType().GetProperties())
            {
                var prop = o.Name.ToLower();
                if (comparativos.Exists(a => a.Contains(prop)))
                {
                    if(o.GetValue(obj) != null)
                    {
                        o.SetValue(obj, Criptografar(o.GetValue(obj, null).ToString()), null);
                    }
                }
            }
            return obj;
        }

        private static List<string> ListarComparativos()
        {
            List<string> comparativos = new List<string>();
            comparativos.Add("senha");
            comparativos.Add("endereco");
            comparativos.Add("cpf");
            comparativos.Add("cnpj");
            comparativos.Add("confirmesenha");

            return comparativos;
        }
    }
}
