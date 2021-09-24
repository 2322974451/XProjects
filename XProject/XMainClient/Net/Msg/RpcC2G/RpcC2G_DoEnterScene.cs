using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DoEnterScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 45201U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DoEnterSceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DoEnterSceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DoEnterScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DoEnterScene.OnTimeout(this.oArg);
		}

		public DoEnterSceneArg oArg = new DoEnterSceneArg();

		public DoEnterSceneRes oRes = new DoEnterSceneRes();
	}
}
