using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_TeamInviteM2CNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 1221U;
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
			Process_PtcM2C_TeamInviteM2CNotify.Process(this);
		}

		public TeamInvite Data = new TeamInvite();
	}
}
