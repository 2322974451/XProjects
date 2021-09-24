using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_EnterWeddingScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 30316U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterWeddingSceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterWeddingSceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_EnterWeddingScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_EnterWeddingScene.OnTimeout(this.oArg);
		}

		public EnterWeddingSceneArg oArg = new EnterWeddingSceneArg();

		public EnterWeddingSceneRes oRes = null;
	}
}
