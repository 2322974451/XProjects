using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkillResult : Protocol
	{

		public override uint GetProtoType()
		{
			return 1054U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillReplyDataUnit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillReplyDataUnit>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkillResult.Process(this);
		}

		public SkillReplyDataUnit Data = new SkillReplyDataUnit();
	}
}
