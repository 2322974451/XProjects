using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B45 RID: 2885
	internal class PtcM2C_GardenBanquetNtf : Protocol
	{
		// Token: 0x0600A883 RID: 43139 RVA: 0x001E0B70 File Offset: 0x001DED70
		public override uint GetProtoType()
		{
			return 21287U;
		}

		// Token: 0x0600A884 RID: 43140 RVA: 0x001E0B87 File Offset: 0x001DED87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BanquetNtfArg>(stream, this.Data);
		}

		// Token: 0x0600A885 RID: 43141 RVA: 0x001E0B97 File Offset: 0x001DED97
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BanquetNtfArg>(stream);
		}

		// Token: 0x0600A886 RID: 43142 RVA: 0x001E0BA6 File Offset: 0x001DEDA6
		public override void Process()
		{
			Process_PtcM2C_GardenBanquetNtf.Process(this);
		}

		// Token: 0x04003E74 RID: 15988
		public BanquetNtfArg Data = new BanquetNtfArg();
	}
}
