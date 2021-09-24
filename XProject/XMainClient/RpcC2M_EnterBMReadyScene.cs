using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_EnterBMReadyScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 24371U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterBMReadySceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterBMReadySceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_EnterBMReadyScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_EnterBMReadyScene.OnTimeout(this.oArg);
		}

		public EnterBMReadySceneArg oArg = new EnterBMReadySceneArg();

		public EnterBMReadySceneRes oRes = null;
	}
}
