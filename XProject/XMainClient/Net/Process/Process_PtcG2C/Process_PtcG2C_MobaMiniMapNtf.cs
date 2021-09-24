using System;

namespace XMainClient
{

	internal class Process_PtcG2C_MobaMiniMapNtf
	{

		public static void Process(PtcG2C_MobaMiniMapNtf roPtc)
		{
			XMobaBattleDocument specificDocument = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			specificDocument.SetMiniMapIcon(roPtc.Data.canSeePosIndex);
		}
	}
}
