using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001051 RID: 4177
	internal class RpcC2G_QueryShopItem : Rpc
	{
		// Token: 0x0600D5FB RID: 54779 RVA: 0x003255D4 File Offset: 0x003237D4
		public override uint GetRpcType()
		{
			return 18079U;
		}

		// Token: 0x0600D5FC RID: 54780 RVA: 0x003255EB File Offset: 0x003237EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryShopItemArg>(stream, this.oArg);
		}

		// Token: 0x0600D5FD RID: 54781 RVA: 0x003255FB File Offset: 0x003237FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryShopItemRes>(stream);
		}

		// Token: 0x0600D5FE RID: 54782 RVA: 0x0032560A File Offset: 0x0032380A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryShopItem.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D5FF RID: 54783 RVA: 0x00325626 File Offset: 0x00323826
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryShopItem.OnTimeout(this.oArg);
		}

		// Token: 0x0400615C RID: 24924
		public QueryShopItemArg oArg = new QueryShopItemArg();

		// Token: 0x0400615D RID: 24925
		public QueryShopItemRes oRes = new QueryShopItemRes();
	}
}
