using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GroupChatQuit : Protocol
	{

		public override uint GetProtoType()
		{
			return 56654U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatQuitPtc>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatQuitPtc>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GroupChatQuit.Process(this);
		}

		public GroupChatQuitPtc Data = new GroupChatQuitPtc();
	}
}
