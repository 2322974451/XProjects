using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012D4 RID: 4820
	internal class RpcC2M_ReqGuildLadderRnakInfo : Rpc
	{
		// Token: 0x0600E032 RID: 57394 RVA: 0x00335AAC File Offset: 0x00333CAC
		public override uint GetRpcType()
		{
			return 39925U;
		}

		// Token: 0x0600E033 RID: 57395 RVA: 0x00335AC3 File Offset: 0x00333CC3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildLadderRnakInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E034 RID: 57396 RVA: 0x00335AD3 File Offset: 0x00333CD3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildLadderRnakInfoRes>(stream);
		}

		// Token: 0x0600E035 RID: 57397 RVA: 0x00335AE2 File Offset: 0x00333CE2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildLadderRnakInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E036 RID: 57398 RVA: 0x00335AFE File Offset: 0x00333CFE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildLadderRnakInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400634D RID: 25421
		public ReqGuildLadderRnakInfoArg oArg = new ReqGuildLadderRnakInfoArg();

		// Token: 0x0400634E RID: 25422
		public ReqGuildLadderRnakInfoRes oRes = null;
	}
}
