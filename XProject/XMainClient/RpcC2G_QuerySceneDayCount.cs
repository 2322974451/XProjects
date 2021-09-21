using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200102B RID: 4139
	internal class RpcC2G_QuerySceneDayCount : Rpc
	{
		// Token: 0x0600D557 RID: 54615 RVA: 0x00323E00 File Offset: 0x00322000
		public override uint GetRpcType()
		{
			return 1676U;
		}

		// Token: 0x0600D558 RID: 54616 RVA: 0x00323E17 File Offset: 0x00322017
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QuerySceneDayCountArg>(stream, this.oArg);
		}

		// Token: 0x0600D559 RID: 54617 RVA: 0x00323E27 File Offset: 0x00322027
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QuerySceneDayCountRes>(stream);
		}

		// Token: 0x0600D55A RID: 54618 RVA: 0x00323E36 File Offset: 0x00322036
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QuerySceneDayCount.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D55B RID: 54619 RVA: 0x00323E52 File Offset: 0x00322052
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QuerySceneDayCount.OnTimeout(this.oArg);
		}

		// Token: 0x0400611D RID: 24861
		public QuerySceneDayCountArg oArg = new QuerySceneDayCountArg();

		// Token: 0x0400611E RID: 24862
		public QuerySceneDayCountRes oRes = new QuerySceneDayCountRes();
	}
}
