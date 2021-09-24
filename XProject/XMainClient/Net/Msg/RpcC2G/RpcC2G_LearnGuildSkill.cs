using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_LearnGuildSkill : Rpc
	{

		public override uint GetRpcType()
		{
			return 62806U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LearnGuildSkillAgr>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LearnGuildSkillRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LearnGuildSkill.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LearnGuildSkill.OnTimeout(this.oArg);
		}

		public LearnGuildSkillAgr oArg = new LearnGuildSkillAgr();

		public LearnGuildSkillRes oRes = new LearnGuildSkillRes();
	}
}
