using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001027 RID: 4135
	internal class RpcC2G_QueryLotteryCD : Rpc
	{
		// Token: 0x0600D545 RID: 54597 RVA: 0x00323AF4 File Offset: 0x00321CF4
		public override uint GetRpcType()
		{
			return 12242U;
		}

		// Token: 0x0600D546 RID: 54598 RVA: 0x00323B0B File Offset: 0x00321D0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryLotteryCDArg>(stream, this.oArg);
		}

		// Token: 0x0600D547 RID: 54599 RVA: 0x00323B1B File Offset: 0x00321D1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryLotteryCDRes>(stream);
		}

		// Token: 0x0600D548 RID: 54600 RVA: 0x00323B2A File Offset: 0x00321D2A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryLotteryCD.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D549 RID: 54601 RVA: 0x00323B46 File Offset: 0x00321D46
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryLotteryCD.OnTimeout(this.oArg);
		}

		// Token: 0x04006119 RID: 24857
		public QueryLotteryCDArg oArg = new QueryLotteryCDArg();

		// Token: 0x0400611A RID: 24858
		public QueryLotteryCDRes oRes = null;
	}
}
