using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_InvFightReqAll : Rpc
	{

		public override uint GetRpcType()
		{
			return 56726U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<InvFightRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_InvFightReqAll.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_InvFightReqAll.OnTimeout(this.oArg);
		}

		public InvFightArg oArg = new InvFightArg();

		public InvFightRes oRes = null;
	}
}
