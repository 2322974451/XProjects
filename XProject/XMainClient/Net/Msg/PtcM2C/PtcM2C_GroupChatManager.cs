using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GroupChatManager : Protocol
	{

		public override uint GetProtoType()
		{
			return 17710U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatManagerPtc>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatManagerPtc>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GroupChatManager.Process(this);
		}

		public GroupChatManagerPtc Data = new GroupChatManagerPtc();
	}
}
