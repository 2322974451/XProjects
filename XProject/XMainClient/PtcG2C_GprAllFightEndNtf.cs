using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001350 RID: 4944
	internal class PtcG2C_GprAllFightEndNtf : Protocol
	{
		// Token: 0x0600E233 RID: 57907 RVA: 0x00338B00 File Offset: 0x00336D00
		public override uint GetProtoType()
		{
			return 58789U;
		}

		// Token: 0x0600E234 RID: 57908 RVA: 0x00338B17 File Offset: 0x00336D17
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GprAllFightEnd>(stream, this.Data);
		}

		// Token: 0x0600E235 RID: 57909 RVA: 0x00338B27 File Offset: 0x00336D27
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GprAllFightEnd>(stream);
		}

		// Token: 0x0600E236 RID: 57910 RVA: 0x00338B36 File Offset: 0x00336D36
		public override void Process()
		{
			Process_PtcG2C_GprAllFightEndNtf.Process(this);
		}

		// Token: 0x040063B1 RID: 25521
		public GprAllFightEnd Data = new GprAllFightEnd();
	}
}
