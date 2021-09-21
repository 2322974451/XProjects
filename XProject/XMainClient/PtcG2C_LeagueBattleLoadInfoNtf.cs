using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B49 RID: 2889
	internal class PtcG2C_LeagueBattleLoadInfoNtf : Protocol
	{
		// Token: 0x0600A899 RID: 43161 RVA: 0x001E0D1C File Offset: 0x001DEF1C
		public override uint GetProtoType()
		{
			return 16091U;
		}

		// Token: 0x0600A89A RID: 43162 RVA: 0x001E0D33 File Offset: 0x001DEF33
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeagueBattleLoadInfoNtf>(stream, this.Data);
		}

		// Token: 0x0600A89B RID: 43163 RVA: 0x001E0D43 File Offset: 0x001DEF43
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeagueBattleLoadInfoNtf>(stream);
		}

		// Token: 0x0600A89C RID: 43164 RVA: 0x001E0D52 File Offset: 0x001DEF52
		public override void Process()
		{
			Process_PtcG2C_LeagueBattleLoadInfoNtf.Process(this);
		}

		// Token: 0x04003E7A RID: 15994
		public LeagueBattleLoadInfoNtf Data = new LeagueBattleLoadInfoNtf();
	}
}
