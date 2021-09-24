using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetListSubscribe : Rpc
	{

		public override uint GetRpcType()
		{
			return 1403U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetListSubscribeArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetListSubscribeRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetListSubscribe.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetListSubscribe.OnTimeout(this.oArg);
		}

		public GetListSubscribeArg oArg = new GetListSubscribeArg();

		public GetListSubscribeRes oRes = null;
	}
}
