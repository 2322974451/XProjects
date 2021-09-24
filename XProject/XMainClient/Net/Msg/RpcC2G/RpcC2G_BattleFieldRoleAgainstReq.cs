using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BattleFieldRoleAgainstReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 12475U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BattleFieldRoleAgainstArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BattleFieldRoleAgainst>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BattleFieldRoleAgainstReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BattleFieldRoleAgainstReq.OnTimeout(this.oArg);
		}

		public BattleFieldRoleAgainstArg oArg = new BattleFieldRoleAgainstArg();

		public BattleFieldRoleAgainst oRes = null;
	}
}
