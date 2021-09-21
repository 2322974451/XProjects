using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001497 RID: 5271
	internal class PtcM2C_UpdateLeagueEleRoomStateNtf : Protocol
	{
		// Token: 0x0600E765 RID: 59237 RVA: 0x0033FFA0 File Offset: 0x0033E1A0
		public override uint GetProtoType()
		{
			return 15800U;
		}

		// Token: 0x0600E766 RID: 59238 RVA: 0x0033FFB7 File Offset: 0x0033E1B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateLeagueEleRoomStateNtf>(stream, this.Data);
		}

		// Token: 0x0600E767 RID: 59239 RVA: 0x0033FFC7 File Offset: 0x0033E1C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateLeagueEleRoomStateNtf>(stream);
		}

		// Token: 0x0600E768 RID: 59240 RVA: 0x0033FFD6 File Offset: 0x0033E1D6
		public override void Process()
		{
			Process_PtcM2C_UpdateLeagueEleRoomStateNtf.Process(this);
		}

		// Token: 0x040064AD RID: 25773
		public UpdateLeagueEleRoomStateNtf Data = new UpdateLeagueEleRoomStateNtf();
	}
}
