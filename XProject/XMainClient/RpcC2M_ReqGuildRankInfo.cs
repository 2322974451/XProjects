using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200130B RID: 4875
	internal class RpcC2M_ReqGuildRankInfo : Rpc
	{
		// Token: 0x0600E116 RID: 57622 RVA: 0x0033702C File Offset: 0x0033522C
		public override uint GetRpcType()
		{
			return 48521U;
		}

		// Token: 0x0600E117 RID: 57623 RVA: 0x00337043 File Offset: 0x00335243
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildRankInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E118 RID: 57624 RVA: 0x00337053 File Offset: 0x00335253
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildRankInfoRes>(stream);
		}

		// Token: 0x0600E119 RID: 57625 RVA: 0x00337062 File Offset: 0x00335262
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildRankInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E11A RID: 57626 RVA: 0x0033707E File Offset: 0x0033527E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildRankInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006379 RID: 25465
		public ReqGuildRankInfoArg oArg = new ReqGuildRankInfoArg();

		// Token: 0x0400637A RID: 25466
		public ReqGuildRankInfoRes oRes = null;
	}
}
