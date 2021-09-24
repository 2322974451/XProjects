using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ChatNotifyG2C : Protocol
	{

		public override uint GetProtoType()
		{
			return 48111U;
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
			Process_PtcG2C_ChatNotifyG2C.Process(this);
		}

		public ChatNotify Data = new ChatNotify();
	}
}
