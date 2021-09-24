using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_TactEnterScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 27599U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TactEnterSceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TactEnterSceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TactEnterScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TactEnterScene.OnTimeout(this.oArg);
		}

		public TactEnterSceneArg oArg = new TactEnterSceneArg();

		public TactEnterSceneRes oRes = null;
	}
}
