using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReturnToSelectRole : Rpc
	{

		public override uint GetRpcType()
		{
			return 25477U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReturnToSelectRoleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReturnToSelectRoleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReturnToSelectRole.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReturnToSelectRole.OnTimeout(this.oArg);
		}

		public ReturnToSelectRoleArg oArg = new ReturnToSelectRoleArg();

		public ReturnToSelectRoleRes oRes = null;
	}
}
