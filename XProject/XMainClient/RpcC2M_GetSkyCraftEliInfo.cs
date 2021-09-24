using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetSkyCraftEliInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 41103U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetSkyCraftEliInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetSkyCraftEliInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetSkyCraftEliInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetSkyCraftEliInfo.OnTimeout(this.oArg);
		}

		public GetSkyCraftEliInfoArg oArg = new GetSkyCraftEliInfoArg();

		public GetSkyCraftEliInfoRes oRes = null;
	}
}
