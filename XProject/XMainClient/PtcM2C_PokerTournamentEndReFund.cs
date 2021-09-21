using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014A4 RID: 5284
	internal class PtcM2C_PokerTournamentEndReFund : Protocol
	{
		// Token: 0x0600E79A RID: 59290 RVA: 0x00340400 File Offset: 0x0033E600
		public override uint GetProtoType()
		{
			return 50590U;
		}

		// Token: 0x0600E79B RID: 59291 RVA: 0x00340417 File Offset: 0x0033E617
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PokerTournamentEndReFundMsg>(stream, this.Data);
		}

		// Token: 0x0600E79C RID: 59292 RVA: 0x00340427 File Offset: 0x0033E627
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PokerTournamentEndReFundMsg>(stream);
		}

		// Token: 0x0600E79D RID: 59293 RVA: 0x00340436 File Offset: 0x0033E636
		public override void Process()
		{
			Process_PtcM2C_PokerTournamentEndReFund.Process(this);
		}

		// Token: 0x040064B6 RID: 25782
		public PokerTournamentEndReFundMsg Data = new PokerTournamentEndReFundMsg();
	}
}
