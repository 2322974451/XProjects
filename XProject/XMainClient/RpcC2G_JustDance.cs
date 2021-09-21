using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001385 RID: 4997
	internal class RpcC2G_JustDance : Rpc
	{
		// Token: 0x0600E309 RID: 58121 RVA: 0x00339D8C File Offset: 0x00337F8C
		public override uint GetRpcType()
		{
			return 43613U;
		}

		// Token: 0x0600E30A RID: 58122 RVA: 0x00339DA3 File Offset: 0x00337FA3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JustDanceArg>(stream, this.oArg);
		}

		// Token: 0x0600E30B RID: 58123 RVA: 0x00339DB3 File Offset: 0x00337FB3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JustDanceRes>(stream);
		}

		// Token: 0x0600E30C RID: 58124 RVA: 0x00339DC2 File Offset: 0x00337FC2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JustDance.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E30D RID: 58125 RVA: 0x00339DDE File Offset: 0x00337FDE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JustDance.OnTimeout(this.oArg);
		}

		// Token: 0x040063DA RID: 25562
		public JustDanceArg oArg = new JustDanceArg();

		// Token: 0x040063DB RID: 25563
		public JustDanceRes oRes = new JustDanceRes();
	}
}
