using System;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_QueryResWarRoleRank
	{

		public static void OnReply(ResWarRoleRankArg oArg, ResWarRoleRankRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				XGuildMineMainDocument specificDocument = XDocuments.GetSpecificDocument<XGuildMineMainDocument>(XGuildMineMainDocument.uuID);
				specificDocument.OnGetRankInfo(oRes);
			}
		}

		public static void OnTimeout(ResWarRoleRankArg oArg)
		{
		}
	}
}
