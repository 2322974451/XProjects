using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DoodadItemAllSkillReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 21002U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EmptyData>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DoodadItemAllSkill>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DoodadItemAllSkillReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DoodadItemAllSkillReq.OnTimeout(this.oArg);
		}

		public EmptyData oArg = new EmptyData();

		public DoodadItemAllSkill oRes = null;
	}
}
