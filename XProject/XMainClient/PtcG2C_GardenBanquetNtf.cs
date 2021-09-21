using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B44 RID: 2884
	internal class PtcG2C_GardenBanquetNtf : Protocol
	{
		// Token: 0x0600A87E RID: 43134 RVA: 0x001E0B18 File Offset: 0x001DED18
		public override uint GetProtoType()
		{
			return 56088U;
		}

		// Token: 0x0600A87F RID: 43135 RVA: 0x001E0B2F File Offset: 0x001DED2F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BanquetNtfArg>(stream, this.Data);
		}

		// Token: 0x0600A880 RID: 43136 RVA: 0x001E0B3F File Offset: 0x001DED3F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BanquetNtfArg>(stream);
		}

		// Token: 0x0600A881 RID: 43137 RVA: 0x001E0B4E File Offset: 0x001DED4E
		public override void Process()
		{
			Process_PtcG2C_GardenBanquetNtf.Process(this);
		}

		// Token: 0x04003E73 RID: 15987
		public BanquetNtfArg Data = new BanquetNtfArg();
	}
}
