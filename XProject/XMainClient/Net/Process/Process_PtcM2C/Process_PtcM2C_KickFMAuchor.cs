using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_PtcM2C_KickFMAuchor
	{

		public static void Process(PtcM2C_KickFMAuchor roPtc)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.QuitBigRoom();
			DlgBase<RadioDlg, RadioBehaviour>.singleton.Refresh(false);
		}
	}
}
