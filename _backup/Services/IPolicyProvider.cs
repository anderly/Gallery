using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace Gallery.Web.Services
{
	[ServiceContract(Namespace = "MobileMeGallery")]
	public interface IPolicyProvider
	{
		[OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
		Stream GetSilverlightPolicy();
	}
}
