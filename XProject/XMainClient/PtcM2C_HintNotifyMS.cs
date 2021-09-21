using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B42 RID: 2882
	internal class PtcM2C_HintNotifyMS : Protocol
	{
		// Token: 0x0600A873 RID: 43123 RVA: 0x001E0A44 File Offset: 0x001DEC44
		public override uint GetProtoType()
		{
			return 15542U;
		}

		// Token: 0x0600A874 RID: 43124 RVA: 0x001E0A5B File Offset: 0x001DEC5B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HintNotify>(stream, this.Data);
		}

		// Token: 0x0600A875 RID: 43125 RVA: 0x001E0A6B File Offset: 0x001DEC6B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HintNotify>(stream);
		}

		// Token: 0x0600A876 RID: 43126 RVA: 0x001E0A7A File Offset: 0x001DEC7A
		public override void Process()
		{
			Process_PtcM2C_HintNotifyMS.Process(this);
		}

		// Token: 0x04003E70 RID: 15984
		public HintNotify Data = new HintNotify();
	}
}
