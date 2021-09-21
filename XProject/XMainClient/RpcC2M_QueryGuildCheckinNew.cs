using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012AB RID: 4779
	internal class RpcC2M_QueryGuildCheckinNew : Rpc
	{
		// Token: 0x0600DF8B RID: 57227 RVA: 0x00334C08 File Offset: 0x00332E08
		public override uint GetRpcType()
		{
			return 56433U;
		}

		// Token: 0x0600DF8C RID: 57228 RVA: 0x00334C1F File Offset: 0x00332E1F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryGuildCheckinArg>(stream, this.oArg);
		}

		// Token: 0x0600DF8D RID: 57229 RVA: 0x00334C2F File Offset: 0x00332E2F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryGuildCheckinRes>(stream);
		}

		// Token: 0x0600DF8E RID: 57230 RVA: 0x00334C3E File Offset: 0x00332E3E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_QueryGuildCheckinNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF8F RID: 57231 RVA: 0x00334C5A File Offset: 0x00332E5A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_QueryGuildCheckinNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400632D RID: 25389
		public QueryGuildCheckinArg oArg = new QueryGuildCheckinArg();

		// Token: 0x0400632E RID: 25390
		public QueryGuildCheckinRes oRes = null;
	}
}
