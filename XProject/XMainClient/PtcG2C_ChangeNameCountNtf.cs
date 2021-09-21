using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B54 RID: 2900
	internal class PtcG2C_ChangeNameCountNtf : Protocol
	{
		// Token: 0x0600A8D4 RID: 43220 RVA: 0x001E1170 File Offset: 0x001DF370
		public override uint GetProtoType()
		{
			return 59287U;
		}

		// Token: 0x0600A8D5 RID: 43221 RVA: 0x001E1187 File Offset: 0x001DF387
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeNameCountNtf>(stream, this.Data);
		}

		// Token: 0x0600A8D6 RID: 43222 RVA: 0x001E1197 File Offset: 0x001DF397
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangeNameCountNtf>(stream);
		}

		// Token: 0x0600A8D7 RID: 43223 RVA: 0x001E11A6 File Offset: 0x001DF3A6
		public override void Process()
		{
			Process_PtcG2C_ChangeNameCountNtf.Process(this);
		}

		// Token: 0x04003E89 RID: 16009
		public ChangeNameCountNtf Data = new ChangeNameCountNtf();
	}
}
