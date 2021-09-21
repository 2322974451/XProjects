using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001486 RID: 5254
	internal class PtcM2C_LeagueBattleMatchTimeoutNtf : Protocol
	{
		// Token: 0x0600E71C RID: 59164 RVA: 0x0033F8BC File Offset: 0x0033DABC
		public override uint GetProtoType()
		{
			return 31012U;
		}

		// Token: 0x0600E71D RID: 59165 RVA: 0x0033F8D3 File Offset: 0x0033DAD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleMatchTimeoutNtf>(stream, this.Data);
		}

		// Token: 0x0600E71E RID: 59166 RVA: 0x0033F8E3 File Offset: 0x0033DAE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleMatchTimeoutNtf>(stream);
		}

		// Token: 0x0600E71F RID: 59167 RVA: 0x0033F8F2 File Offset: 0x0033DAF2
		public override void Process()
		{
			Process_PtcM2C_LeagueBattleMatchTimeoutNtf.Process(this);
		}

		// Token: 0x0400649E RID: 25758
		public LeagueBattleMatchTimeoutNtf Data = new LeagueBattleMatchTimeoutNtf();
	}
}
