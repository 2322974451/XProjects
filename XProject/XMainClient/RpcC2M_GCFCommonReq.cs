using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001402 RID: 5122
	internal class RpcC2M_GCFCommonReq : Rpc
	{
		// Token: 0x0600E50B RID: 58635 RVA: 0x0033C708 File Offset: 0x0033A908
		public override uint GetRpcType()
		{
			return 28945U;
		}

		// Token: 0x0600E50C RID: 58636 RVA: 0x0033C71F File Offset: 0x0033A91F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GCFCommonArg>(stream, this.oArg);
		}

		// Token: 0x0600E50D RID: 58637 RVA: 0x0033C72F File Offset: 0x0033A92F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GCFCommonRes>(stream);
		}

		// Token: 0x0600E50E RID: 58638 RVA: 0x0033C73E File Offset: 0x0033A93E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GCFCommonReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E50F RID: 58639 RVA: 0x0033C75A File Offset: 0x0033A95A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GCFCommonReq.OnTimeout(this.oArg);
		}

		// Token: 0x0400643D RID: 25661
		public GCFCommonArg oArg = new GCFCommonArg();

		// Token: 0x0400643E RID: 25662
		public GCFCommonRes oRes = null;
	}
}
