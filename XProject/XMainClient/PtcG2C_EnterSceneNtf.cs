using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_EnterSceneNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 63366U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneCfg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneCfg>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_EnterSceneNtf.Process(this);
		}

		public SceneCfg Data = new SceneCfg();
	}
}
