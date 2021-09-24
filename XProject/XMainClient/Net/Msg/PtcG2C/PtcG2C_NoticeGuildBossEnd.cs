using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NoticeGuildBossEnd : Protocol
	{

		public override uint GetProtoType()
		{
			return 34184U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildBossEnd>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildBossEnd>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NoticeGuildBossEnd.Process(this);
		}

		public NoticeGuildBossEnd Data = new NoticeGuildBossEnd();
	}
}
