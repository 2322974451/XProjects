using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_OpenSpriteEggNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 47965U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenSpriteEgg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OpenSpriteEgg>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public OpenSpriteEgg Data = new OpenSpriteEgg();
	}
}
