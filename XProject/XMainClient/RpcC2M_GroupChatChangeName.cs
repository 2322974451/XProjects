using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatChangeName : Rpc
	{

		public override uint GetRpcType()
		{
			return 44170U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatChangeNameC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatChangeNameS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatChangeName.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatChangeName.OnTimeout(this.oArg);
		}

		public GroupChatChangeNameC2S oArg = new GroupChatChangeNameC2S();

		public GroupChatChangeNameS2C oRes = null;
	}
}
