using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildTerrAllianceInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 63044U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrAllianceInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrAllianceInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrAllianceInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrAllianceInfo.OnTimeout(this.oArg);
		}

		public ReqGuildTerrAllianceInfoArg oArg = new ReqGuildTerrAllianceInfoArg();

		public ReqGuildTerrAllianceInfoRes oRes = null;
	}
}
