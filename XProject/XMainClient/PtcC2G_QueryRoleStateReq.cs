using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_QueryRoleStateReq : Protocol
	{

		public override uint GetProtoType()
		{
			return 54208U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryRoleStateReq>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QueryRoleStateReq>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public QueryRoleStateReq Data = new QueryRoleStateReq();
	}
}
