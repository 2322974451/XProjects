using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_BlackListReportNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 57057U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BlackListReport>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BlackListReport>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public BlackListReport Data = new BlackListReport();
	}
}
