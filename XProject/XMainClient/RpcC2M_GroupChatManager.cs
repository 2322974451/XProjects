using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatManager : Rpc
	{

		public override uint GetRpcType()
		{
			return 35391U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatManagerC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatManagerS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatManager.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatManager.OnTimeout(this.oArg);
		}

		public GroupChatManagerC2S oArg = new GroupChatManagerC2S();

		public GroupChatManagerS2C oRes = null;
	}
}
