using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200122F RID: 4655
	internal class RpcC2M_AuctionAllReq : Rpc
	{
		// Token: 0x0600DD89 RID: 56713 RVA: 0x00332098 File Offset: 0x00330298
		public override uint GetRpcType()
		{
			return 38875U;
		}

		// Token: 0x0600DD8A RID: 56714 RVA: 0x003320AF File Offset: 0x003302AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AuctionAllReqArg>(stream, this.oArg);
		}

		// Token: 0x0600DD8B RID: 56715 RVA: 0x003320BF File Offset: 0x003302BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AuctionAllReqRes>(stream);
		}

		// Token: 0x0600DD8C RID: 56716 RVA: 0x003320CE File Offset: 0x003302CE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AuctionAllReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD8D RID: 56717 RVA: 0x003320EA File Offset: 0x003302EA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AuctionAllReq.OnTimeout(this.oArg);
		}

		// Token: 0x040062C8 RID: 25288
		public AuctionAllReqArg oArg = new AuctionAllReqArg();

		// Token: 0x040062C9 RID: 25289
		public AuctionAllReqRes oRes = null;
	}
}
