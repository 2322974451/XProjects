using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x0200102E RID: 4142
	internal class Process_RpcC2G_GMCommand
	{
		// Token: 0x0600D565 RID: 54629 RVA: 0x00323F8D File Offset: 0x0032218D
		public static void OnReply(GMCmdArg oArg, GMCmdRes oRes)
		{
			DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(oRes.outputMessage);
		}

		// Token: 0x0600D566 RID: 54630 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTimeout(GMCmdArg oArg)
		{
		}
	}
}
