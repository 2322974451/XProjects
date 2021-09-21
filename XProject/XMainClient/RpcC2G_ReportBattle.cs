using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001092 RID: 4242
	internal class RpcC2G_ReportBattle : Rpc
	{
		// Token: 0x0600D707 RID: 55047 RVA: 0x00327118 File Offset: 0x00325318
		public override uint GetRpcType()
		{
			return 21292U;
		}

		// Token: 0x0600D708 RID: 55048 RVA: 0x0032712F File Offset: 0x0032532F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReportBattleArg>(stream, this.oArg);
		}

		// Token: 0x0600D709 RID: 55049 RVA: 0x0032713F File Offset: 0x0032533F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReportBattleRes>(stream);
		}

		// Token: 0x0600D70A RID: 55050 RVA: 0x0032714E File Offset: 0x0032534E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReportBattle.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D70B RID: 55051 RVA: 0x0032716A File Offset: 0x0032536A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReportBattle.OnTimeout(this.oArg);
		}

		// Token: 0x04006195 RID: 24981
		public ReportBattleArg oArg = new ReportBattleArg();

		// Token: 0x04006196 RID: 24982
		public ReportBattleRes oRes = new ReportBattleRes();
	}
}
