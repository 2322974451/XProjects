using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200131B RID: 4891
	internal class PtcG2C_SpActivityOffsetDayNtf : Protocol
	{
		// Token: 0x0600E15A RID: 57690 RVA: 0x0033769C File Offset: 0x0033589C
		public override uint GetProtoType()
		{
			return 4059U;
		}

		// Token: 0x0600E15B RID: 57691 RVA: 0x003376B3 File Offset: 0x003358B3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpActivityOffsetDay>(stream, this.Data);
		}

		// Token: 0x0600E15C RID: 57692 RVA: 0x003376C3 File Offset: 0x003358C3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpActivityOffsetDay>(stream);
		}

		// Token: 0x0600E15D RID: 57693 RVA: 0x003376D2 File Offset: 0x003358D2
		public override void Process()
		{
			Process_PtcG2C_SpActivityOffsetDayNtf.Process(this);
		}

		// Token: 0x04006387 RID: 25479
		public SpActivityOffsetDay Data = new SpActivityOffsetDay();
	}
}
