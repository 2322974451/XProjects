using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200126D RID: 4717
	internal class RpcC2G_PlayDiceOver : Rpc
	{
		// Token: 0x0600DE8F RID: 56975 RVA: 0x003336D4 File Offset: 0x003318D4
		public override uint GetRpcType()
		{
			return 15035U;
		}

		// Token: 0x0600DE90 RID: 56976 RVA: 0x003336EB File Offset: 0x003318EB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceOverArg>(stream, this.oArg);
		}

		// Token: 0x0600DE91 RID: 56977 RVA: 0x003336FB File Offset: 0x003318FB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PlayDiceOverRes>(stream);
		}

		// Token: 0x0600DE92 RID: 56978 RVA: 0x0033370A File Offset: 0x0033190A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PlayDiceOver.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE93 RID: 56979 RVA: 0x00333726 File Offset: 0x00331926
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PlayDiceOver.OnTimeout(this.oArg);
		}

		// Token: 0x040062FD RID: 25341
		public PlayDiceOverArg oArg = new PlayDiceOverArg();

		// Token: 0x040062FE RID: 25342
		public PlayDiceOverRes oRes = new PlayDiceOverRes();
	}
}
