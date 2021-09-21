using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200120F RID: 4623
	internal class RpcC2G_TitleLevelUp : Rpc
	{
		// Token: 0x0600DD03 RID: 56579 RVA: 0x003311B4 File Offset: 0x0032F3B4
		public override uint GetRpcType()
		{
			return 24381U;
		}

		// Token: 0x0600DD04 RID: 56580 RVA: 0x003311CB File Offset: 0x0032F3CB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TitleLevelUpArg>(stream, this.oArg);
		}

		// Token: 0x0600DD05 RID: 56581 RVA: 0x003311DB File Offset: 0x0032F3DB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TitleLevelUpRes>(stream);
		}

		// Token: 0x0600DD06 RID: 56582 RVA: 0x003311EA File Offset: 0x0032F3EA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TitleLevelUp.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DD07 RID: 56583 RVA: 0x00331206 File Offset: 0x0032F406
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TitleLevelUp.OnTimeout(this.oArg);
		}

		// Token: 0x040062AD RID: 25261
		public TitleLevelUpArg oArg = new TitleLevelUpArg();

		// Token: 0x040062AE RID: 25262
		public TitleLevelUpRes oRes = new TitleLevelUpRes();
	}
}
