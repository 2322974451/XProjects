using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetLevelSealSelfGift : Rpc
	{

		public override uint GetRpcType()
		{
			return 61903U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetLevelSealSealGiftArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetLevelSealSelfGiftRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetLevelSealSelfGift.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetLevelSealSelfGift.OnTimeout(this.oArg);
		}

		public GetLevelSealSealGiftArg oArg = new GetLevelSealSealGiftArg();

		public GetLevelSealSelfGiftRes oRes = new GetLevelSealSelfGiftRes();
	}
}
