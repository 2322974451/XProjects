using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BigMeleeReliveNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 3358U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BigMeleeRelive>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BigMeleeRelive>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BigMeleeReliveNtf.Process(this);
		}

		public BigMeleeRelive Data = new BigMeleeRelive();
	}
}
