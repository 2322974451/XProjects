using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001146 RID: 4422
	internal class RpcC2M_SelectRoleNew : Rpc
	{
		// Token: 0x0600D9E2 RID: 55778 RVA: 0x0032BC5C File Offset: 0x00329E5C
		public override uint GetRpcType()
		{
			return 217U;
		}

		// Token: 0x0600D9E3 RID: 55779 RVA: 0x0032BC73 File Offset: 0x00329E73
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectRoleNewArg>(stream, this.oArg);
		}

		// Token: 0x0600D9E4 RID: 55780 RVA: 0x0032BC83 File Offset: 0x00329E83
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectRoleNewRes>(stream);
		}

		// Token: 0x0600D9E5 RID: 55781 RVA: 0x0032BC92 File Offset: 0x00329E92
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SelectRoleNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D9E6 RID: 55782 RVA: 0x0032BCAE File Offset: 0x00329EAE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SelectRoleNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400621B RID: 25115
		public SelectRoleNewArg oArg = new SelectRoleNewArg();

		// Token: 0x0400621C RID: 25116
		public SelectRoleNewRes oRes = null;
	}
}
