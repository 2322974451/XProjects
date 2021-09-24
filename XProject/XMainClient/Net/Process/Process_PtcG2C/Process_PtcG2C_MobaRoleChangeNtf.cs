using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MobaRoleChangeNtf
	{

		public static void Process(PtcG2C_MobaRoleChangeNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.OnDataChange(roPtc.Data.changeRole);
		}
	}
}
