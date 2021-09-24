using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_TeamRequestPlatFreind2Client : Protocol
	{

		public override uint GetProtoType()
		{
			return 37841U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TeamRequestPlatFreind2ClientData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<TeamRequestPlatFreind2ClientData>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_TeamRequestPlatFreind2Client.Process(this);
		}

		public TeamRequestPlatFreind2ClientData Data = new TeamRequestPlatFreind2ClientData();
	}
}
