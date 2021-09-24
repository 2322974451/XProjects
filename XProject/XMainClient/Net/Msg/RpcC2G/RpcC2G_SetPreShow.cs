using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SetPreShow : Rpc
	{

		public override uint GetRpcType()
		{
			return 346U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SetPreShowArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SetPreShowRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SetPreShow.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SetPreShow.OnTimeout(this.oArg);
		}

		public SetPreShowArg oArg = new SetPreShowArg();

		public SetPreShowRes oRes = null;
	}
}
