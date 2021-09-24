using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_FetchGuildApp : Rpc
	{

		public override uint GetRpcType()
		{
			return 3668U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchGAPPArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchGAPPRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_FetchGuildApp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_FetchGuildApp.OnTimeout(this.oArg);
		}

		public FetchGAPPArg oArg = new FetchGAPPArg();

		public FetchGAPPRes oRes = null;
	}
}
