using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetTowerActivityTop : Rpc
	{

		public override uint GetRpcType()
		{
			return 5168U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetTowerActivityTopArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetTowerActivityTopRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetTowerActivityTop.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetTowerActivityTop.OnTimeout(this.oArg);
		}

		public GetTowerActivityTopArg oArg = new GetTowerActivityTopArg();

		public GetTowerActivityTopRes oRes = new GetTowerActivityTopRes();
	}
}
