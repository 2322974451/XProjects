using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SynPetInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 6548U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SynPetInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SynPetInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SynPetInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SynPetInfo.OnTimeout(this.oArg);
		}

		public SynPetInfoArg oArg = new SynPetInfoArg();

		public SynPetInfoRes oRes = new SynPetInfoRes();
	}
}
