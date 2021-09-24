using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BigMeleePointNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 15624U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BigMeleePoint>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BigMeleePoint>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BigMeleePointNtf.Process(this);
		}

		public BigMeleePoint Data = new BigMeleePoint();
	}
}
