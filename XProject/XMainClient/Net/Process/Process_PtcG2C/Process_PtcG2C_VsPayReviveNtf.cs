using System;

namespace XMainClient
{

	internal class Process_PtcG2C_VsPayReviveNtf
	{

		public static void Process(PtcG2C_VsPayReviveNtf roPtc)
		{
			XGuildArenaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XGuildArenaBattleDocument>(XGuildArenaBattleDocument.uuID);
			specificDocument.NotifyVSPayRevive(roPtc.Data);
		}
	}
}
