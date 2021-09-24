using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildArenaBeginNew : Protocol
	{

		public override uint GetProtoType()
		{
			return 12290U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildArenaBegin>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildArenaBegin>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildArenaBeginNew.Process(this);
		}

		public NoticeGuildArenaBegin Data = new NoticeGuildArenaBegin();
	}
}
