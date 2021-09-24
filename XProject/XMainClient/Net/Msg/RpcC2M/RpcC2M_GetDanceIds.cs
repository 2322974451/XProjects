using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDanceIds : Rpc
	{

		public override uint GetRpcType()
		{
			return 44768U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDanceIdsArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDanceIdsRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDanceIds.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDanceIds.OnTimeout(this.oArg);
		}

		public GetDanceIdsArg oArg = new GetDanceIdsArg();

		public GetDanceIdsRes oRes = null;
	}
}
