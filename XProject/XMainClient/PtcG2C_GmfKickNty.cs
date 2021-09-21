using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012EF RID: 4847
	internal class PtcG2C_GmfKickNty : Protocol
	{
		// Token: 0x0600E0A6 RID: 57510 RVA: 0x00336644 File Offset: 0x00334844
		public override uint GetProtoType()
		{
			return 21295U;
		}

		// Token: 0x0600E0A7 RID: 57511 RVA: 0x0033665B File Offset: 0x0033485B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfKickRes>(stream, this.Data);
		}

		// Token: 0x0600E0A8 RID: 57512 RVA: 0x0033666B File Offset: 0x0033486B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfKickRes>(stream);
		}

		// Token: 0x0600E0A9 RID: 57513 RVA: 0x0033667A File Offset: 0x0033487A
		public override void Process()
		{
			Process_PtcG2C_GmfKickNty.Process(this);
		}

		// Token: 0x04006365 RID: 25445
		public GmfKickRes Data = new GmfKickRes();
	}
}
