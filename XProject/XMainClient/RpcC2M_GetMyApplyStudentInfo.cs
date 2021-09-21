using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013D2 RID: 5074
	internal class RpcC2M_GetMyApplyStudentInfo : Rpc
	{
		// Token: 0x0600E442 RID: 58434 RVA: 0x0033B738 File Offset: 0x00339938
		public override uint GetRpcType()
		{
			return 28961U;
		}

		// Token: 0x0600E443 RID: 58435 RVA: 0x0033B74F File Offset: 0x0033994F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMyApplyStudentInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E444 RID: 58436 RVA: 0x0033B75F File Offset: 0x0033995F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMyApplyStudentInfoRes>(stream);
		}

		// Token: 0x0600E445 RID: 58437 RVA: 0x0033B76E File Offset: 0x0033996E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMyApplyStudentInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E446 RID: 58438 RVA: 0x0033B78A File Offset: 0x0033998A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMyApplyStudentInfo.OnTimeout(this.oArg);
		}

		// Token: 0x04006415 RID: 25621
		public GetMyApplyStudentInfoArg oArg = new GetMyApplyStudentInfoArg();

		// Token: 0x04006416 RID: 25622
		public GetMyApplyStudentInfoRes oRes = null;
	}
}
