using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_HoldWedding : Rpc
	{

		public override uint GetRpcType()
		{
			return 51875U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HoldWeddingReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<HoldWeddingRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_HoldWedding.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_HoldWedding.OnTimeout(this.oArg);
		}

		public HoldWeddingReq oArg = new HoldWeddingReq();

		public HoldWeddingRes oRes = null;
	}
}
