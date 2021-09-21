using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001003 RID: 4099
	internal class PtcG2C_UnitDisappear : Protocol
	{
		// Token: 0x0600D4B6 RID: 54454 RVA: 0x00321D58 File Offset: 0x0031FF58
		public override uint GetProtoType()
		{
			return 26347U;
		}

		// Token: 0x0600D4B7 RID: 54455 RVA: 0x00321D6F File Offset: 0x0031FF6F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UnitAppearance>(stream, this.Data);
		}

		// Token: 0x0600D4B8 RID: 54456 RVA: 0x00321D7F File Offset: 0x0031FF7F
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UnitAppearance>(stream);
		}

		// Token: 0x0600D4B9 RID: 54457 RVA: 0x00321D8E File Offset: 0x0031FF8E
		public override void Process()
		{
			Process_PtcG2C_UnitDisappear.Process(this);
		}

		// Token: 0x040060FF RID: 24831
		public UnitAppearance Data = new UnitAppearance();
	}
}
