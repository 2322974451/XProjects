using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ChangeDragonGuildPosition : Rpc
	{

		public override uint GetRpcType()
		{
			return 3888U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeDragonGuildPositionArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeDragonGuildPositionRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeDragonGuildPosition.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeDragonGuildPosition.OnTimeout(this.oArg);
		}

		public ChangeDragonGuildPositionArg oArg = new ChangeDragonGuildPositionArg();

		public ChangeDragonGuildPositionRes oRes = null;
	}
}
