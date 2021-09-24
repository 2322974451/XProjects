using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatCreate : Rpc
	{

		public override uint GetRpcType()
		{
			return 59293U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatCreateC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatCreateS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatCreate.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatCreate.OnTimeout(this.oArg);
		}

		public GroupChatCreateC2S oArg = new GroupChatCreateC2S();

		public GroupChatCreateS2C oRes = null;
	}
}
