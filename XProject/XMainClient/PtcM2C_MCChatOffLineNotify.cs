using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_MCChatOffLineNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 35008U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChatOfflineNotify>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChatOfflineNotify>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_MCChatOffLineNotify.Process(this);
		}

		public ChatOfflineNotify Data = new ChatOfflineNotify();
	}
}
