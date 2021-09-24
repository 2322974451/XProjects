using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_TeamInviteNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 4060U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamInvite>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamInvite>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_TeamInviteNotify.Process(this);
		}

		public TeamInvite Data = new TeamInvite();
	}
}
