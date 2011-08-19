using System.Configuration;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Gallery.Web.Services
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class GalleryService
	{
		string galleryUrlFormat = ConfigurationManager.AppSettings["GalleryUrlFormat"];
		string albumUrlFormat = ConfigurationManager.AppSettings["AlbumUrlFormat"];

		[WebGet(UriTemplate = "/{username}",
				ResponseFormat = WebMessageFormat.Json,
				BodyStyle = WebMessageBodyStyle.Bare)]
		[OperationContract]
		public string GetGallery(string username)
		{
			var webClient = new WebClient();
			string photocasturl = string.Format(galleryUrlFormat, username);
			return new StreamReader(webClient.OpenRead(photocasturl)).ReadToEnd();
		}

		[WebGet(UriTemplate = "/{username}/{id}",
				ResponseFormat = WebMessageFormat.Json,
				BodyStyle = WebMessageBodyStyle.Bare)]
		[OperationContract]
		public string GetAlbum(string username, string id)
		{
			var webClient = new WebClient();
			string albumUrl = string.Format(albumUrlFormat, username, id);
			return new StreamReader(webClient.OpenRead(albumUrl)).ReadToEnd();
		}

	}
}
