using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_RoleStateReportNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 10217U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RoleStateReport>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RoleStateReport>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public RoleStateReport Data = new RoleStateReport();
	}
}
