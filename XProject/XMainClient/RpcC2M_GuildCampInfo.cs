using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200136E RID: 4974
	internal class RpcC2M_GuildCampInfo : Rpc
	{
		// Token: 0x0600E2AF RID: 58031 RVA: 0x00339680 File Offset: 0x00337880
		public override uint GetRpcType()
		{
			return 4221U;
		}

		// Token: 0x0600E2B0 RID: 58032 RVA: 0x00339697 File Offset: 0x00337897
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildCampInfoArg>(stream, this.oArg);
		}

		// Token: 0x0600E2B1 RID: 58033 RVA: 0x003396A7 File Offset: 0x003378A7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildCampInfoRes>(stream);
		}

		// Token: 0x0600E2B2 RID: 58034 RVA: 0x003396B6 File Offset: 0x003378B6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildCampInfo.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E2B3 RID: 58035 RVA: 0x003396D2 File Offset: 0x003378D2
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildCampInfo.OnTimeout(this.oArg);
		}

		// Token: 0x040063CA RID: 25546
		public GuildCampInfoArg oArg = new GuildCampInfoArg();

		// Token: 0x040063CB RID: 25547
		public GuildCampInfoRes oRes = null;
	}
}
