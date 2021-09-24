using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NoticeDoingGuildInherit : Protocol
	{

		public override uint GetProtoType()
		{
			return 61639U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeDoingGuildInherit>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeDoingGuildInherit>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NoticeDoingGuildInherit.Process(this);
		}

		public NoticeDoingGuildInherit Data = new NoticeDoingGuildInherit();
	}
}
