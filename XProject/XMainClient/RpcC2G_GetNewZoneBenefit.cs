using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetNewZoneBenefit : Rpc
	{

		public override uint GetRpcType()
		{
			return 17236U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetNewZoneBenefitArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetNewZoneBenefitRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetNewZoneBenefit.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetNewZoneBenefit.OnTimeout(this.oArg);
		}

		public GetNewZoneBenefitArg oArg = new GetNewZoneBenefitArg();

		public GetNewZoneBenefitRes oRes = null;
	}
}
