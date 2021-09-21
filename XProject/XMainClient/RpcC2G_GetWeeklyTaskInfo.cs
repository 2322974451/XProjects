using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015F5 RID: 5621
	internal class RpcC2G_GetWeeklyTaskInfo : Rpc
	{
		// Token: 0x0600ED00 RID: 60672 RVA: 0x00347CA4 File Offset: 0x00345EA4
		public override uint GetRpcType()
		{
			return 44747U;
		}

		// Token: 0x0600ED01 RID: 60673 RVA: 0x00347CBB File Offset: 0x00345EBB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWeeklyTaskInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600ED02 RID: 60674 RVA: 0x00347CCB File Offset: 0x00345ECB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWeeklyTaskInfoRes>(stream);
		}

		// Token: 0x0600ED03 RID: 60675 RVA: 0x00347CDA File Offset: 0x00345EDA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetWeeklyTaskInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600ED04 RID: 60676 RVA: 0x00347CF6 File Offset: 0x00345EF6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetWeeklyTaskInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040065C6 RID: 26054
		public GetWeeklyTaskInfoArg oArg = new GetWeeklyTaskInfoArg();

		// Token: 0x040065C7 RID: 26055
		public GetWeeklyTaskInfoRes oRes = null;
	}
}
