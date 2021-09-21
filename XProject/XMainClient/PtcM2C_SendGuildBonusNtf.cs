using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200135C RID: 4956
	internal class PtcM2C_SendGuildBonusNtf : Protocol
	{
		// Token: 0x0600E263 RID: 57955 RVA: 0x00338F2C File Offset: 0x0033712C
		public override uint GetProtoType()
		{
			return 36841U;
		}

		// Token: 0x0600E264 RID: 57956 RVA: 0x00338F43 File Offset: 0x00337143
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SendGuildBonusNtfData>(stream, this.Data);
		}

		// Token: 0x0600E265 RID: 57957 RVA: 0x00338F53 File Offset: 0x00337153
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SendGuildBonusNtfData>(stream);
		}

		// Token: 0x0600E266 RID: 57958 RVA: 0x00338F62 File Offset: 0x00337162
		public override void Process()
		{
			Process_PtcM2C_SendGuildBonusNtf.Process(this);
		}

		// Token: 0x040063BA RID: 25530
		public SendGuildBonusNtfData Data = new SendGuildBonusNtfData();
	}
}
