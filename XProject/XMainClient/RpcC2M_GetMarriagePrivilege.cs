using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001696 RID: 5782
	internal class RpcC2M_GetMarriagePrivilege : Rpc
	{
		// Token: 0x0600EFB0 RID: 61360 RVA: 0x0034BC34 File Offset: 0x00349E34
		public override uint GetRpcType()
		{
			return 15597U;
		}

		// Token: 0x0600EFB1 RID: 61361 RVA: 0x0034BC4B File Offset: 0x00349E4B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetMarriagePrivilegeArg>(stream, this.oArg);
		}

		// Token: 0x0600EFB2 RID: 61362 RVA: 0x0034BC5B File Offset: 0x00349E5B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetMarriagePrivilegeRes>(stream);
		}

		// Token: 0x0600EFB3 RID: 61363 RVA: 0x0034BC6A File Offset: 0x00349E6A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetMarriagePrivilege.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EFB4 RID: 61364 RVA: 0x0034BC86 File Offset: 0x00349E86
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetMarriagePrivilege.OnTimeout(this.oArg);
		}

		// Token: 0x0400665B RID: 26203
		public GetMarriagePrivilegeArg oArg = new GetMarriagePrivilegeArg();

		// Token: 0x0400665C RID: 26204
		public GetMarriagePrivilegeRes oRes = null;
	}
}
