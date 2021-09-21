using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200168E RID: 5774
	internal class RpcC2M_GuildHallUpdateBuff : Rpc
	{
		// Token: 0x0600EF8C RID: 61324 RVA: 0x0034B774 File Offset: 0x00349974
		public override uint GetRpcType()
		{
			return 24892U;
		}

		// Token: 0x0600EF8D RID: 61325 RVA: 0x0034B78B File Offset: 0x0034998B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHallUpdateBuff_C2M>(stream, this.oArg);
		}

		// Token: 0x0600EF8E RID: 61326 RVA: 0x0034B79B File Offset: 0x0034999B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildHallUpdateBuff_M2C>(stream);
		}

		// Token: 0x0600EF8F RID: 61327 RVA: 0x0034B7AA File Offset: 0x003499AA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildHallUpdateBuff.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF90 RID: 61328 RVA: 0x0034B7C6 File Offset: 0x003499C6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildHallUpdateBuff.OnTimeout(this.oArg);
		}

		// Token: 0x04006653 RID: 26195
		public GuildHallUpdateBuff_C2M oArg = new GuildHallUpdateBuff_C2M();

		// Token: 0x04006654 RID: 26196
		public GuildHallUpdateBuff_M2C oRes = null;
	}
}
