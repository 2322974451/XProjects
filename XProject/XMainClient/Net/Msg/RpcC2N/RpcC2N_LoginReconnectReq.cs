using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2N_LoginReconnectReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 25422U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginReconnectReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LoginReconnectReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2N_LoginReconnectReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2N_LoginReconnectReq.OnTimeout(this.oArg);
		}

		public LoginReconnectReqArg oArg = new LoginReconnectReqArg();

		public LoginReconnectReqRes oRes = null;
	}
}
