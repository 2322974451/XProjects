using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001592 RID: 5522
	internal class RpcC2M_HoldWedding : Rpc
	{
		// Token: 0x0600EB6A RID: 60266 RVA: 0x00345B9C File Offset: 0x00343D9C
		public override uint GetRpcType()
		{
			return 51875U;
		}

		// Token: 0x0600EB6B RID: 60267 RVA: 0x00345BB3 File Offset: 0x00343DB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HoldWeddingReq>(stream, this.oArg);
		}

		// Token: 0x0600EB6C RID: 60268 RVA: 0x00345BC3 File Offset: 0x00343DC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<HoldWeddingRes>(stream);
		}

		// Token: 0x0600EB6D RID: 60269 RVA: 0x00345BD2 File Offset: 0x00343DD2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_HoldWedding.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB6E RID: 60270 RVA: 0x00345BEE File Offset: 0x00343DEE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_HoldWedding.OnTimeout(this.oArg);
		}

		// Token: 0x0400657A RID: 25978
		public HoldWeddingReq oArg = new HoldWeddingReq();

		// Token: 0x0400657B RID: 25979
		public HoldWeddingRes oRes = null;
	}
}
