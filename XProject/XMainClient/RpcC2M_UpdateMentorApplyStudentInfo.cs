using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013D8 RID: 5080
	internal class RpcC2M_UpdateMentorApplyStudentInfo : Rpc
	{
		// Token: 0x0600E45D RID: 58461 RVA: 0x0033BA30 File Offset: 0x00339C30
		public override uint GetRpcType()
		{
			return 55126U;
		}

		// Token: 0x0600E45E RID: 58462 RVA: 0x0033BA47 File Offset: 0x00339C47
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateMentorApplyStudentInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E45F RID: 58463 RVA: 0x0033BA57 File Offset: 0x00339C57
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UpdateMentorApplyStudentInfoRes>(stream);
		}

		// Token: 0x0600E460 RID: 58464 RVA: 0x0033BA66 File Offset: 0x00339C66
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_UpdateMentorApplyStudentInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E461 RID: 58465 RVA: 0x0033BA82 File Offset: 0x00339C82
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_UpdateMentorApplyStudentInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400641B RID: 25627
		public UpdateMentorApplyStudentInfoArg oArg = new UpdateMentorApplyStudentInfoArg();

		// Token: 0x0400641C RID: 25628
		public UpdateMentorApplyStudentInfoRes oRes = null;
	}
}
