using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetCrossGvgData : Rpc
	{

		public override uint GetRpcType()
		{
			return 47019U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetCrossGvgDataArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetCrossGvgDataRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetCrossGvgData.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetCrossGvgData.OnTimeout(this.oArg);
		}

		public GetCrossGvgDataArg oArg = new GetCrossGvgDataArg();

		public GetCrossGvgDataRes oRes = null;
	}
}
