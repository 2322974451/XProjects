using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GardenCookingFood : Rpc
	{

		public override uint GetRpcType()
		{
			return 31406U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GardenCookingFoodArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GardenCookingFoodRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GardenCookingFood.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GardenCookingFood.OnTimeout(this.oArg);
		}

		public GardenCookingFoodArg oArg = new GardenCookingFoodArg();

		public GardenCookingFoodRes oRes = null;
	}
}
