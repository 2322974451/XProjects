using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_AbsEnterScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 23463U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AbsEnterSceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AbsEnterSceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AbsEnterScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AbsEnterScene.OnTimeout(this.oArg);
		}

		public AbsEnterSceneArg oArg = new AbsEnterSceneArg();

		public AbsEnterSceneRes oRes = null;
	}
}
