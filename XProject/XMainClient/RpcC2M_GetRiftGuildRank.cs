using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200167A RID: 5754
	internal class RpcC2M_GetRiftGuildRank : Rpc
	{
		// Token: 0x0600EF36 RID: 61238 RVA: 0x0034AEBC File Offset: 0x003490BC
		public override uint GetRpcType()
		{
			return 28195U;
		}

		// Token: 0x0600EF37 RID: 61239 RVA: 0x0034AED3 File Offset: 0x003490D3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetRiftGuildRankArg>(stream, this.oArg);
		}

		// Token: 0x0600EF38 RID: 61240 RVA: 0x0034AEE3 File Offset: 0x003490E3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetRiftGuildRankRes>(stream);
		}

		// Token: 0x0600EF39 RID: 61241 RVA: 0x0034AEF2 File Offset: 0x003490F2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetRiftGuildRank.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF3A RID: 61242 RVA: 0x0034AF0E File Offset: 0x0034910E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetRiftGuildRank.OnTimeout(this.oArg);
		}

		// Token: 0x04006641 RID: 26177
		public GetRiftGuildRankArg oArg = new GetRiftGuildRankArg();

		// Token: 0x04006642 RID: 26178
		public GetRiftGuildRankRes oRes = null;
	}
}
