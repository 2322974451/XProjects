using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskGuildArenaInfoNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 24504U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildArenaInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildArenaInfoReq>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildArenaInfoNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildArenaInfoNew.OnTimeout(this.oArg);
		}

		public AskGuildArenaInfoArg oArg = new AskGuildArenaInfoArg();

		public AskGuildArenaInfoReq oRes = null;
	}
}
