using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200146E RID: 5230
	internal class PtcM2C_UpdateLeagueTeamState : Protocol
	{
		// Token: 0x0600E6BE RID: 59070 RVA: 0x0033EFA8 File Offset: 0x0033D1A8
		public override uint GetProtoType()
		{
			return 7643U;
		}

		// Token: 0x0600E6BF RID: 59071 RVA: 0x0033EFBF File Offset: 0x0033D1BF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateLeagueTeamState>(stream, this.Data);
		}

		// Token: 0x0600E6C0 RID: 59072 RVA: 0x0033EFCF File Offset: 0x0033D1CF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateLeagueTeamState>(stream);
		}

		// Token: 0x0600E6C1 RID: 59073 RVA: 0x0033EFDE File Offset: 0x0033D1DE
		public override void Process()
		{
			Process_PtcM2C_UpdateLeagueTeamState.Process(this);
		}

		// Token: 0x0400648D RID: 25741
		public UpdateLeagueTeamState Data = new UpdateLeagueTeamState();
	}
}
