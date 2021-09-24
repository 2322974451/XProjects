using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_OpenGuildQAReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 62840U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<OpenGuildQAReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<OpenGuildQARes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_OpenGuildQAReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_OpenGuildQAReq.OnTimeout(this.oArg);
		}

		public OpenGuildQAReq oArg = new OpenGuildQAReq();

		public OpenGuildQARes oRes = new OpenGuildQARes();
	}
}
