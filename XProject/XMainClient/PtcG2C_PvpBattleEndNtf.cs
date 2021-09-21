using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001121 RID: 4385
	internal class PtcG2C_PvpBattleEndNtf : Protocol
	{
		// Token: 0x0600D947 RID: 55623 RVA: 0x0032AC6C File Offset: 0x00328E6C
		public override uint GetProtoType()
		{
			return 46438U;
		}

		// Token: 0x0600D948 RID: 55624 RVA: 0x0032AC83 File Offset: 0x00328E83
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpBattleEndData>(stream, this.Data);
		}

		// Token: 0x0600D949 RID: 55625 RVA: 0x0032AC93 File Offset: 0x00328E93
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PvpBattleEndData>(stream);
		}

		// Token: 0x0600D94A RID: 55626 RVA: 0x0032ACA2 File Offset: 0x00328EA2
		public override void Process()
		{
			Process_PtcG2C_PvpBattleEndNtf.Process(this);
		}

		// Token: 0x040061FD RID: 25085
		public PvpBattleEndData Data = new PvpBattleEndData();
	}
}
