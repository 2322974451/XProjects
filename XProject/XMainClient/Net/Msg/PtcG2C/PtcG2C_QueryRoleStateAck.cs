using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_QueryRoleStateAck : Protocol
	{

		public override uint GetProtoType()
		{
			return 53402U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryRoleStateAck>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QueryRoleStateAck>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_QueryRoleStateAck.Process(this);
		}

		public QueryRoleStateAck Data = new QueryRoleStateAck();
	}
}
