using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_CustomBattleOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 12314U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CustomBattleOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CustomBattleOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CustomBattleOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CustomBattleOp.OnTimeout(this.oArg);
		}

		public CustomBattleOpArg oArg = new CustomBattleOpArg();

		public CustomBattleOpRes oRes = null;
	}
}
