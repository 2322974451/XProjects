using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_RoleMatchStateM2CNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 11521U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RoleStateMatch>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<RoleStateMatch>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_RoleMatchStateM2CNotify.Process(this);
		}

		public RoleStateMatch Data = new RoleStateMatch();
	}
}
