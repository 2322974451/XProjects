using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_MentorRelationOp : Rpc
	{

		public override uint GetRpcType()
		{
			return 10644U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MentorRelationOpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<MentorRelationOpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_MentorRelationOp.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_MentorRelationOp.OnTimeout(this.oArg);
		}

		public MentorRelationOpArg oArg = new MentorRelationOpArg();

		public MentorRelationOpRes oRes = null;
	}
}
