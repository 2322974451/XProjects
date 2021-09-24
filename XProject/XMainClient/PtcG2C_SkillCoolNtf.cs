using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkillCoolNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 55142U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillCoolPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillCoolPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkillCoolNtf.Process(this);
		}

		public SkillCoolPara Data = new SkillCoolPara();
	}
}
