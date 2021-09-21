using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x0200133E RID: 4926
	internal class Process_RpcC2M_GardenExpelSprite
	{
		// Token: 0x0600E1EA RID: 57834 RVA: 0x003384ED File Offset: 0x003366ED
		public static void OnReply(GardenExpelSpriteArg oArg, GardenExpelSpriteRes oRes)
		{
			HomePlantDocument.Doc.OnDriveTroubleMakerBack(oRes);
		}

		// Token: 0x0600E1EB RID: 57835 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GardenExpelSpriteArg oArg)
		{
		}
	}
}
