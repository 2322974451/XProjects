using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001158 RID: 4440
	internal class RpcC2G_GetWatchInfoByID : Rpc
	{
		// Token: 0x0600DA2B RID: 55851 RVA: 0x0032CC48 File Offset: 0x0032AE48
		public override uint GetRpcType()
		{
			return 45635U;
		}

		// Token: 0x0600DA2C RID: 55852 RVA: 0x0032CC5F File Offset: 0x0032AE5F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWatchInfoByIDArg>(stream, this.oArg);
		}

		// Token: 0x0600DA2D RID: 55853 RVA: 0x0032CC6F File Offset: 0x0032AE6F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWatchInfoByIDRes>(stream);
		}

		// Token: 0x0600DA2E RID: 55854 RVA: 0x0032CC7E File Offset: 0x0032AE7E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetWatchInfoByID.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA2F RID: 55855 RVA: 0x0032CC9A File Offset: 0x0032AE9A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetWatchInfoByID.OnTimeout(this.oArg);
		}

		// Token: 0x04006229 RID: 25129
		public GetWatchInfoByIDArg oArg = new GetWatchInfoByIDArg();

		// Token: 0x0400622A RID: 25130
		public GetWatchInfoByIDRes oRes = new GetWatchInfoByIDRes();
	}
}
