using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcT2C_ChatNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 4256U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChatNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcT2C_ChatNotify.Process(this);
		}

		public ChatNotify Data = new ChatNotify();
	}
}
