using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001001 RID: 4097
	internal class PtcG2C_UnitAppear : Protocol
	{
		// Token: 0x0600D4AD RID: 54445 RVA: 0x00321AF8 File Offset: 0x0031FCF8
		public override uint GetProtoType()
		{
			return 7458U;
		}

		// Token: 0x0600D4AE RID: 54446 RVA: 0x00321B0F File Offset: 0x0031FD0F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UnitAppearList>(stream, this.Data);
		}

		// Token: 0x0600D4AF RID: 54447 RVA: 0x00321B1F File Offset: 0x0031FD1F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UnitAppearList>(stream);
		}

		// Token: 0x0600D4B0 RID: 54448 RVA: 0x00321B2E File Offset: 0x0031FD2E
		public override void Process()
		{
			Process_PtcG2C_UnitAppear.Process(this);
		}

		// Token: 0x040060F9 RID: 24825
		public UnitAppearList Data = new UnitAppearList();
	}
}
