using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SceneStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4376U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SceneStateNtf.Process(this);
		}

		public SceneStateNtf Data = new SceneStateNtf();
	}
}
