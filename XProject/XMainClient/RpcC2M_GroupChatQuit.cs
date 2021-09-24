using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatQuit : Rpc
	{

		public override uint GetRpcType()
		{
			return 58833U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatQuitC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatQuitS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatQuit.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatQuit.OnTimeout(this.oArg);
		}

		public GroupChatQuitC2S oArg = new GroupChatQuitC2S();

		public GroupChatQuitS2C oRes = null;
	}
}
