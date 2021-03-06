using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcG2C_QANotify
	{

		public static void Process(PtcG2C_QANotify roPtc)
		{
			bool flag = roPtc.Data.type == 0U;
			if (!flag)
			{
				XMainInterfaceDocument specificDocument = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
				XVoiceQADocument specificDocument2 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
				bool is_over = roPtc.Data.is_over;
				if (is_over)
				{
					specificDocument2.TempType = 0U;
					specificDocument2.IsVoiceQAIng = false;
					specificDocument2.MainInterFaceBtnState = false;
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildRelax_VoiceQA, true);
				}
				else
				{
					bool is_playing = roPtc.Data.is_playing;
					if (is_playing)
					{
						specificDocument2.IsVoiceQAIng = true;
						specificDocument.SetVoiceBtnAppear(0U);
						specificDocument2.VoiceQAInit(roPtc.Data.type);
					}
					else
					{
						specificDocument2.TempType = roPtc.Data.type;
						specificDocument.SetVoiceBtnAppear(roPtc.Data.type);
					}
				}
			}
		}
	}
}
