using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013E3 RID: 5091
	internal class PtcC2M_PokerTournamentReq : Protocol
	{
		// Token: 0x0600E48B RID: 58507 RVA: 0x0033BDD0 File Offset: 0x00339FD0
		public override uint GetProtoType()
		{
			return 3685U;
		}

		// Token: 0x0600E48C RID: 58508 RVA: 0x0033BDE7 File Offset: 0x00339FE7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCardMatchReq>(stream, this.Data);
		}

		// Token: 0x0600E48D RID: 58509 RVA: 0x0033BDF7 File Offset: 0x00339FF7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildCardMatchReq>(stream);
		}

		// Token: 0x0600E48E RID: 58510 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006424 RID: 25636
		public GuildCardMatchReq Data = new GuildCardMatchReq();
	}
}
