using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200138A RID: 5002
	internal class PtcM2C_GuildBuffSimpleItemNtf : Protocol
	{
		// Token: 0x0600E31E RID: 58142 RVA: 0x00339F44 File Offset: 0x00338144
		public override uint GetProtoType()
		{
			return 63964U;
		}

		// Token: 0x0600E31F RID: 58143 RVA: 0x00339F5B File Offset: 0x0033815B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBuffSimpleItem>(stream, this.Data);
		}

		// Token: 0x0600E320 RID: 58144 RVA: 0x00339F6B File Offset: 0x0033816B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildBuffSimpleItem>(stream);
		}

		// Token: 0x0600E321 RID: 58145 RVA: 0x00339F7A File Offset: 0x0033817A
		public override void Process()
		{
			Process_PtcM2C_GuildBuffSimpleItemNtf.Process(this);
		}

		// Token: 0x040063DE RID: 25566
		public GuildBuffSimpleItem Data = new GuildBuffSimpleItem();
	}
}
