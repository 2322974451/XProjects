using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_NoticeHungryDown : Protocol
	{

		public override uint GetProtoType()
		{
			return 36895U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<NoticeHungryDown>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<NoticeHungryDown>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_NoticeHungryDown.Process(this);
		}

		public NoticeHungryDown Data = new NoticeHungryDown();
	}
}
