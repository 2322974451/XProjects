using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TransSkillNotfiy : Protocol
	{

		public override uint GetProtoType()
		{
			return 1366U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TransSkillNotfiy>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TransSkillNotfiy>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TransSkillNotfiy.Process(this);
		}

		public TransSkillNotfiy Data = new TransSkillNotfiy();
	}
}
