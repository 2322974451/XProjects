using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_AllyMatchRoleIDNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 41598U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllyMatchRoleID>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<AllyMatchRoleID>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_AllyMatchRoleIDNotify.Process(this);
		}

		public AllyMatchRoleID Data = new AllyMatchRoleID();
	}
}
