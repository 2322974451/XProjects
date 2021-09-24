using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_MarriageRelationOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 24966U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MarriageRelationOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MarriageRelationOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MarriageRelationOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MarriageRelationOp.OnTimeout(this.oArg);
		}

		public MarriageRelationOpArg oArg = new MarriageRelationOpArg();

		public MarriageRelationOpRes oRes = null;
	}
}
