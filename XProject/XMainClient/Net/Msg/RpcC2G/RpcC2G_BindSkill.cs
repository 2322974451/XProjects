using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BindSkill : Rpc
	{

		public override uint GetRpcType()
		{
			return 48236U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BingSkillArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BindSkillRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BindSkill.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BindSkill.OnTimeout(this.oArg);
		}

		public BingSkillArg oArg = new BingSkillArg();

		public BindSkillRes oRes = new BindSkillRes();
	}
}
