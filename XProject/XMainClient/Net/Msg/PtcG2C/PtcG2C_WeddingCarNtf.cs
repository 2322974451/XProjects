using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WeddingCarNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 48301U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingCarNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingCarNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WeddingCarNtf.Process(this);
		}

		public WeddingCarNotify Data = new WeddingCarNotify();
	}
}
