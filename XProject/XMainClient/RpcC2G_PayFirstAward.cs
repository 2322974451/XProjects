using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001204 RID: 4612
	internal class RpcC2G_PayFirstAward : Rpc
	{
		// Token: 0x0600DCD5 RID: 56533 RVA: 0x00330E1C File Offset: 0x0032F01C
		public override uint GetRpcType()
		{
			return 46058U;
		}

		// Token: 0x0600DCD6 RID: 56534 RVA: 0x00330E33 File Offset: 0x0032F033
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayFirstAwardArg>(stream, this.oArg);
		}

		// Token: 0x0600DCD7 RID: 56535 RVA: 0x00330E43 File Offset: 0x0032F043
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PayFirstAwardRes>(stream);
		}

		// Token: 0x0600DCD8 RID: 56536 RVA: 0x00330E52 File Offset: 0x0032F052
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PayFirstAward.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DCD9 RID: 56537 RVA: 0x00330E6E File Offset: 0x0032F06E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PayFirstAward.OnTimeout(this.oArg);
		}

		// Token: 0x040062A4 RID: 25252
		public PayFirstAwardArg oArg = new PayFirstAwardArg();

		// Token: 0x040062A5 RID: 25253
		public PayFirstAwardRes oRes = new PayFirstAwardRes();
	}
}
