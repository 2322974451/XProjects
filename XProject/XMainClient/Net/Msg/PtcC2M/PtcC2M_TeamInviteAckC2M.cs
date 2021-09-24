using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_TeamInviteAckC2M : Protocol
	{

		public override uint GetProtoType()
		{
			return 15365U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInviteAck>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamInviteAck>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public TeamInviteAck Data = new TeamInviteAck();
	}
}
