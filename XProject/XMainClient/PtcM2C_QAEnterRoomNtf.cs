using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B51 RID: 2897
	internal class PtcM2C_QAEnterRoomNtf : Protocol
	{
		// Token: 0x0600A8C5 RID: 43205 RVA: 0x001E1074 File Offset: 0x001DF274
		public override uint GetProtoType()
		{
			return 38488U;
		}

		// Token: 0x0600A8C6 RID: 43206 RVA: 0x001E108B File Offset: 0x001DF28B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QAEnterRoomNtf>(stream, this.Data);
		}

		// Token: 0x0600A8C7 RID: 43207 RVA: 0x001E109B File Offset: 0x001DF29B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QAEnterRoomNtf>(stream);
		}

		// Token: 0x0600A8C8 RID: 43208 RVA: 0x001E10AA File Offset: 0x001DF2AA
		public override void Process()
		{
			Process_PtcM2C_QAEnterRoomNtf.Process(this);
		}

		// Token: 0x04003E86 RID: 16006
		public QAEnterRoomNtf Data = new QAEnterRoomNtf();
	}
}
