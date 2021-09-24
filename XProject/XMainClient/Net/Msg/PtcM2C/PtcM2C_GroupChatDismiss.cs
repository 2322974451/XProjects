using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GroupChatDismiss : Protocol
	{

		public override uint GetProtoType()
		{
			return 18973U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatDismissPtc>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatDismissPtc>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GroupChatDismiss.Process(this);
		}

		public GroupChatDismissPtc Data = new GroupChatDismissPtc();
	}
}
