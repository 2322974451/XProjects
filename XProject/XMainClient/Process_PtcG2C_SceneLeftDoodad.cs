using System;

namespace XMainClient
{
	// Token: 0x020010C9 RID: 4297
	internal class Process_PtcG2C_SceneLeftDoodad
	{
		// Token: 0x0600D7DC RID: 55260 RVA: 0x00328BD0 File Offset: 0x00326DD0
		public static void Process(PtcG2C_SceneLeftDoodad roPtc)
		{
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			specificDocument.SetPickItemList(roPtc.Data.items);
		}
	}
}
