using System.Threading.Tasks;
using ProfileSample.DAL;

namespace ProfileSample.Providers
{
    public interface IImagesProvider
    {
        Task<byte[]> GetImageDataByIdAsync(int imageId);
    }

    public class ImagesProvider : IImagesProvider
    {
        public async Task<byte[]> GetImageDataByIdAsync(int imageId)
        {
            using (var context = new ProfileSampleEntities())
            {
                ImgSource item = await context.ImgSources.FindAsync(imageId);

                return item?.Data;
            }
        }
    }
}