using System.Threading.Tasks;
using System.Web.Mvc;
using ProfileSample.Providers;

namespace ProfileSample.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImagesProvider _imagesProvider;

        public ImagesController()
        {
            _imagesProvider = new ImagesProvider();
        }

        // GET: Images/Get/{id}
        public async Task<ActionResult> Get(string id)
        {
            int imageId;
            int.TryParse(id, out imageId);
            var fileData = await _imagesProvider.GetImageDataByIdAsync(imageId);
            if (fileData != null)
            {
                return File(fileData, "image/jpeg");
            }
            else
            {
                return HttpNotFound();
            }
        }
    }
}