using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2G_SelectChestReward
	{

		public static void OnReply(SelectChestArg oArg, SelectChestRes oRes)
		{
			bool flag = oRes.errcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errcode > ErrorCode.ERR_SUCCESS;
				if (!flag2)
				{
					XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
					specificDocument.SetPlayerSelectChestID((int)oArg.chestIdx);
				}
			}
		}

		public static void OnTimeout(SelectChestArg oArg)
		{
		}
	}
}
