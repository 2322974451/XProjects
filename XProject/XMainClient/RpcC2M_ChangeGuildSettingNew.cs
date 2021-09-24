using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ChangeGuildSettingNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 55897U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeGuildSettingArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeGuildSettingRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeGuildSettingNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeGuildSettingNew.OnTimeout(this.oArg);
		}

		public ChangeGuildSettingArg oArg = new ChangeGuildSettingArg();

		public ChangeGuildSettingRes oRes = null;
	}
}
