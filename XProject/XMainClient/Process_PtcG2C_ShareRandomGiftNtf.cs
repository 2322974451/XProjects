using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B68 RID: 2920
	internal class Process_PtcG2C_ShareRandomGiftNtf
	{
		// Token: 0x0600A919 RID: 43289 RVA: 0x001E19D4 File Offset: 0x001DFBD4
		public static void Process(PtcG2C_ShareRandomGiftNtf roPtc)
		{
			RpcC2G_GetPlatformShareChest rpcC2G_GetPlatformShareChest = new RpcC2G_GetPlatformShareChest();
			rpcC2G_GetPlatformShareChest.oArg.box_id = roPtc.Data.id;
			rpcC2G_GetPlatformShareChest.oArg.open_key = XSingleton<XClientNetwork>.singleton.OpenKey;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetPlatformShareChest);
		}
	}
}
