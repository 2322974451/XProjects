using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenBanquet : Rpc
	{

		public override uint GetRpcType()
		{
			return 22527U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenBanquetArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenBanquetRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenBanquet.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenBanquet.OnTimeout(this.oArg);
		}

		public GardenBanquetArg oArg = new GardenBanquetArg();

		public GardenBanquetRes oRes = null;
	}
}
