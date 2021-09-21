using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200139F RID: 5023
	internal class RpcC2M_ReqGuildInheritInfo : Rpc
	{
		// Token: 0x0600E377 RID: 58231 RVA: 0x0033A694 File Offset: 0x00338894
		public override uint GetRpcType()
		{
			return 7131U;
		}

		// Token: 0x0600E378 RID: 58232 RVA: 0x0033A6AB File Offset: 0x003388AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildInheritInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E379 RID: 58233 RVA: 0x0033A6BB File Offset: 0x003388BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildInheritInfoRes>(stream);
		}

		// Token: 0x0600E37A RID: 58234 RVA: 0x0033A6CA File Offset: 0x003388CA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildInheritInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E37B RID: 58235 RVA: 0x0033A6E6 File Offset: 0x003388E6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildInheritInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063F0 RID: 25584
		public ReqGuildInheritInfoArg oArg = new ReqGuildInheritInfoArg();

		// Token: 0x040063F1 RID: 25585
		public ReqGuildInheritInfoRes oRes = null;
	}
}
