using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class Process_RpcC2G_GMCommand
	{

		public static void OnReply(GMCmdArg oArg, GMCmdRes oRes)
		{
			DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(oRes.outputMessage);
		}

		public static void OnTimeout(GMCmdArg oArg)
		{
		}
	}
}
