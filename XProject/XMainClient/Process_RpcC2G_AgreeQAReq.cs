using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001128 RID: 4392
	internal class Process_RpcC2G_AgreeQAReq
	{
		// Token: 0x0600D961 RID: 55649 RVA: 0x0032AFB4 File Offset: 0x003291B4
		public static void OnReply(AgreeQAReq oArg, AgreeQARes oRes)
		{
			bool flag = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
				bool flag2 = oRes.result > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
					specificDocument.MainInterFaceBtnState = false;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
				}
				else
				{
					specificDocument.IsVoiceQAIng = oArg.agree;
					bool flag3 = !oArg.agree;
					if (flag3)
					{
						specificDocument.MainInterFaceBtnState = false;
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
					}
					else
					{
						XMainInterfaceDocument specificDocument2 = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
						specificDocument2.SetVoiceBtnAppear(0U);
						specificDocument.VoiceQAInit(oArg.type);
						specificDocument.IsFirstOpenUI = true;
						specificDocument.OpenView();
					}
				}
			}
		}

		// Token: 0x0600D962 RID: 55650 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(AgreeQAReq oArg)
		{
		}
	}
}
