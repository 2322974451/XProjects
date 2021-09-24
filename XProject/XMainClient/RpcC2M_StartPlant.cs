using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_StartPlant : Rpc
	{

		public override uint GetRpcType()
		{
			return 2834U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StartPlantArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StartPlantRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StartPlant.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StartPlant.OnTimeout(this.oArg);
		}

		public StartPlantArg oArg = new StartPlantArg();

		public StartPlantRes oRes = null;
	}
}
