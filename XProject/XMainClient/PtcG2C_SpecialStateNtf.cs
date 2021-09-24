using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_SpecialStateNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 11703U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpecialStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SpecialStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_SpecialStateNtf.Process(this);
		}

		public SpecialStateNtf Data = new SpecialStateNtf();
	}
}
