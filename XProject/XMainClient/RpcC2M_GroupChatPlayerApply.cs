using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatPlayerApply : Rpc
	{

		public override uint GetRpcType()
		{
			return 24788U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatPlayerApplyC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatPlayerApplyS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatPlayerApply.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatPlayerApply.OnTimeout(this.oArg);
		}

		public GroupChatPlayerApplyC2S oArg = new GroupChatPlayerApplyC2S();

		public GroupChatPlayerApplyS2C oRes = null;
	}
}
