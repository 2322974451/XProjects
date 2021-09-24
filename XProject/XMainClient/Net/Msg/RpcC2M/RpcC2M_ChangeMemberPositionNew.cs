using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ChangeMemberPositionNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 13625U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeGuildPositionArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeGuildPositionRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeMemberPositionNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeMemberPositionNew.OnTimeout(this.oArg);
		}

		public ChangeGuildPositionArg oArg = new ChangeGuildPositionArg();

		public ChangeGuildPositionRes oRes = null;
	}
}
