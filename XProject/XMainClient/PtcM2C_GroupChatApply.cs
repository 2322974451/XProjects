using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_GroupChatApply : Protocol
	{

		public override uint GetProtoType()
		{
			return 34424U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatApplyNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<GroupChatApplyNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_GroupChatApply.Process(this);
		}

		public GroupChatApplyNtf Data = new GroupChatApplyNtf();
	}
}
