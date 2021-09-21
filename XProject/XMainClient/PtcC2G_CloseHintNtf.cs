using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014B4 RID: 5300
	internal class PtcC2G_CloseHintNtf : Protocol
	{
		// Token: 0x0600E7DA RID: 59354 RVA: 0x003409B0 File Offset: 0x0033EBB0
		public override uint GetProtoType()
		{
			return 37802U;
		}

		// Token: 0x0600E7DB RID: 59355 RVA: 0x003409C7 File Offset: 0x0033EBC7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CloseHintNtf>(stream, this.Data);
		}

		// Token: 0x0600E7DC RID: 59356 RVA: 0x003409D7 File Offset: 0x0033EBD7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CloseHintNtf>(stream);
		}

		// Token: 0x0600E7DD RID: 59357 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040064C2 RID: 25794
		public CloseHintNtf Data = new CloseHintNtf();
	}
}
