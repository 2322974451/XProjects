using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001255 RID: 4693
	internal class RpcC2M_WorldBossEnd : Rpc
	{
		// Token: 0x0600DE28 RID: 56872 RVA: 0x00332E78 File Offset: 0x00331078
		public override uint GetRpcType()
		{
			return 53655U;
		}

		// Token: 0x0600DE29 RID: 56873 RVA: 0x00332E8F File Offset: 0x0033108F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<WorldBossEndArg>(stream, this.oArg);
		}

		// Token: 0x0600DE2A RID: 56874 RVA: 0x00332E9F File Offset: 0x0033109F
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<WorldBossEndRes>(stream);
		}

		// Token: 0x0600DE2B RID: 56875 RVA: 0x00332EAE File Offset: 0x003310AE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_WorldBossEnd.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DE2C RID: 56876 RVA: 0x00332ECA File Offset: 0x003310CA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_WorldBossEnd.OnTimeout(this.oArg);
		}

		// Token: 0x040062E8 RID: 25320
		public WorldBossEndArg oArg = new WorldBossEndArg();

		// Token: 0x040062E9 RID: 25321
		public WorldBossEndRes oRes = null;
	}
}
