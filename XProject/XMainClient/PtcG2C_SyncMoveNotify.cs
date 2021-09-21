using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013BD RID: 5053
	internal class PtcG2C_SyncMoveNotify : Protocol
	{
		// Token: 0x0600E3F1 RID: 58353 RVA: 0x0033B0A4 File Offset: 0x003392A4
		public override uint GetProtoType()
		{
			return 32838U;
		}

		// Token: 0x0600E3F2 RID: 58354 RVA: 0x0033B0BB File Offset: 0x003392BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StepMoveData>(stream, this.Data);
		}

		// Token: 0x0600E3F3 RID: 58355 RVA: 0x0033B0CB File Offset: 0x003392CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StepMoveData>(stream);
		}

		// Token: 0x0600E3F4 RID: 58356 RVA: 0x0033B0DA File Offset: 0x003392DA
		public override void Process()
		{
			Process_PtcG2C_SyncMoveNotify.Process(this);
		}

		// Token: 0x04006407 RID: 25607
		public StepMoveData Data = new StepMoveData();
	}
}
