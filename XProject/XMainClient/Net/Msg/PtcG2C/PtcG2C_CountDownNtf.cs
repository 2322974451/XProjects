using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_CountDownNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 3259U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CountDownNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CountDownNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_CountDownNtf.Process(this);
		}

		public CountDownNtf Data = new CountDownNtf();
	}
}
