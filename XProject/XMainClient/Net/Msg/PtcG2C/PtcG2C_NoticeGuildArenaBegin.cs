using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NoticeGuildArenaBegin : Protocol
	{

		public override uint GetProtoType()
		{
			return 11695U;
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
			Process_PtcG2C_NoticeGuildArenaBegin.Process(this);
		}

		public NoticeGuildArenaBegin Data = new NoticeGuildArenaBegin();
	}
}
