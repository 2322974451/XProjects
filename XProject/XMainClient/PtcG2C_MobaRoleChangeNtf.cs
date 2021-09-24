using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_MobaRoleChangeNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 12958U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MobaRoleChangeData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MobaRoleChangeData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_MobaRoleChangeNtf.Process(this);
		}

		public MobaRoleChangeData Data = new MobaRoleChangeData();
	}
}
