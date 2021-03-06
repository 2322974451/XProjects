using System;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_RpcC2M_GetQADataReq
	{

		public static void OnReply(GetQADataReq oArg, GetQADataRes oRes)
		{
			XVoiceQADocument specificDocument = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
				bool flag2 = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
				if (flag2)
				{
					specificDocument.IsVoiceQAIng = false;
					specificDocument.MainInterFaceBtnState = false;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
					DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(false, true);
				}
			}
			else
			{
				bool flag3 = oRes.result == ErrorCode.ERR_INVALID_REQUEST;
				if (flag3)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag4 = oRes.result > ErrorCode.ERR_SUCCESS;
					if (flag4)
					{
						bool flag5 = DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.IsVisible();
						if (flag5)
						{
							specificDocument.IsVoiceQAIng = false;
							specificDocument.MainInterFaceBtnState = false;
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
							DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(false, true);
						}
					}
					else
					{
						specificDocument.SetVoiceQAInfo(oRes);
					}
				}
			}
		}

		public static void OnTimeout(GetQADataReq oArg)
		{
		}
	}
}
