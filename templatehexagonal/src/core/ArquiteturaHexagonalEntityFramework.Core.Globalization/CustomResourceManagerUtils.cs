using System.Resources;

namespace TemplateHexagonal.Core.Globalization
{
    public class CustomResourceManagerUtils
    {
        public static ResourceManager GetResourceManager()
        {
            return new ResourceManager("BiddingTrack.Core.ResourceMessage.Resource", typeof(CustomResourceManagerUtils).Assembly);
        }
    }
}
