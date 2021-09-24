using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_PhotographEffect
	{

		public static void OnReply(PhotographEffectArg oArg, PhotographEffect oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
				specificDocument.OnGetPhotoGraphEffect(oRes);
			}
		}

		public static void OnTimeout(PhotographEffectArg oArg)
		{
		}
	}
}
