using System;

namespace XMainClient
{
	// Token: 0x02001428 RID: 5160
	internal class Process_PtcG2C_HeroBattleTeamRoleNtf
	{
		// Token: 0x0600E5A6 RID: 58790 RVA: 0x0033D3D0 File Offset: 0x0033B5D0
		public static void Process(PtcG2C_HeroBattleTeamRoleNtf roPtc)
		{
			XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			specificDocument.SetHeroBattleMyTeam(roPtc.Data);
		}
	}
}
