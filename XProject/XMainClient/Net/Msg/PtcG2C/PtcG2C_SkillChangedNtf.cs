using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkillChangedNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 38872U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillChangedData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillChangedData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkillChangedNtf.Process(this);
		}

		public SkillChangedData Data = new SkillChangedData();
	}
}
