using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetDragonTopInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 7973U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonTopInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonTopInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetDragonTopInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetDragonTopInfo.OnTimeout(this.oArg);
		}

		public GetDragonTopInfoArg oArg = new GetDragonTopInfoArg();

		public GetDragonTopInfoRes oRes = new GetDragonTopInfoRes();
	}
}
