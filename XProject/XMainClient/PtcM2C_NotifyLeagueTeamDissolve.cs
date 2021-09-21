using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001468 RID: 5224
	internal class PtcM2C_NotifyLeagueTeamDissolve : Protocol
	{
		// Token: 0x0600E6A5 RID: 59045 RVA: 0x0033ED30 File Offset: 0x0033CF30
		public override uint GetProtoType()
		{
			return 11033U;
		}

		// Token: 0x0600E6A6 RID: 59046 RVA: 0x0033ED47 File Offset: 0x0033CF47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifyLeagueTeamDissolve>(stream, this.Data);
		}

		// Token: 0x0600E6A7 RID: 59047 RVA: 0x0033ED57 File Offset: 0x0033CF57
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifyLeagueTeamDissolve>(stream);
		}

		// Token: 0x0600E6A8 RID: 59048 RVA: 0x0033ED66 File Offset: 0x0033CF66
		public override void Process()
		{
			Process_PtcM2C_NotifyLeagueTeamDissolve.Process(this);
		}

		// Token: 0x04006488 RID: 25736
		public NotifyLeagueTeamDissolve Data = new NotifyLeagueTeamDissolve();
	}
}
