using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CheckRoleBeforePay : Rpc
	{

		public override uint GetRpcType()
		{
			return 56255U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CheckRoleBeforePayArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CheckRoleBeforePayRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CheckRoleBeforePay.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CheckRoleBeforePay.OnTimeout(this.oArg);
		}

		public CheckRoleBeforePayArg oArg = new CheckRoleBeforePayArg();

		public CheckRoleBeforePayRes oRes = null;
	}
}
