using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_StudyGuildSkillNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 45669U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<StudyGuildSkillArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<StudyGuildSkillRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_StudyGuildSkillNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_StudyGuildSkillNew.OnTimeout(this.oArg);
		}

		public StudyGuildSkillArg oArg = new StudyGuildSkillArg();

		public StudyGuildSkillRes oRes = null;
	}
}
