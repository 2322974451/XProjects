using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2G_QueryIBItem
	{

		public static void OnReply(IBQueryItemReq oArg, IBQueryItemRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XGameMallDocument specificDocument = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				specificDocument.RespItems(oArg, oRes);
			}
		}

		public static void OnTimeout(IBQueryItemReq oArg)
		{
		}
	}
}
