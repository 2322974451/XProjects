using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200165B RID: 5723
	internal class RpcC2G_GuildPartySummonSpirit : Rpc
	{
		// Token: 0x0600EEBA RID: 61114 RVA: 0x0034A308 File Offset: 0x00348508
		public override uint GetRpcType()
		{
			return 42269U;
		}

		// Token: 0x0600EEBB RID: 61115 RVA: 0x0034A31F File Offset: 0x0034851F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildPartySummonSpiritArg>(stream, this.oArg);
		}

		// Token: 0x0600EEBC RID: 61116 RVA: 0x0034A32F File Offset: 0x0034852F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildPartySummonSpiritRes>(stream);
		}

		// Token: 0x0600EEBD RID: 61117 RVA: 0x0034A33E File Offset: 0x0034853E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildPartySummonSpirit.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EEBE RID: 61118 RVA: 0x0034A35A File Offset: 0x0034855A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildPartySummonSpirit.OnTimeout(this.oArg);
		}

		// Token: 0x04006623 RID: 26147
		public GuildPartySummonSpiritArg oArg = new GuildPartySummonSpiritArg();

		// Token: 0x04006624 RID: 26148
		public GuildPartySummonSpiritRes oRes = null;
	}
}
