using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001227 RID: 4647
	internal class PtcM2C_SendGuildSkillInfo : Protocol
	{
		// Token: 0x0600DD67 RID: 56679 RVA: 0x00331C9C File Offset: 0x0032FE9C
		public override uint GetProtoType()
		{
			return 55907U;
		}

		// Token: 0x0600DD68 RID: 56680 RVA: 0x00331CB3 File Offset: 0x0032FEB3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSkillAllData>(stream, this.Data);
		}

		// Token: 0x0600DD69 RID: 56681 RVA: 0x00331CC3 File Offset: 0x0032FEC3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildSkillAllData>(stream);
		}

		// Token: 0x0600DD6A RID: 56682 RVA: 0x00331CD2 File Offset: 0x0032FED2
		public override void Process()
		{
			Process_PtcM2C_SendGuildSkillInfo.Process(this);
		}

		// Token: 0x040062C1 RID: 25281
		public GuildSkillAllData Data = new GuildSkillAllData();
	}
}
