using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatClear : Rpc
	{

		public override uint GetRpcType()
		{
			return 61477U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatClearC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatClearS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatClear.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatClear.OnTimeout(this.oArg);
		}

		public GroupChatClearC2S oArg = new GroupChatClearC2S();

		public GroupChatClearS2C oRes = null;
	}
}
