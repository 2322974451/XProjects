using System;

namespace XMainClient
{
	// Token: 0x0200124A RID: 4682
	internal class Process_PtcG2C_SpriteChangedNtf
	{
		// Token: 0x0600DDFC RID: 56828 RVA: 0x00332AA8 File Offset: 0x00330CA8
		public static void Process(PtcG2C_SpriteChangedNtf roPtc)
		{
			XSpriteSystemDocument specificDocument = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			specificDocument.OnSpriteChange(roPtc);
		}
	}
}
