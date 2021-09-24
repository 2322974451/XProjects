using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2T_Reconnect : Rpc
	{

		public override uint GetRpcType()
		{
			return 28358U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReconnArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReconnRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2T_Reconnect.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2T_Reconnect.OnTimeout(this.oArg);
		}

		public ReconnArg oArg = new ReconnArg();

		public ReconnRes oRes = new ReconnRes();
	}
}
