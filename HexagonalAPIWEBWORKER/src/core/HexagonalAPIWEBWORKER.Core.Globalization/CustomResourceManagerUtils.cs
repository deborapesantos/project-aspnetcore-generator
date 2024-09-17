using System.Resources;

namespace HexagonalAPIWEBWORKER.Core.Globalization
{
    public class CustomResourceManagerUtils
    {
        public static ResourceManager GetResourceManager()
        {
            return new ResourceManager("BiddingTrack.Core.ResourceMessage.Resource", typeof(CustomResourceManagerUtils).Assembly);
        }
    }
}
