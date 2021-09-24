using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_OPenGardenFarmland : Rpc
	{

		public override uint GetRpcType()
		{
			return 42589U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenGardenFarmlandArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<OpenGardenFarmlandRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_OPenGardenFarmland.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_OPenGardenFarmland.OnTimeout(this.oArg);
		}

		public OpenGardenFarmlandArg oArg = new OpenGardenFarmlandArg();

		public OpenGardenFarmlandRes oRes = null;
	}
}
