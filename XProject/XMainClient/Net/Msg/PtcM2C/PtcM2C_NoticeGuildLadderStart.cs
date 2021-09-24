using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildLadderStart : Protocol
	{

		public override uint GetProtoType()
		{
			return 49782U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildLadderStart>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildLadderStart>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildLadderStart.Process(this);
		}

		public NoticeGuildLadderStart Data = new NoticeGuildLadderStart();
	}
}
