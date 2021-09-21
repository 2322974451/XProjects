using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200106A RID: 4202
	internal class RpcC2G_QueryOpenGameActivityTime : Rpc
	{
		// Token: 0x0600D65F RID: 54879 RVA: 0x00325FD0 File Offset: 0x003241D0
		public override uint GetRpcType()
		{
			return 24079U;
		}

		// Token: 0x0600D660 RID: 54880 RVA: 0x00325FE7 File Offset: 0x003241E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryOpenGameArg>(stream, this.oArg);
		}

		// Token: 0x0600D661 RID: 54881 RVA: 0x00325FF7 File Offset: 0x003241F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<QueryOpenGameRes>(stream);
		}

		// Token: 0x0600D662 RID: 54882 RVA: 0x00326006 File Offset: 0x00324206
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryOpenGameActivityTime.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D663 RID: 54883 RVA: 0x00326022 File Offset: 0x00324222
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryOpenGameActivityTime.OnTimeout(this.oArg);
		}

		// Token: 0x04006174 RID: 24948
		public QueryOpenGameArg oArg = new QueryOpenGameArg();

		// Token: 0x04006175 RID: 24949
		public QueryOpenGameRes oRes = new QueryOpenGameRes();
	}
}
