using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace Gallery.Web.Services
{
	[ServiceContract(Namespace = "MobileMeGallery")]
	public interface IGallery
	{

		[WebGet(UriTemplate = "/{username}",
				ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		Stream GetGallery(string username);

	}
}
