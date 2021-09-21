using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001286 RID: 4742
	internal class PtcM2C_NotifyGuildSkillData : Protocol
	{
		// Token: 0x0600DEF2 RID: 57074 RVA: 0x00333DD0 File Offset: 0x00331FD0
		public override uint GetProtoType()
		{
			return 2458U;
		}

		// Token: 0x0600DEF3 RID: 57075 RVA: 0x00333DE7 File Offset: 0x00331FE7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSkillAllData>(stream, this.Data);
		}

		// Token: 0x0600DEF4 RID: 57076 RVA: 0x00333DF7 File Offset: 0x00331FF7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildSkillAllData>(stream);
		}

		// Token: 0x0600DEF5 RID: 57077 RVA: 0x00333E06 File Offset: 0x00332006
		public override void Process()
		{
			Process_PtcM2C_NotifyGuildSkillData.Process(this);
		}

		// Token: 0x0400630F RID: 25359
		public GuildSkillAllData Data = new GuildSkillAllData();
	}
}
