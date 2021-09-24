using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ModifyDragonGuildName : Rpc
	{

		public override uint GetRpcType()
		{
			return 10624U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ModifyDragonGuildNameArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ModifyDragonGuildNameRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ModifyDragonGuildName.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ModifyDragonGuildName.OnTimeout(this.oArg);
		}

		public ModifyDragonGuildNameArg oArg = new ModifyDragonGuildNameArg();

		public ModifyDragonGuildNameRes oRes = null;
	}
}
