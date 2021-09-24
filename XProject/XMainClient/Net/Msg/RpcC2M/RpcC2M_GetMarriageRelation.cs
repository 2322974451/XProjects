using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMarriageRelation : Rpc
	{

		public override uint GetRpcType()
		{
			return 13460U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMarriageRelationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMarriageRelationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMarriageRelation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMarriageRelation.OnTimeout(this.oArg);
		}

		public GetMarriageRelationArg oArg = new GetMarriageRelationArg();

		public GetMarriageRelationRes oRes = null;
	}
}
