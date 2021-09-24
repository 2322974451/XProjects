using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_EnterLeisureScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 62361U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterLeisureSceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterLeisureSceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EnterLeisureScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EnterLeisureScene.OnTimeout(this.oArg);
		}

		public EnterLeisureSceneArg oArg = new EnterLeisureSceneArg();

		public EnterLeisureSceneRes oRes = null;
	}
}
