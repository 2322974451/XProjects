using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SpriteStateChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 38584U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpriteState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpriteState>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SpriteStateChangeNtf.Process(this);
		}

		public SpriteState Data = new SpriteState();
	}
}
