using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Gallery.Model.MobileMe;

namespace Gallery.Web.Services
{
	[ServiceContract(Namespace = "MobileMeGallery")]
	public interface IGalleryService
	{

		[WebGet(UriTemplate = "/{username}",
		        ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		gallery GetGallery(string username);

		[WebGet(UriTemplate = "/{username}/{id}",
		        ResponseFormat = WebMessageFormat.Json)]
		[OperationContract]
		album GetAlbum(string username, string id);

	}
}
