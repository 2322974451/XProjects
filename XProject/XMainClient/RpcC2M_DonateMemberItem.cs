using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DonateMemberItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 4241U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DonateMemberItemArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DonateMemberItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DonateMemberItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DonateMemberItem.OnTimeout(this.oArg);
		}

		public DonateMemberItemArg oArg = new DonateMemberItemArg();

		public DonateMemberItemRes oRes = null;
	}
}
