using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001462 RID: 5218
	internal class RpcC2M_GetLeagueTeamInfo : Rpc
	{
		// Token: 0x0600E68E RID: 59022 RVA: 0x0033EB4C File Offset: 0x0033CD4C
		public override uint GetRpcType()
		{
			return 12488U;
		}

		// Token: 0x0600E68F RID: 59023 RVA: 0x0033EB63 File Offset: 0x0033CD63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLeagueTeamInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E690 RID: 59024 RVA: 0x0033EB73 File Offset: 0x0033CD73
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLeagueTeamInfoRes>(stream);
		}

		// Token: 0x0600E691 RID: 59025 RVA: 0x0033EB82 File Offset: 0x0033CD82
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetLeagueTeamInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E692 RID: 59026 RVA: 0x0033EB9E File Offset: 0x0033CD9E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetLeagueTeamInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006484 RID: 25732
		public GetLeagueTeamInfoArg oArg = new GetLeagueTeamInfoArg();

		// Token: 0x04006485 RID: 25733
		public GetLeagueTeamInfoRes oRes = null;
	}
}
