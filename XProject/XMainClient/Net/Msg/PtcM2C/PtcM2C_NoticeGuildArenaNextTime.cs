using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildArenaNextTime : Protocol
	{

		public override uint GetProtoType()
		{
			return 21612U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildArenaNextTime>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildArenaNextTime>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildArenaNextTime.Process(this);
		}

		public NoticeGuildArenaNextTime Data = new NoticeGuildArenaNextTime();
	}
}
