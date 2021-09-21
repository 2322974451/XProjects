using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B56 RID: 2902
	internal class RpcC2N_CreateRoleNew : Rpc
	{
		// Token: 0x0600A8DF RID: 43231 RVA: 0x001E1250 File Offset: 0x001DF450
		public override uint GetRpcType()
		{
			return 13034U;
		}

		// Token: 0x0600A8E0 RID: 43232 RVA: 0x001E1267 File Offset: 0x001DF467
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateRoleNewArg>(stream, this.oArg);
		}

		// Token: 0x0600A8E1 RID: 43233 RVA: 0x001E1277 File Offset: 0x001DF477
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateRoleNewRes>(stream);
		}

		// Token: 0x0600A8E2 RID: 43234 RVA: 0x001E1286 File Offset: 0x001DF486
		public override void Process()
		{
			base.Process();
			Process_RpcC2N_CreateRoleNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8E3 RID: 43235 RVA: 0x001E12A2 File Offset: 0x001DF4A2
		public override void OnTimeout(object args)
		{
			Process_RpcC2N_CreateRoleNew.OnTimeout(this.oArg);
		}

		// Token: 0x04003E8C RID: 16012
		public CreateRoleNewArg oArg = new CreateRoleNewArg();

		// Token: 0x04003E8D RID: 16013
		public CreateRoleNewRes oRes = new CreateRoleNewRes();
	}
}
