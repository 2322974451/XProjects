using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SceneMobaOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 32594U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SceneMobaOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SceneMobaOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SceneMobaOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SceneMobaOp.OnTimeout(this.oArg);
		}

		public SceneMobaOpArg oArg = new SceneMobaOpArg();

		public SceneMobaOpRes oRes = null;
	}
}
