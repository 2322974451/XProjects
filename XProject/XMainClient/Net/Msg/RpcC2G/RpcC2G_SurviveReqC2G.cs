using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SurviveReqC2G : Rpc
	{

		public override uint GetRpcType()
		{
			return 19408U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SurviveReqArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SurviveReqRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SurviveReqC2G.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SurviveReqC2G.OnTimeout(this.oArg);
		}

		public SurviveReqArg oArg = new SurviveReqArg();

		public SurviveReqRes oRes = null;
	}
}
