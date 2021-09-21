using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012F9 RID: 4857
	internal class PtcG2C_SkyCityBattleDataNtf : Protocol
	{
		// Token: 0x0600E0D0 RID: 57552 RVA: 0x00336A40 File Offset: 0x00334C40
		public override uint GetProtoType()
		{
			return 51753U;
		}

		// Token: 0x0600E0D1 RID: 57553 RVA: 0x00336A57 File Offset: 0x00334C57
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCityAllInfo>(stream, this.Data);
		}

		// Token: 0x0600E0D2 RID: 57554 RVA: 0x00336A67 File Offset: 0x00334C67
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCityAllInfo>(stream);
		}

		// Token: 0x0600E0D3 RID: 57555 RVA: 0x00336A76 File Offset: 0x00334C76
		public override void Process()
		{
			Process_PtcG2C_SkyCityBattleDataNtf.Process(this);
		}

		// Token: 0x0400636D RID: 25453
		public SkyCityAllInfo Data = new SkyCityAllInfo();
	}
}
