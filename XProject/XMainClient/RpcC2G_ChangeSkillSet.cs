using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeSkillSet : Rpc
	{

		public override uint GetRpcType()
		{
			return 51116U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeSkillSetArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeSkillSetRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeSkillSet.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeSkillSet.OnTimeout(this.oArg);
		}

		public ChangeSkillSetArg oArg = new ChangeSkillSetArg();

		public ChangeSkillSetRes oRes = null;
	}
}
