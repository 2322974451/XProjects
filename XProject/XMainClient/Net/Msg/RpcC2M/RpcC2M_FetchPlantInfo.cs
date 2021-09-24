using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchPlantInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 19949U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchPlantInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchPlantInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchPlantInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchPlantInfo.OnTimeout(this.oArg);
		}

		public FetchPlantInfoArg oArg = new FetchPlantInfoArg();

		public FetchPlantInfoRes oRes = null;
	}
}
