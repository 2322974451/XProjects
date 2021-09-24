using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NotifySkyTeamCreate : Protocol
	{

		public override uint GetProtoType()
		{
			return 21688U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NotifySkyTeamCreate>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NotifySkyTeamCreate>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NotifySkyTeamCreate.Process(this);
		}

		public NotifySkyTeamCreate Data = new NotifySkyTeamCreate();
	}
}
