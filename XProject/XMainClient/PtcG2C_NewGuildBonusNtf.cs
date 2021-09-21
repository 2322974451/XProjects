using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000D8B RID: 3467
	internal class PtcG2C_NewGuildBonusNtf : Protocol
	{
		// Token: 0x0600BD1C RID: 48412 RVA: 0x00270810 File Offset: 0x0026EA10
		public override uint GetProtoType()
		{
			return 33515U;
		}

		// Token: 0x0600BD1D RID: 48413 RVA: 0x00270827 File Offset: 0x0026EA27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NewGuildBonusData>(stream, this.Data);
		}

		// Token: 0x0600BD1E RID: 48414 RVA: 0x00270837 File Offset: 0x0026EA37
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NewGuildBonusData>(stream);
		}

		// Token: 0x0600BD1F RID: 48415 RVA: 0x00270846 File Offset: 0x0026EA46
		public override void Process()
		{
			Process_PtcG2C_NewGuildBonusNtf.Process(this);
		}

		// Token: 0x04004D03 RID: 19715
		public NewGuildBonusData Data = new NewGuildBonusData();
	}
}
