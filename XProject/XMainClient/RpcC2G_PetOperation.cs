using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PetOperation : Rpc
	{

		public override uint GetRpcType()
		{
			return 28857U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetOperationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PetOperationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PetOperation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PetOperation.OnTimeout(this.oArg);
		}

		public PetOperationArg oArg = new PetOperationArg();

		public PetOperationRes oRes = new PetOperationRes();
	}
}
