using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetMyRiftInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 31519U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyRiftInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyRiftInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetMyRiftInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetMyRiftInfo.OnTimeout(this.oArg);
		}

		public GetMyRiftInfoArg oArg = new GetMyRiftInfoArg();

		public GetMyRiftInfoRes oRes = null;
	}
}
