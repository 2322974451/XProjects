using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200105A RID: 4186
	internal class RpcC2G_BuyGoldAndFatigue : Rpc
	{
		// Token: 0x0600D620 RID: 54816 RVA: 0x00325AB8 File Offset: 0x00323CB8
		public override uint GetRpcType()
		{
			return 31095U;
		}

		// Token: 0x0600D621 RID: 54817 RVA: 0x00325ACF File Offset: 0x00323CCF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyGoldAndFatigueArg>(stream, this.oArg);
		}

		// Token: 0x0600D622 RID: 54818 RVA: 0x00325ADF File Offset: 0x00323CDF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyGoldAndFatigueRes>(stream);
		}

		// Token: 0x0600D623 RID: 54819 RVA: 0x00325AEE File Offset: 0x00323CEE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyGoldAndFatigue.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D624 RID: 54820 RVA: 0x00325B0A File Offset: 0x00323D0A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyGoldAndFatigue.OnTimeout(this.oArg);
		}

		// Token: 0x0400616A RID: 24938
		public BuyGoldAndFatigueArg oArg = new BuyGoldAndFatigueArg();

		// Token: 0x0400616B RID: 24939
		public BuyGoldAndFatigueRes oRes = new BuyGoldAndFatigueRes();
	}
}
