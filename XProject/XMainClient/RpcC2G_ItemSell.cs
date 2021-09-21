using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001491 RID: 5265
	internal class RpcC2G_ItemSell : Rpc
	{
		// Token: 0x0600E74A RID: 59210 RVA: 0x0033FCA8 File Offset: 0x0033DEA8
		public override uint GetRpcType()
		{
			return 34826U;
		}

		// Token: 0x0600E74B RID: 59211 RVA: 0x0033FCBF File Offset: 0x0033DEBF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemSellArg>(stream, this.oArg);
		}

		// Token: 0x0600E74C RID: 59212 RVA: 0x0033FCCF File Offset: 0x0033DECF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemSellRes>(stream);
		}

		// Token: 0x0600E74D RID: 59213 RVA: 0x0033FCDE File Offset: 0x0033DEDE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemSell.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E74E RID: 59214 RVA: 0x0033FCFA File Offset: 0x0033DEFA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemSell.OnTimeout(this.oArg);
		}

		// Token: 0x040064A7 RID: 25767
		public ItemSellArg oArg = new ItemSellArg();

		// Token: 0x040064A8 RID: 25768
		public ItemSellRes oRes = null;
	}
}
