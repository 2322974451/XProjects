using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000EC4 RID: 3780
	internal class RpcC2G_EmblemLevelUp : Rpc
	{
		// Token: 0x0600C8AA RID: 51370 RVA: 0x002CEEA4 File Offset: 0x002CD0A4
		public override uint GetRpcType()
		{
			return 9893U;
		}

		// Token: 0x0600C8AB RID: 51371 RVA: 0x002CEEBB File Offset: 0x002CD0BB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<EmblemLevelUpArg>(stream, this.oArg);
		}

		// Token: 0x0600C8AC RID: 51372 RVA: 0x002CEECB File Offset: 0x002CD0CB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<EmblemLevelUpRes>(stream);
		}

		// Token: 0x0600C8AD RID: 51373 RVA: 0x002CEEDA File Offset: 0x002CD0DA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_EmblemLevelUp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600C8AE RID: 51374 RVA: 0x002CEEF6 File Offset: 0x002CD0F6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_EmblemLevelUp.OnTimeout(this.oArg);
		}

		// Token: 0x040058BF RID: 22719
		public EmblemLevelUpArg oArg = new EmblemLevelUpArg();

		// Token: 0x040058C0 RID: 22720
		public EmblemLevelUpRes oRes = new EmblemLevelUpRes();
	}
}
