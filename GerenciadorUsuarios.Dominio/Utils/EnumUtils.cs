using System.ComponentModel.DataAnnotations;

namespace GerenciadorUsuarios.Dominio.Utils
{
    public static class EnumUtils
    {
        public static string DisplayName(this Enum @enum)
        {
            if (@enum is null)
                return "";

            Type tipo = @enum.GetType();

            var nome = Enum.GetName(tipo, @enum);

            if (nome != null)
            {
                var item = tipo.GetMember(nome)
                    .FirstOrDefault();

                if (item != null)
                {
                    var atributo = (DisplayAttribute)item
                        .GetCustomAttributes(typeof(DisplayAttribute), false)
                        .FirstOrDefault();

                    if (atributo is null)
                        return "";

                    var descricao = atributo.Name;

                    if (atributo.ResourceType != null)
                        descricao = atributo.GetName();

                    return descricao;
                }
            }
            return "";
        }

        public static bool IsInEnum<T>(this Enum @enum) where T : Enum
        {
            if (@enum is null)
                return false;

            return GetElements<T>()
                .Any(x => x.GetType().Equals(@enum.GetType()));
        }

        public static int GetValue(this Enum @enum)
        {
            return Convert.ToInt32(@enum);
        }

        public static KeyValuePair<string, int> ToKeyValuePair<T>(this T @enum) where T : Enum
        {
            return new KeyValuePair<string, int>(@enum.DisplayName(), @enum.GetValue());
        }

        public static IEnumerable<T> GetElements<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
