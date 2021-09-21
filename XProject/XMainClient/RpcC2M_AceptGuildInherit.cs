using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200139B RID: 5019
	internal class RpcC2M_AceptGuildInherit : Rpc
	{
		// Token: 0x0600E367 RID: 58215 RVA: 0x0033A52C File Offset: 0x0033872C
		public override uint GetRpcType()
		{
			return 35235U;
		}

		// Token: 0x0600E368 RID: 58216 RVA: 0x0033A543 File Offset: 0x00338743
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AceptGuildInheritArg>(stream, this.oArg);
		}

		// Token: 0x0600E369 RID: 58217 RVA: 0x0033A553 File Offset: 0x00338753
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AceptGuildInheritRes>(stream);
		}

		// Token: 0x0600E36A RID: 58218 RVA: 0x0033A562 File Offset: 0x00338762
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AceptGuildInherit.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E36B RID: 58219 RVA: 0x0033A57E File Offset: 0x0033877E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AceptGuildInherit.OnTimeout(this.oArg);
		}

		// Token: 0x040063ED RID: 25581
		public AceptGuildInheritArg oArg = new AceptGuildInheritArg();

		// Token: 0x040063EE RID: 25582
		public AceptGuildInheritRes oRes = null;
	}
}
