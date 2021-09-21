using System;

namespace XMainClient
{
	// Token: 0x0200167F RID: 5759
	internal class Process_PtcG2C_RiftSceneInfoNtf
	{
		// Token: 0x0600EF4C RID: 61260 RVA: 0x0034B154 File Offset: 0x00349354
		public static void Process(PtcG2C_RiftSceneInfoNtf roPtc)
		{
			XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
			specificDocument.OnRiftSceneInfo(roPtc.Data);
		}
	}
}
