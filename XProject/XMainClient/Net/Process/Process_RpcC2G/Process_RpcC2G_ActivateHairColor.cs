using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_ActivateHairColor
	{

		public static void OnReply(ActivateHairColorArg oArg, ActivateHairColorRes oRes)
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			specificDocument.SetActivateHairColor(oRes);
		}

		public static void OnTimeout(ActivateHairColorArg oArg)
		{
		}
	}
}
