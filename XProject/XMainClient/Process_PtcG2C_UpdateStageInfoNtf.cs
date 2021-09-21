using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001675 RID: 5749
	internal class Process_PtcG2C_UpdateStageInfoNtf
	{
		// Token: 0x0600EF23 RID: 61219 RVA: 0x0034ACCC File Offset: 0x00348ECC
		public static void Process(PtcG2C_UpdateStageInfoNtf roPtc)
		{
			XSingleton<XStageProgress>.singleton.Init(roPtc.Data.Stages);
			XAbyssPartyDocument specificDocument = XDocuments.GetSpecificDocument<XAbyssPartyDocument>(XAbyssPartyDocument.uuID);
			bool flag = roPtc.Data.Stages.absparty != null;
			if (flag)
			{
				specificDocument.SetAbyssIndex(roPtc.Data.Stages.absparty.aby);
			}
		}
	}
}
