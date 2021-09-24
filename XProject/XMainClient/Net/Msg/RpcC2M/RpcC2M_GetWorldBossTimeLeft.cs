using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetWorldBossTimeLeft : Rpc
	{

		public override uint GetRpcType()
		{
			return 23195U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetWorldBossTimeLeftArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetWorldBossTimeLeftRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetWorldBossTimeLeft.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetWorldBossTimeLeft.OnTimeout(this.oArg);
		}

		public GetWorldBossTimeLeftArg oArg = new GetWorldBossTimeLeftArg();

		public GetWorldBossTimeLeftRes oRes = null;
	}
}
