using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200116A RID: 4458
	internal class RpcC2G_TakeOffAllJade : Rpc
	{
		// Token: 0x0600DA7C RID: 55932 RVA: 0x0032DB84 File Offset: 0x0032BD84
		public override uint GetRpcType()
		{
			return 21793U;
		}

		// Token: 0x0600DA7D RID: 55933 RVA: 0x0032DB9B File Offset: 0x0032BD9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakeOffAllJadeArg>(stream, this.oArg);
		}

		// Token: 0x0600DA7E RID: 55934 RVA: 0x0032DBAB File Offset: 0x0032BDAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakeOffAllJadeRes>(stream);
		}

		// Token: 0x0600DA7F RID: 55935 RVA: 0x0032DBBA File Offset: 0x0032BDBA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakeOffAllJade.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DA80 RID: 55936 RVA: 0x0032DBD6 File Offset: 0x0032BDD6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakeOffAllJade.OnTimeout(this.oArg);
		}

		// Token: 0x0400623B RID: 25147
		public TakeOffAllJadeArg oArg = new TakeOffAllJadeArg();

		// Token: 0x0400623C RID: 25148
		public TakeOffAllJadeRes oRes = new TakeOffAllJadeRes();
	}
}
