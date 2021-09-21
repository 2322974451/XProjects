using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001615 RID: 5653
	internal class RpcC2M_GetDailyTaskRefreshRecord : Rpc
	{
		// Token: 0x0600ED8C RID: 60812 RVA: 0x00348860 File Offset: 0x00346A60
		public override uint GetRpcType()
		{
			return 7202U;
		}

		// Token: 0x0600ED8D RID: 60813 RVA: 0x00348877 File Offset: 0x00346A77
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskRefreshRecordArg>(stream, this.oArg);
		}

		// Token: 0x0600ED8E RID: 60814 RVA: 0x00348887 File Offset: 0x00346A87
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskRefreshRecordRes>(stream);
		}

		// Token: 0x0600ED8F RID: 60815 RVA: 0x00348896 File Offset: 0x00346A96
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDailyTaskRefreshRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED90 RID: 60816 RVA: 0x003488B2 File Offset: 0x00346AB2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDailyTaskRefreshRecord.OnTimeout(this.oArg);
		}

		// Token: 0x040065E4 RID: 26084
		public GetDailyTaskRefreshRecordArg oArg = new GetDailyTaskRefreshRecordArg();

		// Token: 0x040065E5 RID: 26085
		public GetDailyTaskRefreshRecordRes oRes = null;
	}
}
