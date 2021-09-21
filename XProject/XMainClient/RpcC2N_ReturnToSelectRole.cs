using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B57 RID: 2903
	internal class RpcC2N_ReturnToSelectRole : Rpc
	{
		// Token: 0x0600A8E5 RID: 43237 RVA: 0x001E12D4 File Offset: 0x001DF4D4
		public override uint GetRpcType()
		{
			return 25477U;
		}

		// Token: 0x0600A8E6 RID: 43238 RVA: 0x001E12EB File Offset: 0x001DF4EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReturnToSelectRoleArg>(stream, this.oArg);
		}

		// Token: 0x0600A8E7 RID: 43239 RVA: 0x001E12FB File Offset: 0x001DF4FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReturnToSelectRoleRes>(stream);
		}

		// Token: 0x0600A8E8 RID: 43240 RVA: 0x001E130A File Offset: 0x001DF50A
		public override void Process()
		{
			base.Process();
			Process_RpcC2N_ReturnToSelectRole.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8E9 RID: 43241 RVA: 0x001E1326 File Offset: 0x001DF526
		public override void OnTimeout(object args)
		{
			Process_RpcC2N_ReturnToSelectRole.OnTimeout(this.oArg);
		}

		// Token: 0x04003E8E RID: 16014
		public ReturnToSelectRoleArg oArg = new ReturnToSelectRoleArg();

		// Token: 0x04003E8F RID: 16015
		public ReturnToSelectRoleRes oRes = new ReturnToSelectRoleRes();
	}
}
