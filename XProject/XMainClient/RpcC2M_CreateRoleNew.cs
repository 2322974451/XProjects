using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001144 RID: 4420
	internal class RpcC2M_CreateRoleNew : Rpc
	{
		// Token: 0x0600D9D9 RID: 55769 RVA: 0x0032BAE4 File Offset: 0x00329CE4
		public override uint GetRpcType()
		{
			return 13034U;
		}

		// Token: 0x0600D9DA RID: 55770 RVA: 0x0032BAFB File Offset: 0x00329CFB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CreateRoleNewArg>(stream, this.oArg);
		}

		// Token: 0x0600D9DB RID: 55771 RVA: 0x0032BB0B File Offset: 0x00329D0B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<CreateRoleNewRes>(stream);
		}

		// Token: 0x0600D9DC RID: 55772 RVA: 0x0032BB1A File Offset: 0x00329D1A
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_CreateRoleNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D9DD RID: 55773 RVA: 0x0032BB36 File Offset: 0x00329D36
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_CreateRoleNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006219 RID: 25113
		public CreateRoleNewArg oArg = new CreateRoleNewArg();

		// Token: 0x0400621A RID: 25114
		public CreateRoleNewRes oRes = null;
	}
}
