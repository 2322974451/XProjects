using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ModifyMsGuildName : Rpc
	{

		public override uint GetRpcType()
		{
			return 21709U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ModifyArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ModifyRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ModifyMsGuildName.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ModifyMsGuildName.OnTimeout(this.oArg);
		}

		public ModifyArg oArg = new ModifyArg();

		public ModifyRes oRes = null;
	}
}
