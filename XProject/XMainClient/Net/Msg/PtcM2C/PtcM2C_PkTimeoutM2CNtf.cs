using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_PkTimeoutM2CNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 4963U;
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
			Process_PtcM2C_PkTimeoutM2CNtf.Process(this);
		}

		public PkTimeoutNtf Data = new PkTimeoutNtf();
	}
}
