using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001466 RID: 5222
	internal class PtcM2C_NotifyLeagueTeamCreate : Protocol
	{
		// Token: 0x0600E69E RID: 59038 RVA: 0x0033ECB8 File Offset: 0x0033CEB8
		public override uint GetProtoType()
		{
			return 22343U;
		}

		// Token: 0x0600E69F RID: 59039 RVA: 0x0033ECCF File Offset: 0x0033CECF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyLeagueTeamCreate>(stream, this.Data);
		}

		// Token: 0x0600E6A0 RID: 59040 RVA: 0x0033ECDF File Offset: 0x0033CEDF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyLeagueTeamCreate>(stream);
		}

		// Token: 0x0600E6A1 RID: 59041 RVA: 0x0033ECEE File Offset: 0x0033CEEE
		public override void Process()
		{
			Process_PtcM2C_NotifyLeagueTeamCreate.Process(this);
		}

		// Token: 0x04006487 RID: 25735
		public NotifyLeagueTeamCreate Data = new NotifyLeagueTeamCreate();
	}
}
