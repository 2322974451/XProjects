using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PetOperationOther : Rpc
	{

		public override uint GetRpcType()
		{
			return 58525U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PetOperationOtherArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PetOperationOtherRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PetOperationOther.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PetOperationOther.OnTimeout(this.oArg);
		}

		public PetOperationOtherArg oArg = new PetOperationOtherArg();

		public PetOperationOtherRes oRes = null;
	}
}
