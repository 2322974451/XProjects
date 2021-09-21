using System;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x0200149D RID: 5277
	internal class Process_PtcM2C_KickFMAuchor
	{
		// Token: 0x0600E77E RID: 59262 RVA: 0x0034013C File Offset: 0x0033E33C
		public static void Process(PtcM2C_KickFMAuchor roPtc)
		{
			XRadioDocument specificDocument = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
			specificDocument.QuitBigRoom();
			DlgBase<RadioDlg, RadioBehaviour>.singleton.Refresh(false);
		}
	}
}
