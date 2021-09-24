using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMarriageLiveness : Rpc
	{

		public override uint GetRpcType()
		{
			return 30055U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMarriageLivenessArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMarriageLivenessRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMarriageLiveness.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMarriageLiveness.OnTimeout(this.oArg);
		}

		public GetMarriageLivenessArg oArg = new GetMarriageLivenessArg();

		public GetMarriageLivenessRes oRes = null;
	}
}
