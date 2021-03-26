using Microsoft.AspNetCore.Mvc;

namespace VedaSystem.UI.Web.Extensions
{
    public static class VectorExtensions
    {
        public static BindAttribute ObterPropriedadesObrigatorias(object obj)
        {
            BindAttribute bind = new BindAttribute();

            foreach (var prop in obj.GetType().GetProperties())
            {
                var teste = prop.Attributes;
                //if (prop.Attributes)
                //{

                //}
                //var teste = prop.Attributes;
            }
            return bind;
        }
    }
}
