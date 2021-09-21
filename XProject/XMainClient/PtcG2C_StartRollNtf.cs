using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001200 RID: 4608
	internal class PtcG2C_StartRollNtf : Protocol
	{
		// Token: 0x0600DCC5 RID: 56517 RVA: 0x00330D0C File Offset: 0x0032EF0C
		public override uint GetProtoType()
		{
			return 41146U;
		}

		// Token: 0x0600DCC6 RID: 56518 RVA: 0x00330D23 File Offset: 0x0032EF23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartRollNtfData>(stream, this.Data);
		}

		// Token: 0x0600DCC7 RID: 56519 RVA: 0x00330D33 File Offset: 0x0032EF33
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<StartRollNtfData>(stream);
		}

		// Token: 0x0600DCC8 RID: 56520 RVA: 0x00330D42 File Offset: 0x0032EF42
		public override void Process()
		{
			Process_PtcG2C_StartRollNtf.Process(this);
		}

		// Token: 0x040062A1 RID: 25249
		public StartRollNtfData Data = new StartRollNtfData();
	}
}
