using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_GiftIBBackInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 6953U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GiftIBBackInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GiftIBBackInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_GiftIBBackInfoNtf.Process(this);
		}

		public GiftIBBackInfo Data = new GiftIBBackInfo();
	}
}
