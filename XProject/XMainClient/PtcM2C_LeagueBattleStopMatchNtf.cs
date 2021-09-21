using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001472 RID: 5234
	internal class PtcM2C_LeagueBattleStopMatchNtf : Protocol
	{
		// Token: 0x0600E6CC RID: 59084 RVA: 0x0033F078 File Offset: 0x0033D278
		public override uint GetProtoType()
		{
			return 53912U;
		}

		// Token: 0x0600E6CD RID: 59085 RVA: 0x0033F08F File Offset: 0x0033D28F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleStopMatchNtf>(stream, this.Data);
		}

		// Token: 0x0600E6CE RID: 59086 RVA: 0x0033F09F File Offset: 0x0033D29F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleStopMatchNtf>(stream);
		}

		// Token: 0x0600E6CF RID: 59087 RVA: 0x0033F0AE File Offset: 0x0033D2AE
		public override void Process()
		{
			Process_PtcM2C_LeagueBattleStopMatchNtf.Process(this);
		}

		// Token: 0x0400648F RID: 25743
		public LeagueBattleStopMatchNtf Data = new LeagueBattleStopMatchNtf();
	}
}
