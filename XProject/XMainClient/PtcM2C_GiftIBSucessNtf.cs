using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GiftIBSucessNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 29707U;
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
			Process_PtcM2C_GiftIBSucessNtf.Process(this);
		}

		public GiftIBBackInfo Data = new GiftIBBackInfo();
	}
}
