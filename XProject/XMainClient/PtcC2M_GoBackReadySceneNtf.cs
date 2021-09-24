using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_GoBackReadySceneNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 10491U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoBackReadyScene>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GoBackReadyScene>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public GoBackReadyScene Data = new GoBackReadyScene();
	}
}
