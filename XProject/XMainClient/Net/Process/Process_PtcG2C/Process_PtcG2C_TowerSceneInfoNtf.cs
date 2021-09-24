using System;

namespace XMainClient
{

	internal class Process_PtcG2C_TowerSceneInfoNtf
	{

		public static void Process(PtcG2C_TowerSceneInfoNtf roPtc)
		{
			XBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
			specificDocument.RefreshTowerSceneInfo(roPtc);
		}
	}
}
