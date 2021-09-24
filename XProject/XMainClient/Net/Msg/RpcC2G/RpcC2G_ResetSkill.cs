using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ResetSkill : Rpc
	{

		public override uint GetRpcType()
		{
			return 26941U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResetSkillArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResetSkillRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ResetSkill.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ResetSkill.OnTimeout(this.oArg);
		}

		public ResetSkillArg oArg = new ResetSkillArg();

		public ResetSkillRes oRes = new ResetSkillRes();
	}
}
