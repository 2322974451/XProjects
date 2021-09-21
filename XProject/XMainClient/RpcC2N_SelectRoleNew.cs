using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000B58 RID: 2904
	internal class RpcC2N_SelectRoleNew : Rpc
	{
		// Token: 0x0600A8EB RID: 43243 RVA: 0x001E1358 File Offset: 0x001DF558
		public override uint GetRpcType()
		{
			return 217U;
		}

		// Token: 0x0600A8EC RID: 43244 RVA: 0x001E136F File Offset: 0x001DF56F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectRoleNewArg>(stream, this.oArg);
		}

		// Token: 0x0600A8ED RID: 43245 RVA: 0x001E137F File Offset: 0x001DF57F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectRoleNewRes>(stream);
		}

		// Token: 0x0600A8EE RID: 43246 RVA: 0x001E138E File Offset: 0x001DF58E
		public override void Process()
		{
			base.Process();
			Process_RpcC2N_SelectRoleNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600A8EF RID: 43247 RVA: 0x001E13AA File Offset: 0x001DF5AA
		public override void OnTimeout(object args)
		{
			Process_RpcC2N_SelectRoleNew.OnTimeout(this.oArg);
		}

		// Token: 0x04003E90 RID: 16016
		public SelectRoleNewArg oArg = new SelectRoleNewArg();

		// Token: 0x04003E91 RID: 16017
		public SelectRoleNewRes oRes = new SelectRoleNewRes();
	}
}
