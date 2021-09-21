using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200111F RID: 4383
	internal class PtcG2C_PvpBattleBeginNtf : Protocol
	{
		// Token: 0x0600D940 RID: 55616 RVA: 0x0032ABF4 File Offset: 0x00328DF4
		public override uint GetProtoType()
		{
			return 53763U;
		}

		// Token: 0x0600D941 RID: 55617 RVA: 0x0032AC0B File Offset: 0x00328E0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpBattleBeginData>(stream, this.Data);
		}

		// Token: 0x0600D942 RID: 55618 RVA: 0x0032AC1B File Offset: 0x00328E1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PvpBattleBeginData>(stream);
		}

		// Token: 0x0600D943 RID: 55619 RVA: 0x0032AC2A File Offset: 0x00328E2A
		public override void Process()
		{
			Process_PtcG2C_PvpBattleBeginNtf.Process(this);
		}

		// Token: 0x040061FC RID: 25084
		public PvpBattleBeginData Data = new PvpBattleBeginData();
	}
}
