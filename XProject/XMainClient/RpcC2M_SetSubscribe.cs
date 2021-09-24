using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_SetSubscribe : Rpc
	{

		public override uint GetRpcType()
		{
			return 40540U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetSubscirbeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetSubscribeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SetSubscribe.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SetSubscribe.OnTimeout(this.oArg);
		}

		public SetSubscirbeArg oArg = new SetSubscirbeArg();

		public SetSubscribeRes oRes = null;
	}
}
