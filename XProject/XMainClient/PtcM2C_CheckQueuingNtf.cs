using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200120B RID: 4619
	internal class PtcM2C_CheckQueuingNtf : Protocol
	{
		// Token: 0x0600DCF5 RID: 56565 RVA: 0x00331080 File Offset: 0x0032F280
		public override uint GetProtoType()
		{
			return 25553U;
		}

		// Token: 0x0600DCF6 RID: 56566 RVA: 0x00331097 File Offset: 0x0032F297
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckQueuingNtf>(stream, this.Data);
		}

		// Token: 0x0600DCF7 RID: 56567 RVA: 0x003310A7 File Offset: 0x0032F2A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CheckQueuingNtf>(stream);
		}

		// Token: 0x0600DCF8 RID: 56568 RVA: 0x003310B6 File Offset: 0x0032F2B6
		public override void Process()
		{
			Process_PtcM2C_CheckQueuingNtf.Process(this);
		}

		// Token: 0x040062AB RID: 25259
		public CheckQueuingNtf Data = new CheckQueuingNtf();
	}
}
