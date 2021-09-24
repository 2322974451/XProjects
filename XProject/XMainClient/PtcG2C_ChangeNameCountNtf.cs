using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ChangeNameCountNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 59287U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeNameCountNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangeNameCountNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ChangeNameCountNtf.Process(this);
		}

		public ChangeNameCountNtf Data = new ChangeNameCountNtf();
	}
}
