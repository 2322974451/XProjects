using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetSkyCraftInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 26199U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftInfo.OnTimeout(this.oArg);
		}

		public GetSkyCraftInfoArg oArg = new GetSkyCraftInfoArg();

		public GetSkyCraftInfoRes oRes = null;
	}
}
