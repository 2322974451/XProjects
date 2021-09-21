using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001678 RID: 5752
	internal class RpcC2G_GetMyRiftInfo : Rpc
	{
		// Token: 0x0600EF2D RID: 61229 RVA: 0x0034ADA0 File Offset: 0x00348FA0
		public override uint GetRpcType()
		{
			return 31519U;
		}

		// Token: 0x0600EF2E RID: 61230 RVA: 0x0034ADB7 File Offset: 0x00348FB7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyRiftInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600EF2F RID: 61231 RVA: 0x0034ADC7 File Offset: 0x00348FC7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyRiftInfoRes>(stream);
		}

		// Token: 0x0600EF30 RID: 61232 RVA: 0x0034ADD6 File Offset: 0x00348FD6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetMyRiftInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF31 RID: 61233 RVA: 0x0034ADF2 File Offset: 0x00348FF2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetMyRiftInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400663F RID: 26175
		public GetMyRiftInfoArg oArg = new GetMyRiftInfoArg();

		// Token: 0x04006640 RID: 26176
		public GetMyRiftInfoRes oRes = null;
	}
}
