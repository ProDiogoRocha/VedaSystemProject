namespace VedaSystem.Application.Utils
{
    public static class TratarObjeto<T> where T : class
    {
        public static T MesclarObjeto(T t, T v)
        {
            foreach (var p in t.GetType().GetProperties())
            {
                var prop = v.GetType().GetProperty(p.Name);

                if (prop != null)
                {
                    p.SetValue(p, prop.GetValue(prop, null));
                }
            }
            return t;
        }
    }
}
