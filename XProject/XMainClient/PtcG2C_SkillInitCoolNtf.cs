using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SkillInitCoolNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4132U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillInitCoolPara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkillInitCoolPara>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SkillInitCoolNtf.Process(this);
		}

		public SkillInitCoolPara Data = new SkillInitCoolPara();
	}
}
