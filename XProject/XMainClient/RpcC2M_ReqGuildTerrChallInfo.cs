using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001410 RID: 5136
	internal class RpcC2M_ReqGuildTerrChallInfo : Rpc
	{
		// Token: 0x0600E546 RID: 58694 RVA: 0x0033CB7C File Offset: 0x0033AD7C
		public override uint GetRpcType()
		{
			return 9791U;
		}

		// Token: 0x0600E547 RID: 58695 RVA: 0x0033CB93 File Offset: 0x0033AD93
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrChallInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E548 RID: 58696 RVA: 0x0033CBA3 File Offset: 0x0033ADA3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrChallInfoRes>(stream);
		}

		// Token: 0x0600E549 RID: 58697 RVA: 0x0033CBB2 File Offset: 0x0033ADB2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrChallInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E54A RID: 58698 RVA: 0x0033CBCE File Offset: 0x0033ADCE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrChallInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006449 RID: 25673
		public ReqGuildTerrChallInfoArg oArg = new ReqGuildTerrChallInfoArg();

		// Token: 0x0400644A RID: 25674
		public ReqGuildTerrChallInfoRes oRes = null;
	}
}
