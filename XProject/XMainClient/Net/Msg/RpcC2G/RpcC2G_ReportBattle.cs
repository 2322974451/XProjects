using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReportBattle : Rpc
	{

		public override uint GetRpcType()
		{
			return 21292U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReportBattleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReportBattleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReportBattle.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReportBattle.OnTimeout(this.oArg);
		}

		public ReportBattleArg oArg = new ReportBattleArg();

		public ReportBattleRes oRes = new ReportBattleRes();
	}
}
