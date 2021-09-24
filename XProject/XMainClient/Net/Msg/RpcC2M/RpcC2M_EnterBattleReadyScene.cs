using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_EnterBattleReadyScene : Rpc
	{

		public override uint GetRpcType()
		{
			return 55233U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EnterBattleReadySceneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EnterBattleReadySceneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_EnterBattleReadyScene.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_EnterBattleReadyScene.OnTimeout(this.oArg);
		}

		public EnterBattleReadySceneArg oArg = new EnterBattleReadySceneArg();

		public EnterBattleReadySceneRes oRes = null;
	}
}
