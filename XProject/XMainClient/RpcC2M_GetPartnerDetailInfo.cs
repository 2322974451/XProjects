using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013E6 RID: 5094
	internal class RpcC2M_GetPartnerDetailInfo : Rpc
	{
		// Token: 0x0600E499 RID: 58521 RVA: 0x0033BEB8 File Offset: 0x0033A0B8
		public override uint GetRpcType()
		{
			return 31275U;
		}

		// Token: 0x0600E49A RID: 58522 RVA: 0x0033BECF File Offset: 0x0033A0CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerDetailInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E49B RID: 58523 RVA: 0x0033BEDF File Offset: 0x0033A0DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerDetailInfoRes>(stream);
		}

		// Token: 0x0600E49C RID: 58524 RVA: 0x0033BEEE File Offset: 0x0033A0EE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerDetailInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E49D RID: 58525 RVA: 0x0033BF0A File Offset: 0x0033A10A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerDetailInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006427 RID: 25639
		public GetPartnerDetailInfoArg oArg = new GetPartnerDetailInfoArg();

		// Token: 0x04006428 RID: 25640
		public GetPartnerDetailInfoRes oRes = null;
	}
}
