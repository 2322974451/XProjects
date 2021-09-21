using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001141 RID: 4417
	internal class Process_RpcC2G_GetDragonTopInfo
	{
		// Token: 0x0600D9CC RID: 55756 RVA: 0x0032B984 File Offset: 0x00329B84
		public static void OnReply(GetDragonTopInfoArg oArg, GetDragonTopInfoRes oRes)
		{
			bool flag = oRes.errorCode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XDragonNestDocument specificDocument = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
				bool flag2 = oRes.errorCode == ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					specificDocument.SetDragonNestInfo(oRes.dragonInfo);
				}
			}
		}

		// Token: 0x0600D9CD RID: 55757 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GetDragonTopInfoArg oArg)
		{
		}
	}
}
