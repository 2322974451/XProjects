using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PkRoleInfoNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 8937U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PkRoleInfoNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PkRoleInfoNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PkRoleInfoNtf.Process(this);
		}

		public PkRoleInfoNtf Data = new PkRoleInfoNtf();
	}
}
