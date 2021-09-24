using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMyApplyMasterInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 61902U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyApplyMasterInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyApplyMasterInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMyApplyMasterInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMyApplyMasterInfo.OnTimeout(this.oArg);
		}

		public GetMyApplyMasterInfoArg oArg = new GetMyApplyMasterInfoArg();

		public GetMyApplyMasterInfoRes oRes = null;
	}
}
