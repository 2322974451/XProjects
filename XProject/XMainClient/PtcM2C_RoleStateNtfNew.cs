using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_RoleStateNtfNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 62463U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RoleStateNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RoleStateNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_RoleStateNtfNew.Process(this);
		}

		public RoleStateNtf Data = new RoleStateNtf();
	}
}
