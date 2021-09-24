using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SkillLevelup : Rpc
	{

		public override uint GetRpcType()
		{
			return 63698U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkillLevelupArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkillLevelupRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SkillLevelup.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SkillLevelup.OnTimeout(this.oArg);
		}

		public SkillLevelupArg oArg = new SkillLevelupArg();

		public SkillLevelupRes oRes = null;
	}
}
