using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SpriteChangedNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 197U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpriteChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpriteChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SpriteChangedNtf.Process(this);
		}

		public SpriteChanged Data = new SpriteChanged();
	}
}
