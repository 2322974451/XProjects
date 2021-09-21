using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200107D RID: 4221
	internal class RpcC2G_QueryGuildCard : Rpc
	{
		// Token: 0x0600D6AF RID: 54959 RVA: 0x003267C4 File Offset: 0x003249C4
		public override uint GetRpcType()
		{
			return 55524U;
		}

		// Token: 0x0600D6B0 RID: 54960 RVA: 0x003267DB File Offset: 0x003249DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryGuildCardArg>(stream, this.oArg);
		}

		// Token: 0x0600D6B1 RID: 54961 RVA: 0x003267EB File Offset: 0x003249EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryGuildCardRes>(stream);
		}

		// Token: 0x0600D6B2 RID: 54962 RVA: 0x003267FA File Offset: 0x003249FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryGuildCard.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6B3 RID: 54963 RVA: 0x00326816 File Offset: 0x00324A16
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryGuildCard.OnTimeout(this.oArg);
		}

		// Token: 0x04006184 RID: 24964
		public QueryGuildCardArg oArg = new QueryGuildCardArg();

		// Token: 0x04006185 RID: 24965
		public QueryGuildCardRes oRes = new QueryGuildCardRes();
	}
}
