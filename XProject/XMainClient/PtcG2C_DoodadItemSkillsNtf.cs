using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_DoodadItemSkillsNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 45490U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoodadItemAllSkill>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DoodadItemAllSkill>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_DoodadItemSkillsNtf.Process(this);
		}

		public DoodadItemAllSkill Data = new DoodadItemAllSkill();
	}
}
