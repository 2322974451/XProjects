using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcM2C_GiftIBSucessNtf
	{

		public static void Process(PtcM2C_GiftIBSucessNtf roPtc)
		{
			DlgBase<PresentDlg, PresentBehaviour>.singleton.OnResPresent(roPtc.Data.openid, roPtc.Data.name);
		}
	}
}
