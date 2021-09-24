using System;

namespace XMainClient
{

	internal class Process_PtcG2C_UpdateVoipRoomMemberNtf
	{

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
