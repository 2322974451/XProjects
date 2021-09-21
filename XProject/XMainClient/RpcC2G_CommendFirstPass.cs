using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001217 RID: 4631
	internal class RpcC2G_CommendFirstPass : Rpc
	{
		// Token: 0x0600DD25 RID: 56613 RVA: 0x003313F8 File Offset: 0x0032F5F8
		public override uint GetRpcType()
		{
			return 8467U;
		}

		// Token: 0x0600DD26 RID: 56614 RVA: 0x0033140F File Offset: 0x0032F60F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CommendFirstPassArg>(stream, this.oArg);
		}

		// Token: 0x0600DD27 RID: 56615 RVA: 0x0033141F File Offset: 0x0032F61F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CommendFirstPassRes>(stream);
		}

		// Token: 0x0600DD28 RID: 56616 RVA: 0x0033142E File Offset: 0x0032F62E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_CommendFirstPass.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD29 RID: 56617 RVA: 0x0033144A File Offset: 0x0032F64A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_CommendFirstPass.OnTimeout(this.oArg);
		}

		// Token: 0x040062B4 RID: 25268
		public CommendFirstPassArg oArg = new CommendFirstPassArg();

		// Token: 0x040062B5 RID: 25269
		public CommendFirstPassRes oRes = new CommendFirstPassRes();
	}
}
