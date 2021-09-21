using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013FC RID: 5116
	internal class PtcG2C_DoodadItemAddNtf : Protocol
	{
		// Token: 0x0600E4F4 RID: 58612 RVA: 0x0033C57C File Offset: 0x0033A77C
		public override uint GetProtoType()
		{
			return 16613U;
		}

		// Token: 0x0600E4F5 RID: 58613 RVA: 0x0033C593 File Offset: 0x0033A793
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoodadItemAddNtf>(stream, this.Data);
		}

		// Token: 0x0600E4F6 RID: 58614 RVA: 0x0033C5A3 File Offset: 0x0033A7A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DoodadItemAddNtf>(stream);
		}

		// Token: 0x0600E4F7 RID: 58615 RVA: 0x0033C5B2 File Offset: 0x0033A7B2
		public override void Process()
		{
			Process_PtcG2C_DoodadItemAddNtf.Process(this);
		}

		// Token: 0x04006439 RID: 25657
		public DoodadItemAddNtf Data = new DoodadItemAddNtf();
	}
}
