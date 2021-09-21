using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001692 RID: 5778
	internal class RpcC2M_GuildZiCaiDonate : Rpc
	{
		// Token: 0x0600EF9E RID: 61342 RVA: 0x0034B9C8 File Offset: 0x00349BC8
		public override uint GetRpcType()
		{
			return 1738U;
		}

		// Token: 0x0600EF9F RID: 61343 RVA: 0x0034B9DF File Offset: 0x00349BDF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildZiCaiDonate_C2M>(stream, this.oArg);
		}

		// Token: 0x0600EFA0 RID: 61344 RVA: 0x0034B9EF File Offset: 0x00349BEF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildZiCaiDonate_M2C>(stream);
		}

		// Token: 0x0600EFA1 RID: 61345 RVA: 0x0034B9FE File Offset: 0x00349BFE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildZiCaiDonate.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EFA2 RID: 61346 RVA: 0x0034BA1A File Offset: 0x00349C1A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildZiCaiDonate.OnTimeout(this.oArg);
		}

		// Token: 0x04006657 RID: 26199
		public GuildZiCaiDonate_C2M oArg = new GuildZiCaiDonate_C2M();

		// Token: 0x04006658 RID: 26200
		public GuildZiCaiDonate_M2C oRes = null;
	}
}
