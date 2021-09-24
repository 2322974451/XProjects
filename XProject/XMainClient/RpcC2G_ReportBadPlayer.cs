using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReportBadPlayer : Rpc
	{

		public override uint GetRpcType()
		{
			return 32807U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReportBadPlayerArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReportBadPlayerRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReportBadPlayer.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReportBadPlayer.OnTimeout(this.oArg);
		}

		public ReportBadPlayerArg oArg = new ReportBadPlayerArg();

		public ReportBadPlayerRes oRes = null;
	}
}
