using System;
using KKSG;

namespace XMainClient
{

	internal class Process_RpcC2M_GardenExpelSprite
	{

		public static void OnReply(GardenExpelSpriteArg oArg, GardenExpelSpriteRes oRes)
		{
			HomePlantDocument.Doc.OnDriveTroubleMakerBack(oRes);
		}

		public static void OnTimeout(GardenExpelSpriteArg oArg)
		{
		}
	}
}
