using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_LevelScriptStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 12789U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelScriptStateData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LevelScriptStateData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_LevelScriptStateNtf.Process(this);
		}

		public LevelScriptStateData Data = new LevelScriptStateData();
	}
}
