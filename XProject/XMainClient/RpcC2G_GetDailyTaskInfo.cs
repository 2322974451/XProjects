using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200138C RID: 5004
	internal class RpcC2G_GetDailyTaskInfo : Rpc
	{
		// Token: 0x0600E325 RID: 58149 RVA: 0x00339FB4 File Offset: 0x003381B4
		public override uint GetRpcType()
		{
			return 52480U;
		}

		// Token: 0x0600E326 RID: 58150 RVA: 0x00339FCB File Offset: 0x003381CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDailyTaskInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E327 RID: 58151 RVA: 0x00339FDB File Offset: 0x003381DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDailyTaskInfoRes>(stream);
		}

		// Token: 0x0600E328 RID: 58152 RVA: 0x00339FEA File Offset: 0x003381EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDailyTaskInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E329 RID: 58153 RVA: 0x0033A006 File Offset: 0x00338206
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDailyTaskInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063DF RID: 25567
		public GetDailyTaskInfoArg oArg = new GetDailyTaskInfoArg();

		// Token: 0x040063E0 RID: 25568
		public GetDailyTaskInfoRes oRes = new GetDailyTaskInfoRes();
	}
}
