using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_RemoveBlackListNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 38702U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<RemoveBlackListArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<RemoveBlackListRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_RemoveBlackListNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_RemoveBlackListNew.OnTimeout(this.oArg);
		}

		public RemoveBlackListArg oArg = new RemoveBlackListArg();

		public RemoveBlackListRes oRes = null;
	}
}
