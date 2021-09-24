using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_BlackListNtfNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 1537U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BlackListNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BlackListNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_BlackListNtfNew.Process(this);
		}

		public BlackListNtf Data = new BlackListNtf();
	}
}
