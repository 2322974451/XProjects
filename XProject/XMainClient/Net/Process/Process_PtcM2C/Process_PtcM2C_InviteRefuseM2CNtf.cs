using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_InviteRefuseM2CNtf
	{

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
