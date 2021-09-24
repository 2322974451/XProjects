using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_OpenPrivateChatNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 23206U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenPrivateChat>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<OpenPrivateChat>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public OpenPrivateChat Data = new OpenPrivateChat();
	}
}
