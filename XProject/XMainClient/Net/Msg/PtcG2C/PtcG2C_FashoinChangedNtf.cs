using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_FashoinChangedNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 12350U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FashionChangedData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FashionChangedData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_FashoinChangedNtf.Process(this);
		}

		public FashionChangedData Data = new FashionChangedData();
	}
}
