using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_IdipClearChatNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 47934U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IdipClearChatInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<IdipClearChatInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_IdipClearChatNtf.Process(this);
		}

		public IdipClearChatInfo Data = new IdipClearChatInfo();
	}
}
