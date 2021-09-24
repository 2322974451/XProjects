using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ChangeDragonGuildSetting : Rpc
	{

		public override uint GetRpcType()
		{
			return 52505U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeDragonGuildSettingArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeDragonGuildSettingRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeDragonGuildSetting.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeDragonGuildSetting.OnTimeout(this.oArg);
		}

		public ChangeDragonGuildSettingArg oArg = new ChangeDragonGuildSettingArg();

		public ChangeDragonGuildSettingRes oRes = null;
	}
}
