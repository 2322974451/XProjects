using System;

namespace XMainClient
{

	internal class Process_PtcG2C_JoinRoomReply
	{

		public static void Process(PtcG2C_JoinRoomReply roPtc)
		{
			XApolloDocument specificDocument = XDocuments.GetSpecificDocument<XApolloDocument>(XApolloDocument.uuID);
			specificDocument.JoinRoom(roPtc.Data);
		}
	}
}
