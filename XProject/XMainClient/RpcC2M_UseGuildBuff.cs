using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200135E RID: 4958
	internal class RpcC2M_UseGuildBuff : Rpc
	{
		// Token: 0x0600E26A RID: 57962 RVA: 0x00338FB4 File Offset: 0x003371B4
		public override uint GetRpcType()
		{
			return 15817U;
		}

		// Token: 0x0600E26B RID: 57963 RVA: 0x00338FCB File Offset: 0x003371CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UseGuildBuffArg>(stream, this.oArg);
		}

		// Token: 0x0600E26C RID: 57964 RVA: 0x00338FDB File Offset: 0x003371DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<UseGuildBuffRes>(stream);
		}

		// Token: 0x0600E26D RID: 57965 RVA: 0x00338FEA File Offset: 0x003371EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_UseGuildBuff.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E26E RID: 57966 RVA: 0x00339006 File Offset: 0x00337206
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_UseGuildBuff.OnTimeout(this.oArg);
		}

		// Token: 0x040063BB RID: 25531
		public UseGuildBuffArg oArg = new UseGuildBuffArg();

		// Token: 0x040063BC RID: 25532
		public UseGuildBuffRes oRes = null;
	}
}
