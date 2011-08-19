using System.Configuration;
using System.IO;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Gallery.Web.Services
{
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class GalleryService : IGallery, IPolicyProvider
	{
		string photocastUrlFormat = ConfigurationManager.AppSettings["PhotocastUrlFormat"];

		#region IGallery Members

		public Stream GetGallery(string username)
		{
			WebClient meService = new WebClient();
			string photocastUrl = string.Format(photocastUrlFormat, username);
			return meService.OpenRead(photocastUrl);
		}

		#endregion

		#region IPolicyProvider Members

		public Stream GetSilverlightPolicy()
		{
			WebOperationContext.Current.OutgoingResponse.ContentType = "application/xml";
			return new MemoryStream(File.ReadAllBytes("clientaccesspolicy.xml"), false);
		}

		#endregion
	}
}
