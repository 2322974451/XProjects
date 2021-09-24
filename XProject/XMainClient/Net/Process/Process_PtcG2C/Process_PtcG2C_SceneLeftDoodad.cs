using System;

namespace XMainClient
{

	internal class Process_PtcG2C_SceneLeftDoodad
	{

		public static void Process(PtcG2C_SceneLeftDoodad roPtc)
		{
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument.SetPickItemList(roPtc.Data.items);
		}
	}
}
