using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013E8 RID: 5096
	internal class RpcC2M_GetPartnerLiveness : Rpc
	{
		// Token: 0x0600E4A2 RID: 58530 RVA: 0x0033BF44 File Offset: 0x0033A144
		public override uint GetRpcType()
		{
			return 18784U;
		}

		// Token: 0x0600E4A3 RID: 58531 RVA: 0x0033BF5B File Offset: 0x0033A15B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerLivenessArg>(stream, this.oArg);
		}

		// Token: 0x0600E4A4 RID: 58532 RVA: 0x0033BF6B File Offset: 0x0033A16B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerLivenessRes>(stream);
		}

		// Token: 0x0600E4A5 RID: 58533 RVA: 0x0033BF7A File Offset: 0x0033A17A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerLiveness.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4A6 RID: 58534 RVA: 0x0033BF96 File Offset: 0x0033A196
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerLiveness.OnTimeout(this.oArg);
		}

		// Token: 0x04006429 RID: 25641
		public GetPartnerLivenessArg oArg = new GetPartnerLivenessArg();

		// Token: 0x0400642A RID: 25642
		public GetPartnerLivenessRes oRes = null;
	}
}
