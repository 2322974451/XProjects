using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_WeddingLoadInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 61694U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WeddingLoadInfoNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<WeddingLoadInfoNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_WeddingLoadInfoNtf.Process(this);
		}

		public WeddingLoadInfoNtf Data = new WeddingLoadInfoNtf();
	}
}
