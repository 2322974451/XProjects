using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001241 RID: 4673
	internal class RpcC2G_AutoBreakAtlas : Rpc
	{
		// Token: 0x0600DDD4 RID: 56788 RVA: 0x00332708 File Offset: 0x00330908
		public override uint GetRpcType()
		{
			return 23263U;
		}

		// Token: 0x0600DDD5 RID: 56789 RVA: 0x0033271F File Offset: 0x0033091F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AutoBreakAtlasArg>(stream, this.oArg);
		}

		// Token: 0x0600DDD6 RID: 56790 RVA: 0x0033272F File Offset: 0x0033092F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AutoBreakAtlasRes>(stream);
		}

		// Token: 0x0600DDD7 RID: 56791 RVA: 0x0033273E File Offset: 0x0033093E
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AutoBreakAtlas.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DDD8 RID: 56792 RVA: 0x0033275A File Offset: 0x0033095A
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AutoBreakAtlas.OnTimeout(this.oArg);
		}

		// Token: 0x040062D7 RID: 25303
		public AutoBreakAtlasArg oArg = new AutoBreakAtlasArg();

		// Token: 0x040062D8 RID: 25304
		public AutoBreakAtlasRes oRes = new AutoBreakAtlasRes();
	}
}
