using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013EE RID: 5102
	internal class RpcC2G_GetHeroBattleInfo : Rpc
	{
		// Token: 0x0600E4BB RID: 58555 RVA: 0x0033C0C4 File Offset: 0x0033A2C4
		public override uint GetRpcType()
		{
			return 65206U;
		}

		// Token: 0x0600E4BC RID: 58556 RVA: 0x0033C0DB File Offset: 0x0033A2DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetHeroBattleInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E4BD RID: 58557 RVA: 0x0033C0EB File Offset: 0x0033A2EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetHeroBattleInfoRes>(stream);
		}

		// Token: 0x0600E4BE RID: 58558 RVA: 0x0033C0FA File Offset: 0x0033A2FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetHeroBattleInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E4BF RID: 58559 RVA: 0x0033C116 File Offset: 0x0033A316
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetHeroBattleInfo.OnTimeout(this.oArg);
		}

		// Token: 0x0400642E RID: 25646
		public GetHeroBattleInfoArg oArg = new GetHeroBattleInfoArg();

		// Token: 0x0400642F RID: 25647
		public GetHeroBattleInfoRes oRes = null;
	}
}
