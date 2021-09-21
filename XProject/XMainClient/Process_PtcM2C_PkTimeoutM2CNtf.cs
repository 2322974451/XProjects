using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001224 RID: 4644
	internal class Process_PtcM2C_PkTimeoutM2CNtf
	{
		// Token: 0x0600DD5D RID: 56669 RVA: 0x00331BD0 File Offset: 0x0032FDD0
		public static void Process(PtcM2C_PkTimeoutM2CNtf roPtc)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MATCH_TIME_OUT"), "fece00");
			XQualifyingDocument specificDocument = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
			specificDocument.SetMatchTime(0U, false);
		}
	}
}
