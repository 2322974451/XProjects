using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015AF RID: 5551
	internal class PtcG2C_WeddingEventNtf : Protocol
	{
		// Token: 0x0600EBE3 RID: 60387 RVA: 0x003465A0 File Offset: 0x003447A0
		public override uint GetProtoType()
		{
			return 51472U;
		}

		// Token: 0x0600EBE4 RID: 60388 RVA: 0x003465B7 File Offset: 0x003447B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingEventNtf>(stream, this.Data);
		}

		// Token: 0x0600EBE5 RID: 60389 RVA: 0x003465C7 File Offset: 0x003447C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingEventNtf>(stream);
		}

		// Token: 0x0600EBE6 RID: 60390 RVA: 0x003465D6 File Offset: 0x003447D6
		public override void Process()
		{
			Process_PtcG2C_WeddingEventNtf.Process(this);
		}

		// Token: 0x04006591 RID: 26001
		public WeddingEventNtf Data = new WeddingEventNtf();
	}
}
