using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenBanquetAward : Rpc
	{

		public override uint GetRpcType()
		{
			return 1091U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BanquetAwardArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BanquetAwardRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenBanquetAward.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenBanquetAward.OnTimeout(this.oArg);
		}

		public BanquetAwardArg oArg = new BanquetAwardArg();

		public BanquetAwardRes oRes = null;
	}
}
