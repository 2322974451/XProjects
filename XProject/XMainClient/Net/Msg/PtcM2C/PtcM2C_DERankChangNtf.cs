using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_DERankChangNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 11404U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DERankChangePara>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<DERankChangePara>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_DERankChangNtf.Process(this);
		}

		public DERankChangePara Data = new DERankChangePara();
	}
}
