using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_FriendQueryReportNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 15079U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendQueryReportNew>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FriendQueryReportNew>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public FriendQueryReportNew Data = new FriendQueryReportNew();
	}
}
