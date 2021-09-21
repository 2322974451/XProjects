using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001268 RID: 4712
	internal class PtcG2C_IBShopIcon : Protocol
	{
		// Token: 0x0600DE7C RID: 56956 RVA: 0x00333544 File Offset: 0x00331744
		public override uint GetProtoType()
		{
			return 56800U;
		}

		// Token: 0x0600DE7D RID: 56957 RVA: 0x0033355B File Offset: 0x0033175B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBShopIcon>(stream, this.Data);
		}

		// Token: 0x0600DE7E RID: 56958 RVA: 0x0033356B File Offset: 0x0033176B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IBShopIcon>(stream);
		}

		// Token: 0x0600DE7F RID: 56959 RVA: 0x0033357A File Offset: 0x0033177A
		public override void Process()
		{
			Process_PtcG2C_IBShopIcon.Process(this);
		}

		// Token: 0x040062FA RID: 25338
		public IBShopIcon Data = new IBShopIcon();
	}
}
