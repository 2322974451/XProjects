using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GroupChatGetGroupInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 64081U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GroupChatGetGroupInfoC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GroupChatGetGroupInfoS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GroupChatGetGroupInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GroupChatGetGroupInfo.OnTimeout(this.oArg);
		}

		public GroupChatGetGroupInfoC2S oArg = new GroupChatGetGroupInfoC2S();

		public GroupChatGetGroupInfoS2C oRes = null;
	}
}
