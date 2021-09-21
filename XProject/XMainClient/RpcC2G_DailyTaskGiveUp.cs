using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013AC RID: 5036
	internal class RpcC2G_DailyTaskGiveUp : Rpc
	{
		// Token: 0x0600E3AC RID: 58284 RVA: 0x0033AA40 File Offset: 0x00338C40
		public override uint GetRpcType()
		{
			return 10546U;
		}

		// Token: 0x0600E3AD RID: 58285 RVA: 0x0033AA57 File Offset: 0x00338C57
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DailyTaskGiveUpArg>(stream, this.oArg);
		}

		// Token: 0x0600E3AE RID: 58286 RVA: 0x0033AA67 File Offset: 0x00338C67
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DailyTaskGiveUpRes>(stream);
		}

		// Token: 0x0600E3AF RID: 58287 RVA: 0x0033AA76 File Offset: 0x00338C76
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DailyTaskGiveUp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E3B0 RID: 58288 RVA: 0x0033AA92 File Offset: 0x00338C92
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DailyTaskGiveUp.OnTimeout(this.oArg);
		}

		// Token: 0x040063FA RID: 25594
		public DailyTaskGiveUpArg oArg = new DailyTaskGiveUpArg();

		// Token: 0x040063FB RID: 25595
		public DailyTaskGiveUpRes oRes = new DailyTaskGiveUpRes();
	}
}
