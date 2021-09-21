using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020011E9 RID: 4585
	internal class Process_PtcM2C_InviteRefuseM2CNtf
	{
		// Token: 0x0600DC6A RID: 56426 RVA: 0x00330520 File Offset: 0x0032E720
		public static void Process(PtcM2C_InviteRefuseM2CNtf roPtc)
		{
			XTeamInviteDocument specificDocument = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAM_REFUSE_INVITATION", new object[]
			{
				roPtc.Data.name
			}), "fece00");
		}
	}
}
