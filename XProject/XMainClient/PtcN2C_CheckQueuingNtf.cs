using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B53 RID: 2899
	internal class PtcN2C_CheckQueuingNtf : Protocol
	{
		// Token: 0x0600A8CF RID: 43215 RVA: 0x001E1118 File Offset: 0x001DF318
		public override uint GetProtoType()
		{
			return 25553U;
		}

		// Token: 0x0600A8D0 RID: 43216 RVA: 0x001E112F File Offset: 0x001DF32F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckQueuingNtf>(stream, this.Data);
		}

		// Token: 0x0600A8D1 RID: 43217 RVA: 0x001E113F File Offset: 0x001DF33F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckQueuingNtf>(stream);
		}

		// Token: 0x0600A8D2 RID: 43218 RVA: 0x001E114E File Offset: 0x001DF34E
		public override void Process()
		{
			Process_PtcN2C_CheckQueuingNtf.Process(this);
		}

		// Token: 0x04003E88 RID: 16008
		public CheckQueuingNtf Data = new CheckQueuingNtf();
	}
}
