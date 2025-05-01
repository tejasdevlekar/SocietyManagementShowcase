using System.Text;

namespace SocietyManagementShowcase.Common
{
    public static class SqlHelper
    {
        //Can't think of a way to create SQLHelper.
        //Abandon for now.
        public static void GetData<T>(T dataType, string spName, List<string> parameters, List<string> values)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"EXEC {spName}");
            for (int i = 0; i < parameters.Count; i++)
            {
                sb.Append($" {parameters[i]} = {values[i]}");
                if(i != parameters.Count-1) sb.Append(", ");
            }

            using EfCoreDbContext context = new EfCoreDbContext();
            
        }
    }
}
