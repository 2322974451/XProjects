using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B4D RID: 2893
	internal class PtcG2C_ShareRandomGiftNtf : Protocol
	{
		// Token: 0x0600A8AE RID: 43182 RVA: 0x001E0EA0 File Offset: 0x001DF0A0
		public override uint GetProtoType()
		{
			return 18823U;
		}

		// Token: 0x0600A8AF RID: 43183 RVA: 0x001E0EB7 File Offset: 0x001DF0B7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShareRandomGiftData>(stream, this.Data);
		}

		// Token: 0x0600A8B0 RID: 43184 RVA: 0x001E0EC7 File Offset: 0x001DF0C7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ShareRandomGiftData>(stream);
		}

		// Token: 0x0600A8B1 RID: 43185 RVA: 0x001E0ED6 File Offset: 0x001DF0D6
		public override void Process()
		{
			Process_PtcG2C_ShareRandomGiftNtf.Process(this);
		}

		// Token: 0x04003E7F RID: 15999
		public ShareRandomGiftData Data = new ShareRandomGiftData();
	}
}
