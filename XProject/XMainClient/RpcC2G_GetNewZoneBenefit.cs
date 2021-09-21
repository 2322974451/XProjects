using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200166E RID: 5742
	internal class RpcC2G_GetNewZoneBenefit : Rpc
	{
		// Token: 0x0600EF06 RID: 61190 RVA: 0x0034AA4C File Offset: 0x00348C4C
		public override uint GetRpcType()
		{
			return 17236U;
		}

		// Token: 0x0600EF07 RID: 61191 RVA: 0x0034AA63 File Offset: 0x00348C63
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetNewZoneBenefitArg>(stream, this.oArg);
		}

		// Token: 0x0600EF08 RID: 61192 RVA: 0x0034AA73 File Offset: 0x00348C73
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetNewZoneBenefitRes>(stream);
		}

		// Token: 0x0600EF09 RID: 61193 RVA: 0x0034AA82 File Offset: 0x00348C82
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetNewZoneBenefit.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF0A RID: 61194 RVA: 0x0034AA9E File Offset: 0x00348C9E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetNewZoneBenefit.OnTimeout(this.oArg);
		}

		// Token: 0x04006638 RID: 26168
		public GetNewZoneBenefitArg oArg = new GetNewZoneBenefitArg();

		// Token: 0x04006639 RID: 26169
		public GetNewZoneBenefitRes oRes = null;
	}
}
