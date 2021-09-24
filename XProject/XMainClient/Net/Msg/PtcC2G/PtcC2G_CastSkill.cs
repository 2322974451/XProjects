using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_CastSkill : Protocol
	{

		public override uint GetProtoType()
		{
			return 49584U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillDataUnit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillDataUnit>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SkillDataUnit Data = new SkillDataUnit();
	}
}
