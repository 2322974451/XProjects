using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_NoticeGuildWageReward : Protocol
	{

		public override uint GetProtoType()
		{
			return 29986U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeGuildWageReward>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeGuildWageReward>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_NoticeGuildWageReward.Process(this);
		}

		public NoticeGuildWageReward Data = new NoticeGuildWageReward();
	}
}
