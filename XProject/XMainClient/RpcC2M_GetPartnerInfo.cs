using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013E0 RID: 5088
	internal class RpcC2M_GetPartnerInfo : Rpc
	{
		// Token: 0x0600E47D RID: 58493 RVA: 0x0033BCFC File Offset: 0x00339EFC
		public override uint GetRpcType()
		{
			return 61123U;
		}

		// Token: 0x0600E47E RID: 58494 RVA: 0x0033BD13 File Offset: 0x00339F13
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetPartnerInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E47F RID: 58495 RVA: 0x0033BD23 File Offset: 0x00339F23
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetPartnerInfoRes>(stream);
		}

		// Token: 0x0600E480 RID: 58496 RVA: 0x0033BD32 File Offset: 0x00339F32
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetPartnerInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E481 RID: 58497 RVA: 0x0033BD4E File Offset: 0x00339F4E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetPartnerInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006421 RID: 25633
		public GetPartnerInfoArg oArg = new GetPartnerInfoArg();

		// Token: 0x04006422 RID: 25634
		public GetPartnerInfoRes oRes = null;
	}
}
