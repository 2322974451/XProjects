using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LevelSealNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 40338U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelSealInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LevelSealInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LevelSealNtf.Process(this);
		}

		public LevelSealInfo Data = new LevelSealInfo();
	}
}
