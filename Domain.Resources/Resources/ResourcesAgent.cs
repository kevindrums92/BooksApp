using Domain.Resources.Resources;
using System.Reflection;

namespace Domain.Resources
{
    public static class ResourcesAgent
    {
        public static string GetResource(string name)
        {
            // Create a resource manager to retrieve resources.
            //ResourceManager rm = new ResourceManager("Help", Assembly.GetExecutingAssembly());
            global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Domain.Resources.Resources.Messages", typeof(Messages).GetTypeInfo().Assembly);
            // Retrieve the value of the string resource named "welcome".
            // The resource manager will retrieve the value of the  
            // localized resource using the caller's current culture setting.

            return temp.GetString(name);


        }
    }
}
