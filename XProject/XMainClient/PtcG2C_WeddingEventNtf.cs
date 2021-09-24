using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WeddingEventNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51472U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingEventNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingEventNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WeddingEventNtf.Process(this);
		}

		public WeddingEventNtf Data = new WeddingEventNtf();
	}
}
