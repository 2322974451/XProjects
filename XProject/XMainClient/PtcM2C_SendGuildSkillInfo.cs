using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SendGuildSkillInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 55907U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildSkillAllData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GuildSkillAllData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SendGuildSkillInfo.Process(this);
		}

		public GuildSkillAllData Data = new GuildSkillAllData();
	}
}
