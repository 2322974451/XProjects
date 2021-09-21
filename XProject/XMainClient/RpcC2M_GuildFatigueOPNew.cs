using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020012B5 RID: 4789
	internal class RpcC2M_GuildFatigueOPNew : Rpc
	{
		// Token: 0x0600DFB2 RID: 57266 RVA: 0x00334F98 File Offset: 0x00333198
		public override uint GetRpcType()
		{
			return 10226U;
		}

		// Token: 0x0600DFB3 RID: 57267 RVA: 0x00334FAF File Offset: 0x003331AF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildFatigueArg>(stream, this.oArg);
		}

		// Token: 0x0600DFB4 RID: 57268 RVA: 0x00334FBF File Offset: 0x003331BF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildFatigueRes>(stream);
		}

		// Token: 0x0600DFB5 RID: 57269 RVA: 0x00334FCE File Offset: 0x003331CE
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildFatigueOPNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DFB6 RID: 57270 RVA: 0x00334FEA File Offset: 0x003331EA
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildFatigueOPNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006334 RID: 25396
		public GuildFatigueArg oArg = new GuildFatigueArg();

		// Token: 0x04006335 RID: 25397
		public GuildFatigueRes oRes = null;
	}
}
