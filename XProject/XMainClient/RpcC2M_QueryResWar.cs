using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001352 RID: 4946
	internal class RpcC2M_QueryResWar : Rpc
	{
		// Token: 0x0600E23A RID: 57914 RVA: 0x00338B84 File Offset: 0x00336D84
		public override uint GetRpcType()
		{
			return 41509U;
		}

		// Token: 0x0600E23B RID: 57915 RVA: 0x00338B9B File Offset: 0x00336D9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryResWarArg>(stream, this.oArg);
		}

		// Token: 0x0600E23C RID: 57916 RVA: 0x00338BAB File Offset: 0x00336DAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryResWarRes>(stream);
		}

		// Token: 0x0600E23D RID: 57917 RVA: 0x00338BBA File Offset: 0x00336DBA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryResWar.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E23E RID: 57918 RVA: 0x00338BD6 File Offset: 0x00336DD6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryResWar.OnTimeout(this.oArg);
		}

		// Token: 0x040063B2 RID: 25522
		public QueryResWarArg oArg = new QueryResWarArg();

		// Token: 0x040063B3 RID: 25523
		public QueryResWarRes oRes = null;
	}
}
