using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WeddingStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 30976U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WeddingStateNtf.Process(this);
		}

		public WeddingStateNtf Data = new WeddingStateNtf();
	}
}
