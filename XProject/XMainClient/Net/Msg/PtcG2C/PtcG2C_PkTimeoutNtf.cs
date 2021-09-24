using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PkTimeoutNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 58692U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkTimeoutNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkTimeoutNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PkTimeoutNtf.Process(this);
		}

		public PkTimeoutNtf Data = new PkTimeoutNtf();
	}
}
