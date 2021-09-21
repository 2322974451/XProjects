using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001682 RID: 5762
	internal class RpcC2M_GetCrossGvgData : Rpc
	{
		// Token: 0x0600EF58 RID: 61272 RVA: 0x0034B360 File Offset: 0x00349560
		public override uint GetRpcType()
		{
			return 47019U;
		}

		// Token: 0x0600EF59 RID: 61273 RVA: 0x0034B377 File Offset: 0x00349577
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetCrossGvgDataArg>(stream, this.oArg);
		}

		// Token: 0x0600EF5A RID: 61274 RVA: 0x0034B387 File Offset: 0x00349587
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetCrossGvgDataRes>(stream);
		}

		// Token: 0x0600EF5B RID: 61275 RVA: 0x0034B396 File Offset: 0x00349596
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetCrossGvgData.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF5C RID: 61276 RVA: 0x0034B3B2 File Offset: 0x003495B2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetCrossGvgData.OnTimeout(this.oArg);
		}

		// Token: 0x04006648 RID: 26184
		public GetCrossGvgDataArg oArg = new GetCrossGvgDataArg();

		// Token: 0x04006649 RID: 26185
		public GetCrossGvgDataRes oRes = null;
	}
}
