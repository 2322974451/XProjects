using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetMyApplyStudentInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 28961U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyApplyStudentInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyApplyStudentInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMyApplyStudentInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMyApplyStudentInfo.OnTimeout(this.oArg);
		}

		public GetMyApplyStudentInfoArg oArg = new GetMyApplyStudentInfoArg();

		public GetMyApplyStudentInfoRes oRes = null;
	}
}
