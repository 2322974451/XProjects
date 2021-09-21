using System;

namespace XMainClient
{
	// Token: 0x020011CA RID: 4554
	internal class Process_PtcG2C_JoinRoomReply
	{
		// Token: 0x0600DBF0 RID: 56304 RVA: 0x0032FABC File Offset: 0x0032DCBC
		public static void Process(PtcG2C_JoinRoomReply roPtc)
		{
			XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
			specificDocument.JoinRoom(roPtc.Data);
		}
	}
}
