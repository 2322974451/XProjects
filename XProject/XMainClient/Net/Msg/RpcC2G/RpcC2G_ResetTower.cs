using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ResetTower : Rpc
	{

		public override uint GetRpcType()
		{
			return 8570U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResetTowerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResetTowerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResetTower.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResetTower.OnTimeout(this.oArg);
		}

		public ResetTowerArg oArg = new ResetTowerArg();

		public ResetTowerRes oRes = new ResetTowerRes();
	}
}
