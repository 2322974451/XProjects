using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200148D RID: 5261
	internal class RpcC2G_GetHolidayStageInfo : Rpc
	{
		// Token: 0x0600E738 RID: 59192 RVA: 0x0033FB1C File Offset: 0x0033DD1C
		public override uint GetRpcType()
		{
			return 31093U;
		}

		// Token: 0x0600E739 RID: 59193 RVA: 0x0033FB33 File Offset: 0x0033DD33
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHolidayStageInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E73A RID: 59194 RVA: 0x0033FB43 File Offset: 0x0033DD43
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHolidayStageInfoRes>(stream);
		}

		// Token: 0x0600E73B RID: 59195 RVA: 0x0033FB52 File Offset: 0x0033DD52
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHolidayStageInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E73C RID: 59196 RVA: 0x0033FB6E File Offset: 0x0033DD6E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHolidayStageInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064A3 RID: 25763
		public GetHolidayStageInfoArg oArg = new GetHolidayStageInfoArg();

		// Token: 0x040064A4 RID: 25764
		public GetHolidayStageInfoRes oRes = null;
	}
}
