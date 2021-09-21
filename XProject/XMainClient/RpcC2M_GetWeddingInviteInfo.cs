using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001594 RID: 5524
	internal class RpcC2M_GetWeddingInviteInfo : Rpc
	{
		// Token: 0x0600EB73 RID: 60275 RVA: 0x00345C88 File Offset: 0x00343E88
		public override uint GetRpcType()
		{
			return 2804U;
		}

		// Token: 0x0600EB74 RID: 60276 RVA: 0x00345C9F File Offset: 0x00343E9F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWeddingInviteInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600EB75 RID: 60277 RVA: 0x00345CAF File Offset: 0x00343EAF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWeddingInviteInfoRes>(stream);
		}

		// Token: 0x0600EB76 RID: 60278 RVA: 0x00345CBE File Offset: 0x00343EBE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetWeddingInviteInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB77 RID: 60279 RVA: 0x00345CDA File Offset: 0x00343EDA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetWeddingInviteInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400657C RID: 25980
		public GetWeddingInviteInfoArg oArg = new GetWeddingInviteInfoArg();

		// Token: 0x0400657D RID: 25981
		public GetWeddingInviteInfoRes oRes = null;
	}
}
