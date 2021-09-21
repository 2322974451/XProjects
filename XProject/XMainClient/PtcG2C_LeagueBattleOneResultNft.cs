using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B4A RID: 2890
	internal class PtcG2C_LeagueBattleOneResultNft : Protocol
	{
		// Token: 0x0600A89E RID: 43166 RVA: 0x001E0D74 File Offset: 0x001DEF74
		public override uint GetProtoType()
		{
			return 40599U;
		}

		// Token: 0x0600A89F RID: 43167 RVA: 0x001E0D8B File Offset: 0x001DEF8B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleOneResultNtf>(stream, this.Data);
		}

		// Token: 0x0600A8A0 RID: 43168 RVA: 0x001E0D9B File Offset: 0x001DEF9B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleOneResultNtf>(stream);
		}

		// Token: 0x0600A8A1 RID: 43169 RVA: 0x001E0DAA File Offset: 0x001DEFAA
		public override void Process()
		{
			Process_PtcG2C_LeagueBattleOneResultNft.Process(this);
		}

		// Token: 0x04003E7B RID: 15995
		public LeagueBattleOneResultNtf Data = new LeagueBattleOneResultNtf();
	}
}
