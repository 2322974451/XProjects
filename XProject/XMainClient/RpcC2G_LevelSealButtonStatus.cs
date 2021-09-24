using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_LevelSealButtonStatus : Rpc
	{

		public override uint GetRpcType()
		{
			return 10396U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelSealOverExpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LevelSealOverExpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LevelSealButtonStatus.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LevelSealButtonStatus.OnTimeout(this.oArg);
		}

		public LevelSealOverExpArg oArg = new LevelSealOverExpArg();

		public LevelSealOverExpRes oRes = new LevelSealOverExpRes();
	}
}
