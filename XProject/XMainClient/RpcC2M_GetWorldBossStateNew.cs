using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetWorldBossStateNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 17093U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWorldBossStateArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWorldBossStateRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetWorldBossStateNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetWorldBossStateNew.OnTimeout(this.oArg);
		}

		public GetWorldBossStateArg oArg = new GetWorldBossStateArg();

		public GetWorldBossStateRes oRes = null;
	}
}
