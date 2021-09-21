using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001225 RID: 4645
	internal class PtcM2C_LoginGuildInfo : Protocol
	{
		// Token: 0x0600DD60 RID: 56672 RVA: 0x00331C24 File Offset: 0x0032FE24
		public override uint GetProtoType()
		{
			return 29049U;
		}

		// Token: 0x0600DD61 RID: 56673 RVA: 0x00331C3B File Offset: 0x0032FE3B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MyGuild>(stream, this.Data);
		}

		// Token: 0x0600DD62 RID: 56674 RVA: 0x00331C4B File Offset: 0x0032FE4B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MyGuild>(stream);
		}

		// Token: 0x0600DD63 RID: 56675 RVA: 0x00331C5A File Offset: 0x0032FE5A
		public override void Process()
		{
			Process_PtcM2C_LoginGuildInfo.Process(this);
		}

		// Token: 0x040062C0 RID: 25280
		public MyGuild Data = new MyGuild();
	}
}
