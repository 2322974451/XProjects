using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LevelChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 38651U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LevelChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LevelChangeNtf.Process(this);
		}

		public LevelChanged Data = new LevelChanged();
	}
}
