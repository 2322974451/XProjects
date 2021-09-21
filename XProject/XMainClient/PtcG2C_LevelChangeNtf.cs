using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200100E RID: 4110
	internal class PtcG2C_LevelChangeNtf : Protocol
	{
		// Token: 0x0600D4E0 RID: 54496 RVA: 0x003224E4 File Offset: 0x003206E4
		public override uint GetProtoType()
		{
			return 38651U;
		}

		// Token: 0x0600D4E1 RID: 54497 RVA: 0x003224FB File Offset: 0x003206FB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelChanged>(stream, this.Data);
		}

		// Token: 0x0600D4E2 RID: 54498 RVA: 0x0032250B File Offset: 0x0032070B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LevelChanged>(stream);
		}

		// Token: 0x0600D4E3 RID: 54499 RVA: 0x0032251A File Offset: 0x0032071A
		public override void Process()
		{
			Process_PtcG2C_LevelChangeNtf.Process(this);
		}

		// Token: 0x04006106 RID: 24838
		public LevelChanged Data = new LevelChanged();
	}
}
