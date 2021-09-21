using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020014AA RID: 5290
	internal class RpcC2G_ChangeDeclaration : Rpc
	{
		// Token: 0x0600E7B3 RID: 59315 RVA: 0x0034065C File Offset: 0x0033E85C
		public override uint GetRpcType()
		{
			return 1588U;
		}

		// Token: 0x0600E7B4 RID: 59316 RVA: 0x00340673 File Offset: 0x0033E873
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeDeclarationArg>(stream, this.oArg);
		}

		// Token: 0x0600E7B5 RID: 59317 RVA: 0x00340683 File Offset: 0x0033E883
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeDeclarationRes>(stream);
		}

		// Token: 0x0600E7B6 RID: 59318 RVA: 0x00340692 File Offset: 0x0033E892
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeDeclaration.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E7B7 RID: 59319 RVA: 0x003406AE File Offset: 0x0033E8AE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeDeclaration.OnTimeout(this.oArg);
		}

		// Token: 0x040064BB RID: 25787
		public ChangeDeclarationArg oArg = new ChangeDeclarationArg();

		// Token: 0x040064BC RID: 25788
		public ChangeDeclarationRes oRes = null;
	}
}
