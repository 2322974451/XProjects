using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PkPrepareNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 41409U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkPrepareNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkPrepareNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PkPrepareNtf.Process(this);
		}

		public PkPrepareNtf Data = new PkPrepareNtf();
	}
}
