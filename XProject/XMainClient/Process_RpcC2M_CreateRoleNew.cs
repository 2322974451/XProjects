using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001145 RID: 4421
	internal class Process_RpcC2M_CreateRoleNew
	{
		// Token: 0x0600D9DE RID: 55774 RVA: 0x0032BB48 File Offset: 0x00329D48
		public static void OnReply(CreateRoleNewArg oArg, CreateRoleNewRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(ErrorCode.ERR_FAILED);
			}
			else
			{
				bool flag2 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(false);
					ErrorCode result = oRes.result;
					if (result <= ErrorCode.ERR_INVALID_NAME)
					{
						if (result == ErrorCode.ERR_SUCCESS)
						{
							RpcC2M_SelectRoleNew rpcC2M_SelectRoleNew = new RpcC2M_SelectRoleNew();
							rpcC2M_SelectRoleNew.oArg.index = (int)oArg.type % (int)(RoleType)10 - (int)RoleType.Role_Warrior;
							XSingleton<XClientNetwork>.singleton.Send(rpcC2M_SelectRoleNew);
							return;
						}
						if (result - ErrorCode.ERR_NAME_EXIST > 1)
						{
							goto IL_D3;
						}
					}
					else if (result != ErrorCode.ERR_WORD_FORBID && result - ErrorCode.ERR_NAME_ALLNUM > 2)
					{
						goto IL_D3;
					}
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					return;
					IL_D3:
					XSingleton<XClientNetwork>.singleton.OnServerErrorNotify((uint)oRes.result, null);
				}
			}
		}

		// Token: 0x0600D9DF RID: 55775 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(CreateRoleNewArg oArg)
		{
		}
	}
}
