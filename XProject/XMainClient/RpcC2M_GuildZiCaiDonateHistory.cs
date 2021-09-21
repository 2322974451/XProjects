using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001694 RID: 5780
	internal class RpcC2M_GuildZiCaiDonateHistory : Rpc
	{
		// Token: 0x0600EFA7 RID: 61351 RVA: 0x0034BB18 File Offset: 0x00349D18
		public override uint GetRpcType()
		{
			return 22824U;
		}

		// Token: 0x0600EFA8 RID: 61352 RVA: 0x0034BB2F File Offset: 0x00349D2F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildZiCaiDonateHistory_C2M>(stream, this.oArg);
		}

		// Token: 0x0600EFA9 RID: 61353 RVA: 0x0034BB3F File Offset: 0x00349D3F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildZiCaiDonateHistory_M2C>(stream);
		}

		// Token: 0x0600EFAA RID: 61354 RVA: 0x0034BB4E File Offset: 0x00349D4E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildZiCaiDonateHistory.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EFAB RID: 61355 RVA: 0x0034BB6A File Offset: 0x00349D6A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildZiCaiDonateHistory.OnTimeout(this.oArg);
		}

		// Token: 0x04006659 RID: 26201
		public GuildZiCaiDonateHistory_C2M oArg = new GuildZiCaiDonateHistory_C2M();

		// Token: 0x0400665A RID: 26202
		public GuildZiCaiDonateHistory_M2C oRes = null;
	}
}
