using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_StageCountReset : Rpc
	{

		public override uint GetRpcType()
		{
			return 8496U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StageCountResetArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StageCountResetRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_StageCountReset.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_StageCountReset.OnTimeout(this.oArg);
		}

		public StageCountResetArg oArg = new StageCountResetArg();

		public StageCountResetRes oRes = new StageCountResetRes();
	}
}
