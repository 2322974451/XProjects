using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014B7 RID: 5303
	internal class PtcG2C_CountDownNtf : Protocol
	{
		// Token: 0x0600E7E6 RID: 59366 RVA: 0x00340A54 File Offset: 0x0033EC54
		public override uint GetProtoType()
		{
			return 3259U;
		}

		// Token: 0x0600E7E7 RID: 59367 RVA: 0x00340A6B File Offset: 0x0033EC6B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CountDownNtf>(stream, this.Data);
		}

		// Token: 0x0600E7E8 RID: 59368 RVA: 0x00340A7B File Offset: 0x0033EC7B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CountDownNtf>(stream);
		}

		// Token: 0x0600E7E9 RID: 59369 RVA: 0x00340A8A File Offset: 0x0033EC8A
		public override void Process()
		{
			Process_PtcG2C_CountDownNtf.Process(this);
		}

		// Token: 0x040064C4 RID: 25796
		public CountDownNtf Data = new CountDownNtf();
	}
}
