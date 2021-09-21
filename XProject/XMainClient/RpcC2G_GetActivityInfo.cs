using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011D8 RID: 4568
	internal class RpcC2G_GetActivityInfo : Rpc
	{
		// Token: 0x0600DC28 RID: 56360 RVA: 0x0032FEF4 File Offset: 0x0032E0F4
		public override uint GetRpcType()
		{
			return 43911U;
		}

		// Token: 0x0600DC29 RID: 56361 RVA: 0x0032FF0B File Offset: 0x0032E10B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetActivityInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600DC2A RID: 56362 RVA: 0x0032FF1B File Offset: 0x0032E11B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetActivityInfoRes>(stream);
		}

		// Token: 0x0600DC2B RID: 56363 RVA: 0x0032FF2A File Offset: 0x0032E12A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetActivityInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DC2C RID: 56364 RVA: 0x0032FF46 File Offset: 0x0032E146
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetActivityInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006285 RID: 25221
		public GetActivityInfoArg oArg = new GetActivityInfoArg();

		// Token: 0x04006286 RID: 25222
		public GetActivityInfoRes oRes = new GetActivityInfoRes();
	}
}
