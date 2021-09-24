using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_Revive : Rpc
	{

		public override uint GetRpcType()
		{
			return 29831U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReviveArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReviveRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Revive.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Revive.OnTimeout(this.oArg);
		}

		public ReviveArg oArg = new ReviveArg();

		public ReviveRes oRes = new ReviveRes();
	}
}
