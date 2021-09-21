using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013AA RID: 5034
	internal class RpcC2G_QueryQQVipInfo : Rpc
	{
		// Token: 0x0600E3A3 RID: 58275 RVA: 0x0033A998 File Offset: 0x00338B98
		public override uint GetRpcType()
		{
			return 43943U;
		}

		// Token: 0x0600E3A4 RID: 58276 RVA: 0x0033A9AF File Offset: 0x00338BAF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryQQVipInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E3A5 RID: 58277 RVA: 0x0033A9BF File Offset: 0x00338BBF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryQQVipInfoRes>(stream);
		}

		// Token: 0x0600E3A6 RID: 58278 RVA: 0x0033A9CE File Offset: 0x00338BCE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryQQVipInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E3A7 RID: 58279 RVA: 0x0033A9EA File Offset: 0x00338BEA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryQQVipInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063F8 RID: 25592
		public QueryQQVipInfoArg oArg = new QueryQQVipInfoArg();

		// Token: 0x040063F9 RID: 25593
		public QueryQQVipInfoRes oRes = new QueryQQVipInfoRes();
	}
}
