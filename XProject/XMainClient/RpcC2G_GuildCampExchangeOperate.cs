using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014F8 RID: 5368
	internal class RpcC2G_GuildCampExchangeOperate : Rpc
	{
		// Token: 0x0600E8F4 RID: 59636 RVA: 0x00342008 File Offset: 0x00340208
		public override uint GetRpcType()
		{
			return 31811U;
		}

		// Token: 0x0600E8F5 RID: 59637 RVA: 0x0034201F File Offset: 0x0034021F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampExchangeOperateArg>(stream, this.oArg);
		}

		// Token: 0x0600E8F6 RID: 59638 RVA: 0x0034202F File Offset: 0x0034022F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCampExchangeOperateRes>(stream);
		}

		// Token: 0x0600E8F7 RID: 59639 RVA: 0x0034203E File Offset: 0x0034023E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildCampExchangeOperate.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E8F8 RID: 59640 RVA: 0x0034205A File Offset: 0x0034025A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildCampExchangeOperate.OnTimeout(this.oArg);
		}

		// Token: 0x040064F9 RID: 25849
		public GuildCampExchangeOperateArg oArg = new GuildCampExchangeOperateArg();

		// Token: 0x040064FA RID: 25850
		public GuildCampExchangeOperateRes oRes = null;
	}
}
