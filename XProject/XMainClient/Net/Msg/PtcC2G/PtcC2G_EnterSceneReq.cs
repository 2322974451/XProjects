using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_EnterSceneReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 9036U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneRequest>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SceneRequest>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public SceneRequest Data = new SceneRequest();
	}
}
