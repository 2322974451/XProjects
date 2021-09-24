using System;

namespace XMainClient
{

	internal class Process_PtcG2C_GuildCheckinBoxNtf
	{

		public static void Process(PtcG2C_GuildCheckinBoxNtf roPtc)
		{
			XGuildSignInDocument specificDocument = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
			specificDocument.SetChestStateAndProgress(roPtc.Data.processbar, roPtc.Data.boxmask);
		}
	}
}
