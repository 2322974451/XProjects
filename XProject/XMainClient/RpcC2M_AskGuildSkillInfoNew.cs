using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_AskGuildSkillInfoNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 35479U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AskGuildSkillInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AskGuildSkillInfoReq>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AskGuildSkillInfoNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AskGuildSkillInfoNew.OnTimeout(this.oArg);
		}

		public AskGuildSkillInfoArg oArg = new AskGuildSkillInfoArg();

		public AskGuildSkillInfoReq oRes = null;
	}
}
