using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatFindRoleInfoList : Rpc
	{

		public override uint GetRpcType()
		{
			return 7283U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatFindRoleInfoListC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatFindRoleInfoListS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatFindRoleInfoList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatFindRoleInfoList.OnTimeout(this.oArg);
		}

		public GroupChatFindRoleInfoListC2S oArg = new GroupChatFindRoleInfoListC2S();

		public GroupChatFindRoleInfoListS2C oRes = null;
	}
}
