using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001562 RID: 5474
	internal class RpcC2M_QueryBigMeleeRank : Rpc
	{
		// Token: 0x0600EA9E RID: 60062 RVA: 0x00344850 File Offset: 0x00342A50
		public override uint GetRpcType()
		{
			return 33332U;
		}

		// Token: 0x0600EA9F RID: 60063 RVA: 0x00344867 File Offset: 0x00342A67
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryMayhemRankArg>(stream, this.oArg);
		}

		// Token: 0x0600EAA0 RID: 60064 RVA: 0x00344877 File Offset: 0x00342A77
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryMayhemRankRes>(stream);
		}

		// Token: 0x0600EAA1 RID: 60065 RVA: 0x00344886 File Offset: 0x00342A86
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryBigMeleeRank.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAA2 RID: 60066 RVA: 0x003448A2 File Offset: 0x00342AA2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryBigMeleeRank.OnTimeout(this.oArg);
		}

		// Token: 0x04006550 RID: 25936
		public QueryMayhemRankArg oArg = new QueryMayhemRankArg();

		// Token: 0x04006551 RID: 25937
		public QueryMayhemRankRes oRes = null;
	}
}
