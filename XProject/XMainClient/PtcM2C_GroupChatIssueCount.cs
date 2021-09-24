using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GroupChatIssueCount : Protocol
	{

		public override uint GetProtoType()
		{
			return 61968U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatIssueCountNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatIssueCountNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GroupChatIssueCount.Process(this);
		}

		public GroupChatIssueCountNtf Data = new GroupChatIssueCountNtf();
	}
}
