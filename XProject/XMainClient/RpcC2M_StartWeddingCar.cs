using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_StartWeddingCar : Rpc
	{

		public override uint GetRpcType()
		{
			return 26388U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartWeddingCarArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StartWeddingCarRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StartWeddingCar.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StartWeddingCar.OnTimeout(this.oArg);
		}

		public StartWeddingCarArg oArg = new StartWeddingCarArg();

		public StartWeddingCarRes oRes = null;
	}
}
