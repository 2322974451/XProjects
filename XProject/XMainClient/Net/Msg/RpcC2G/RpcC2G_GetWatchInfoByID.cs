using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetWatchInfoByID : Rpc
	{

		public override uint GetRpcType()
		{
			return 45635U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWatchInfoByIDArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWatchInfoByIDRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetWatchInfoByID.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetWatchInfoByID.OnTimeout(this.oArg);
		}

		public GetWatchInfoByIDArg oArg = new GetWatchInfoByIDArg();

		public GetWatchInfoByIDRes oRes = new GetWatchInfoByIDRes();
	}
}
