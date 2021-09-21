using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001186 RID: 4486
	internal class PtcG2C_GmfAllFightEndNtf : Protocol
	{
		// Token: 0x0600DAE6 RID: 56038 RVA: 0x0032E3C8 File Offset: 0x0032C5C8
		public override uint GetProtoType()
		{
			return 42921U;
		}

		// Token: 0x0600DAE7 RID: 56039 RVA: 0x0032E3DF File Offset: 0x0032C5DF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GmfAllFightEnd>(stream, this.Data);
		}

		// Token: 0x0600DAE8 RID: 56040 RVA: 0x0032E3EF File Offset: 0x0032C5EF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GmfAllFightEnd>(stream);
		}

		// Token: 0x0600DAE9 RID: 56041 RVA: 0x0032E3FE File Offset: 0x0032C5FE
		public override void Process()
		{
			Process_PtcG2C_GmfAllFightEndNtf.Process(this);
		}

		// Token: 0x0400624D RID: 25165
		public GmfAllFightEnd Data = new GmfAllFightEnd();
	}
}
