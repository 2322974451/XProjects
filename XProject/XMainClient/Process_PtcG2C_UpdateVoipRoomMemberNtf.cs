using System;

namespace XMainClient
{
	// Token: 0x020011CD RID: 4557
	internal class Process_PtcG2C_UpdateVoipRoomMemberNtf
	{
		// Token: 0x0600DBFC RID: 56316 RVA: 0x0032FB84 File Offset: 0x0032DD84
		public static void Process(PtcG2C_UpdateVoipRoomMemberNtf roPtc)
		{
			XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
			bool flag = specificDocument != null;
			if (flag)
			{
				specificDocument.OnMembersInfoChange(roPtc.Data.dataList);
			}
		}
	}
}
