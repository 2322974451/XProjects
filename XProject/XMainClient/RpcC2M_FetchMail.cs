using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B4F RID: 2895
	internal class RpcC2M_FetchMail : Rpc
	{
		// Token: 0x0600A8B9 RID: 43193 RVA: 0x001E0F7C File Offset: 0x001DF17C
		public override uint GetRpcType()
		{
			return 12373U;
		}

		// Token: 0x0600A8BA RID: 43194 RVA: 0x001E0F93 File Offset: 0x001DF193
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchMailArg>(stream, this.oArg);
		}

		// Token: 0x0600A8BB RID: 43195 RVA: 0x001E0FA3 File Offset: 0x001DF1A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchMailRes>(stream);
		}

		// Token: 0x0600A8BC RID: 43196 RVA: 0x001E0FB2 File Offset: 0x001DF1B2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchMail.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8BD RID: 43197 RVA: 0x001E0FCE File Offset: 0x001DF1CE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchMail.OnTimeout(this.oArg);
		}

		// Token: 0x04003E82 RID: 16002
		public FetchMailArg oArg = new FetchMailArg();

		// Token: 0x04003E83 RID: 16003
		public FetchMailRes oRes = null;
	}
}
