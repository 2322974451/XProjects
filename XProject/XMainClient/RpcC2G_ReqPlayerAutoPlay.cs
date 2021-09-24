using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReqPlayerAutoPlay : Rpc
	{

		public override uint GetRpcType()
		{
			return 3718U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqAutoPlay>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RetAutoPlay>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReqPlayerAutoPlay.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReqPlayerAutoPlay.OnTimeout(this.oArg);
		}

		public ReqAutoPlay oArg = new ReqAutoPlay();

		public RetAutoPlay oRes = new RetAutoPlay();
	}
}
