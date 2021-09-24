using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChooseRollReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 50047U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChooseRollReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChooseRollReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChooseRollReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChooseRollReq.OnTimeout(this.oArg);
		}

		public ChooseRollReqArg oArg = new ChooseRollReqArg();

		public ChooseRollReqRes oRes = new ChooseRollReqRes();
	}
}
