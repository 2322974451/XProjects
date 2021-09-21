using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001564 RID: 5476
	internal class RpcC2G_BuySpriteEgg : Rpc
	{
		// Token: 0x0600EAA7 RID: 60071 RVA: 0x00344984 File Offset: 0x00342B84
		public override uint GetRpcType()
		{
			return 34552U;
		}

		// Token: 0x0600EAA8 RID: 60072 RVA: 0x0034499B File Offset: 0x00342B9B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuySpriteEggArg>(stream, this.oArg);
		}

		// Token: 0x0600EAA9 RID: 60073 RVA: 0x003449AB File Offset: 0x00342BAB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuySpriteEggRes>(stream);
		}

		// Token: 0x0600EAAA RID: 60074 RVA: 0x003449BA File Offset: 0x00342BBA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuySpriteEgg.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EAAB RID: 60075 RVA: 0x003449D6 File Offset: 0x00342BD6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuySpriteEgg.OnTimeout(this.oArg);
		}

		// Token: 0x04006552 RID: 25938
		public BuySpriteEggArg oArg = new BuySpriteEggArg();

		// Token: 0x04006553 RID: 25939
		public BuySpriteEggRes oRes = null;
	}
}
