using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_JustDance : Rpc
	{

		public override uint GetRpcType()
		{
			return 43613U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JustDanceArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JustDanceRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JustDance.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JustDance.OnTimeout(this.oArg);
		}

		public JustDanceArg oArg = new JustDanceArg();

		public JustDanceRes oRes = new JustDanceRes();
	}
}
