using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ChangeFashionNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 1731U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FashionChanged>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FashionChanged>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ChangeFashionNotify.Process(this);
		}

		public FashionChanged Data = new FashionChanged();
	}
}
