using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ShareRandomGiftNtf
	{

		public static void Process(PtcG2C_ShareRandomGiftNtf roPtc)
		{
			RpcC2G_GetPlatformShareChest rpcC2G_GetPlatformShareChest = new RpcC2G_GetPlatformShareChest();
			rpcC2G_GetPlatformShareChest.oArg.box_id = roPtc.Data.id;
			rpcC2G_GetPlatformShareChest.oArg.open_key = XSingleton<XClientNetwork>.singleton.OpenKey;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GetPlatformShareChest);
		}
	}
}
