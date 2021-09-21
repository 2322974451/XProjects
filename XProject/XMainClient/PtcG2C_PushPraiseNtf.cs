using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001476 RID: 5238
	internal class PtcG2C_PushPraiseNtf : Protocol
	{
		// Token: 0x0600E6DC RID: 59100 RVA: 0x0033F1F4 File Offset: 0x0033D3F4
		public override uint GetProtoType()
		{
			return 5686U;
		}

		// Token: 0x0600E6DD RID: 59101 RVA: 0x0033F20B File Offset: 0x0033D40B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PushPraise>(stream, this.Data);
		}

		// Token: 0x0600E6DE RID: 59102 RVA: 0x0033F21B File Offset: 0x0033D41B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PushPraise>(stream);
		}

		// Token: 0x0600E6DF RID: 59103 RVA: 0x0033F22A File Offset: 0x0033D42A
		public override void Process()
		{
			Process_PtcG2C_PushPraiseNtf.Process(this);
		}

		// Token: 0x04006492 RID: 25746
		public PushPraise Data = new PushPraise();
	}
}
