using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_UpdateMentorApplyStudentInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 55126U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateMentorApplyStudentInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UpdateMentorApplyStudentInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_UpdateMentorApplyStudentInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_UpdateMentorApplyStudentInfo.OnTimeout(this.oArg);
		}

		public UpdateMentorApplyStudentInfoArg oArg = new UpdateMentorApplyStudentInfoArg();

		public UpdateMentorApplyStudentInfoRes oRes = null;
	}
}
