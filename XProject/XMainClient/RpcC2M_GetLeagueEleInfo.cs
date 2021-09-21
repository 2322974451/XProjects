using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001495 RID: 5269
	internal class RpcC2M_GetLeagueEleInfo : Rpc
	{
		// Token: 0x0600E75C RID: 59228 RVA: 0x0033FE90 File Offset: 0x0033E090
		public override uint GetRpcType()
		{
			return 40678U;
		}

		// Token: 0x0600E75D RID: 59229 RVA: 0x0033FEA7 File Offset: 0x0033E0A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueEleInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E75E RID: 59230 RVA: 0x0033FEB7 File Offset: 0x0033E0B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueEleInfoRes>(stream);
		}

		// Token: 0x0600E75F RID: 59231 RVA: 0x0033FEC6 File Offset: 0x0033E0C6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueEleInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E760 RID: 59232 RVA: 0x0033FEE2 File Offset: 0x0033E0E2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueEleInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040064AB RID: 25771
		public GetLeagueEleInfoArg oArg = new GetLeagueEleInfoArg();

		// Token: 0x040064AC RID: 25772
		public GetLeagueEleInfoRes oRes = null;
	}
}
