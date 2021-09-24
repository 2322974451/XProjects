using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_DoodadItemAddNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 16613U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoodadItemAddNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DoodadItemAddNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_DoodadItemAddNtf.Process(this);
		}

		public DoodadItemAddNtf Data = new DoodadItemAddNtf();
	}
}
