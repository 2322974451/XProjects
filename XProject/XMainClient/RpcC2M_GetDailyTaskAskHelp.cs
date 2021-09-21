using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001613 RID: 5651
	internal class RpcC2M_GetDailyTaskAskHelp : Rpc
	{
		// Token: 0x0600ED83 RID: 60803 RVA: 0x00348750 File Offset: 0x00346950
		public override uint GetRpcType()
		{
			return 46394U;
		}

		// Token: 0x0600ED84 RID: 60804 RVA: 0x00348767 File Offset: 0x00346967
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskAskHelpArg>(stream, this.oArg);
		}

		// Token: 0x0600ED85 RID: 60805 RVA: 0x00348777 File Offset: 0x00346977
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskAskHelpRes>(stream);
		}

		// Token: 0x0600ED86 RID: 60806 RVA: 0x00348786 File Offset: 0x00346986
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDailyTaskAskHelp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED87 RID: 60807 RVA: 0x003487A2 File Offset: 0x003469A2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDailyTaskAskHelp.OnTimeout(this.oArg);
		}

		// Token: 0x040065E2 RID: 26082
		public GetDailyTaskAskHelpArg oArg = new GetDailyTaskAskHelpArg();

		// Token: 0x040065E3 RID: 26083
		public GetDailyTaskAskHelpRes oRes = null;
	}
}
