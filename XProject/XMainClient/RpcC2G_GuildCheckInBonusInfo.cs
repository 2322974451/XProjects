using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001110 RID: 4368
	internal class RpcC2G_GuildCheckInBonusInfo : Rpc
	{
		// Token: 0x0600D900 RID: 55552 RVA: 0x0032A57C File Offset: 0x0032877C
		public override uint GetRpcType()
		{
			return 47251U;
		}

		// Token: 0x0600D901 RID: 55553 RVA: 0x0032A593 File Offset: 0x00328793
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCheckInBonusInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600D902 RID: 55554 RVA: 0x0032A5A3 File Offset: 0x003287A3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCheckInBonusInfoRes>(stream);
		}

		// Token: 0x0600D903 RID: 55555 RVA: 0x0032A5B2 File Offset: 0x003287B2
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GuildCheckInBonusInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D904 RID: 55556 RVA: 0x0032A5CE File Offset: 0x003287CE
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GuildCheckInBonusInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040061EF RID: 25071
		public GuildCheckInBonusInfoArg oArg = new GuildCheckInBonusInfoArg();

		// Token: 0x040061F0 RID: 25072
		public GuildCheckInBonusInfoRes oRes = new GuildCheckInBonusInfoRes();
	}
}
