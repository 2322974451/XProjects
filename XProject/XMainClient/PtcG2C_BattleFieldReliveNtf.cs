using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015F1 RID: 5617
	internal class PtcG2C_BattleFieldReliveNtf : Protocol
	{
		// Token: 0x0600ECF2 RID: 60658 RVA: 0x00347BE4 File Offset: 0x00345DE4
		public override uint GetProtoType()
		{
			return 813U;
		}

		// Token: 0x0600ECF3 RID: 60659 RVA: 0x00347BFB File Offset: 0x00345DFB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldReliveInfo>(stream, this.Data);
		}

		// Token: 0x0600ECF4 RID: 60660 RVA: 0x00347C0B File Offset: 0x00345E0B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BattleFieldReliveInfo>(stream);
		}

		// Token: 0x0600ECF5 RID: 60661 RVA: 0x00347C1A File Offset: 0x00345E1A
		public override void Process()
		{
			Process_PtcG2C_BattleFieldReliveNtf.Process(this);
		}

		// Token: 0x040065C4 RID: 26052
		public BattleFieldReliveInfo Data = new BattleFieldReliveInfo();
	}
}
