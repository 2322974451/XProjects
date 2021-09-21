using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001264 RID: 4708
	internal class RpcC2G_LevelSealExchange : Rpc
	{
		// Token: 0x0600DE6A RID: 56938 RVA: 0x00333380 File Offset: 0x00331580
		public override uint GetRpcType()
		{
			return 65467U;
		}

		// Token: 0x0600DE6B RID: 56939 RVA: 0x00333397 File Offset: 0x00331597
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LevelSealExchangeArg>(stream, this.oArg);
		}

		// Token: 0x0600DE6C RID: 56940 RVA: 0x003333A7 File Offset: 0x003315A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<LevelSealExchangeRes>(stream);
		}

		// Token: 0x0600DE6D RID: 56941 RVA: 0x003333B6 File Offset: 0x003315B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_LevelSealExchange.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE6E RID: 56942 RVA: 0x003333D2 File Offset: 0x003315D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_LevelSealExchange.OnTimeout(this.oArg);
		}

		// Token: 0x040062F6 RID: 25334
		public LevelSealExchangeArg oArg = new LevelSealExchangeArg();

		// Token: 0x040062F7 RID: 25335
		public LevelSealExchangeRes oRes = new LevelSealExchangeRes();
	}
}
