using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012D2 RID: 4818
	internal class RpcC2M_ReqGuildLadderInfo : Rpc
	{
		// Token: 0x0600E029 RID: 57385 RVA: 0x003359F0 File Offset: 0x00333BF0
		public override uint GetRpcType()
		{
			return 44006U;
		}

		// Token: 0x0600E02A RID: 57386 RVA: 0x00335A07 File Offset: 0x00333C07
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildLadderInfoAgr>(stream, this.oArg);
		}

		// Token: 0x0600E02B RID: 57387 RVA: 0x00335A17 File Offset: 0x00333C17
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildLadderInfoRes>(stream);
		}

		// Token: 0x0600E02C RID: 57388 RVA: 0x00335A26 File Offset: 0x00333C26
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildLadderInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E02D RID: 57389 RVA: 0x00335A42 File Offset: 0x00333C42
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildLadderInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400634B RID: 25419
		public ReqGuildLadderInfoAgr oArg = new ReqGuildLadderInfoAgr();

		// Token: 0x0400634C RID: 25420
		public ReqGuildLadderInfoRes oRes = null;
	}
}
