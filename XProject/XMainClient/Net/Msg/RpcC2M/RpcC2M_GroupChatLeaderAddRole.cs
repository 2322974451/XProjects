using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatLeaderAddRole : Rpc
	{

		public override uint GetRpcType()
		{
			return 44703U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatLeaderAddRoleC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatLeaderAddRoleS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatLeaderAddRole.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatLeaderAddRole.OnTimeout(this.oArg);
		}

		public GroupChatLeaderAddRoleC2S oArg = new GroupChatLeaderAddRoleC2S();

		public GroupChatLeaderAddRoleS2C oRes = null;
	}
}
