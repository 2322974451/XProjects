using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001440 RID: 5184
	internal class PtcG2C_DoodadItemUseNtf : Protocol
	{
		// Token: 0x0600E60B RID: 58891 RVA: 0x0033DD00 File Offset: 0x0033BF00
		public override uint GetProtoType()
		{
			return 13498U;
		}

		// Token: 0x0600E60C RID: 58892 RVA: 0x0033DD17 File Offset: 0x0033BF17
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoodadItemUseNtf>(stream, this.Data);
		}

		// Token: 0x0600E60D RID: 58893 RVA: 0x0033DD27 File Offset: 0x0033BF27
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DoodadItemUseNtf>(stream);
		}

		// Token: 0x0600E60E RID: 58894 RVA: 0x0033DD36 File Offset: 0x0033BF36
		public override void Process()
		{
			Process_PtcG2C_DoodadItemUseNtf.Process(this);
		}

		// Token: 0x0400646E RID: 25710
		public DoodadItemUseNtf Data = new DoodadItemUseNtf();
	}
}
