using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001391 RID: 5009
	internal class RpcC2G_DailyTaskAskHelp : Rpc
	{
		// Token: 0x0600E33C RID: 58172 RVA: 0x0033A130 File Offset: 0x00338330
		public override uint GetRpcType()
		{
			return 9236U;
		}

		// Token: 0x0600E33D RID: 58173 RVA: 0x0033A147 File Offset: 0x00338347
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskAskHelpArg>(stream, this.oArg);
		}

		// Token: 0x0600E33E RID: 58174 RVA: 0x0033A157 File Offset: 0x00338357
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DailyTaskAskHelpRes>(stream);
		}

		// Token: 0x0600E33F RID: 58175 RVA: 0x0033A166 File Offset: 0x00338366
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DailyTaskAskHelp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E340 RID: 58176 RVA: 0x0033A182 File Offset: 0x00338382
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DailyTaskAskHelp.OnTimeout(this.oArg);
		}

		// Token: 0x040063E4 RID: 25572
		public DailyTaskAskHelpArg oArg = new DailyTaskAskHelpArg();

		// Token: 0x040063E5 RID: 25573
		public DailyTaskAskHelpRes oRes = new DailyTaskAskHelpRes();
	}
}
