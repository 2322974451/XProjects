using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MakePartnerResultNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 49652U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MakePartnerResult>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MakePartnerResult>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MakePartnerResultNtf.Process(this);
		}

		public MakePartnerResult Data = new MakePartnerResult();
	}
}
