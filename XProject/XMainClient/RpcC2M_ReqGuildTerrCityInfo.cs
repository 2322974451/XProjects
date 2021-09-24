using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ReqGuildTerrCityInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 47229U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReqGuildTerrCityInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReqGuildTerrCityInfo>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ReqGuildTerrCityInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ReqGuildTerrCityInfo.OnTimeout(this.oArg);
		}

		public ReqGuildTerrCityInfoArg oArg = new ReqGuildTerrCityInfoArg();

		public ReqGuildTerrCityInfo oRes = null;
	}
}
