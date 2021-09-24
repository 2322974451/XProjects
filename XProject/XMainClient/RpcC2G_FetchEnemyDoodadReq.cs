using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FetchEnemyDoodadReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 56348U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnemyDoodadInfo>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RollInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FetchEnemyDoodadReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FetchEnemyDoodadReq.OnTimeout(this.oArg);
		}

		public EnemyDoodadInfo oArg = new EnemyDoodadInfo();

		public RollInfoRes oRes = new RollInfoRes();
	}
}
