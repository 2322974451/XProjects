using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200134A RID: 4938
	internal class RpcC2M_ResWarExplore : Rpc
	{
		// Token: 0x0600E21C RID: 57884 RVA: 0x0033890C File Offset: 0x00336B0C
		public override uint GetRpcType()
		{
			return 33965U;
		}

		// Token: 0x0600E21D RID: 57885 RVA: 0x00338923 File Offset: 0x00336B23
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarExploreArg>(stream, this.oArg);
		}

		// Token: 0x0600E21E RID: 57886 RVA: 0x00338933 File Offset: 0x00336B33
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarExploreRes>(stream);
		}

		// Token: 0x0600E21F RID: 57887 RVA: 0x00338942 File Offset: 0x00336B42
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ResWarExplore.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E220 RID: 57888 RVA: 0x0033895E File Offset: 0x00336B5E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ResWarExplore.OnTimeout(this.oArg);
		}

		// Token: 0x040063AD RID: 25517
		public ResWarExploreArg oArg = new ResWarExploreArg();

		// Token: 0x040063AE RID: 25518
		public ResWarExploreRes oRes = null;
	}
}
