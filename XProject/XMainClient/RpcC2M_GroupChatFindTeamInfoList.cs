using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatFindTeamInfoList : Rpc
	{

		public override uint GetRpcType()
		{
			return 46399U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatFindTeamInfoListC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatFindTeamInfoListS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatFindTeamInfoList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatFindTeamInfoList.OnTimeout(this.oArg);
		}

		public GroupChatFindTeamInfoListC2S oArg = new GroupChatFindTeamInfoListC2S();

		public GroupChatFindTeamInfoListS2C oRes = null;
	}
}
