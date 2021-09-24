using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2T_ClientLoginRequest : Rpc
	{

		public override uint GetRpcType()
		{
			return 10091U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoginArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LoginRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2T_ClientLoginRequest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2T_ClientLoginRequest.OnTimeout(this.oArg);
		}

		public LoginArg oArg = new LoginArg();

		public LoginRes oRes = new LoginRes();
	}
}
