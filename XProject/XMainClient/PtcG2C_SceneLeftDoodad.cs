using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SceneLeftDoodad : Protocol
	{

		public override uint GetProtoType()
		{
			return 18028U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneLeftDoodad>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneLeftDoodad>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SceneLeftDoodad.Process(this);
		}

		public SceneLeftDoodad Data = new SceneLeftDoodad();
	}
}
