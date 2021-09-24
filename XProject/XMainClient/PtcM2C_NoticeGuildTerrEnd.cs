using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildTerrEnd : Protocol
	{

		public override uint GetProtoType()
		{
			return 2103U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildTerrEnd>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildTerrEnd>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildTerrEnd.Process(this);
		}

		public NoticeGuildTerrEnd Data = new NoticeGuildTerrEnd();
	}
}
