using System;

namespace XMainClient
{

	internal class Process_PtcG2C_InvFightBefEnterSceneNtf
	{

		public static void Process(PtcG2C_InvFightBefEnterSceneNtf roPtc)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.EnterFightScene(roPtc);
		}
	}
}
