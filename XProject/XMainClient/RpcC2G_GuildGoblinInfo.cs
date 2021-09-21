using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010BC RID: 4284
	internal class RpcC2G_GuildGoblinInfo : Rpc
	{
		// Token: 0x0600D7AB RID: 55211 RVA: 0x00328790 File Offset: 0x00326990
		public override uint GetRpcType()
		{
			return 59865U;
		}

		// Token: 0x0600D7AC RID: 55212 RVA: 0x003287A7 File Offset: 0x003269A7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildGoblinInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600D7AD RID: 55213 RVA: 0x003287B7 File Offset: 0x003269B7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildGoblinInfoRes>(stream);
		}

		// Token: 0x0600D7AE RID: 55214 RVA: 0x003287C6 File Offset: 0x003269C6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildGoblinInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D7AF RID: 55215 RVA: 0x003287E2 File Offset: 0x003269E2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildGoblinInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040061B1 RID: 25009
		public GuildGoblinInfoArg oArg = new GuildGoblinInfoArg();

		// Token: 0x040061B2 RID: 25010
		public GuildGoblinInfoRes oRes = new GuildGoblinInfoRes();
	}
}
