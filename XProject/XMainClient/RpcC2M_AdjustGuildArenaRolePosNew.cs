using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AdjustGuildArenaRolePosNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 57124U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AdjustGuildArenaRolePosArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AdjustGuildArenaRolePosRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AdjustGuildArenaRolePosNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AdjustGuildArenaRolePosNew.OnTimeout(this.oArg);
		}

		public AdjustGuildArenaRolePosArg oArg = new AdjustGuildArenaRolePosArg();

		public AdjustGuildArenaRolePosRes oRes = null;
	}
}
