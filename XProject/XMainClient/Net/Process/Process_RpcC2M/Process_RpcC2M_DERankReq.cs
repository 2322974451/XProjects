using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_DERankReq
	{

		public static void OnReply(DERankArg oArg, DERankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				XDragonCrusadeDocument specificDocument = XDocuments.GetSpecificDocument<XDragonCrusadeDocument>(XDragonCrusadeDocument.uuID);
				specificDocument.OnDERankReq(oRes);
			}
		}

		public static void OnTimeout(DERankArg oArg)
		{
		}
	}
}
