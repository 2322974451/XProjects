using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_AgreeQAReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 43200U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AgreeQAReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AgreeQARes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AgreeQAReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AgreeQAReq.OnTimeout(this.oArg);
		}

		public AgreeQAReq oArg = new AgreeQAReq();

		public AgreeQARes oRes = new AgreeQARes();
	}
}
