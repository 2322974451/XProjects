using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014D0 RID: 5328
	internal class PtcC2M_IBGiftTipsReq : Protocol
	{
		// Token: 0x0600E84B RID: 59467 RVA: 0x00341274 File Offset: 0x0033F474
		public override uint GetProtoType()
		{
			return 29090U;
		}

		// Token: 0x0600E84C RID: 59468 RVA: 0x0034128B File Offset: 0x0033F48B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBGiftTips>(stream, this.Data);
		}

		// Token: 0x0600E84D RID: 59469 RVA: 0x0034129B File Offset: 0x0033F49B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBGiftTips>(stream);
		}

		// Token: 0x0600E84E RID: 59470 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040064D7 RID: 25815
		public IBGiftTips Data = new IBGiftTips();
	}
}
