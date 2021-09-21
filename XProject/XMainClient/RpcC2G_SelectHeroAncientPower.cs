using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200158E RID: 5518
	internal class RpcC2G_SelectHeroAncientPower : Rpc
	{
		// Token: 0x0600EB58 RID: 60248 RVA: 0x003459F4 File Offset: 0x00343BF4
		public override uint GetRpcType()
		{
			return 7667U;
		}

		// Token: 0x0600EB59 RID: 60249 RVA: 0x00345A0B File Offset: 0x00343C0B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectHeroAncientPowerArg>(stream, this.oArg);
		}

		// Token: 0x0600EB5A RID: 60250 RVA: 0x00345A1B File Offset: 0x00343C1B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectHeroAncientPowerRes>(stream);
		}

		// Token: 0x0600EB5B RID: 60251 RVA: 0x00345A2A File Offset: 0x00343C2A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SelectHeroAncientPower.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EB5C RID: 60252 RVA: 0x00345A46 File Offset: 0x00343C46
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SelectHeroAncientPower.OnTimeout(this.oArg);
		}

		// Token: 0x04006576 RID: 25974
		public SelectHeroAncientPowerArg oArg = new SelectHeroAncientPowerArg();

		// Token: 0x04006577 RID: 25975
		public SelectHeroAncientPowerRes oRes = null;
	}
}
