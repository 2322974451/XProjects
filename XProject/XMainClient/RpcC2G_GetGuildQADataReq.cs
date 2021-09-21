using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001154 RID: 4436
	internal class RpcC2G_GetGuildQADataReq : Rpc
	{
		// Token: 0x0600DA19 RID: 55833 RVA: 0x0032CA6C File Offset: 0x0032AC6C
		public override uint GetRpcType()
		{
			return 35568U;
		}

		// Token: 0x0600DA1A RID: 55834 RVA: 0x0032CA83 File Offset: 0x0032AC83
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildQADataReq>(stream, this.oArg);
		}

		// Token: 0x0600DA1B RID: 55835 RVA: 0x0032CA93 File Offset: 0x0032AC93
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildQADataRes>(stream);
		}

		// Token: 0x0600DA1C RID: 55836 RVA: 0x0032CAA2 File Offset: 0x0032ACA2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildQADataReq.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA1D RID: 55837 RVA: 0x0032CABE File Offset: 0x0032ACBE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildQADataReq.OnTimeout(this.oArg);
		}

		// Token: 0x04006225 RID: 25125
		public GetGuildQADataReq oArg = new GetGuildQADataReq();

		// Token: 0x04006226 RID: 25126
		public GetGuildQADataRes oRes = new GetGuildQADataRes();
	}
}
