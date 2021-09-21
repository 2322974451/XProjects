using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001670 RID: 5744
	internal class RpcC2G_SelectChargeBackRole : Rpc
	{
		// Token: 0x0600EF0F RID: 61199 RVA: 0x0034AB40 File Offset: 0x00348D40
		public override uint GetRpcType()
		{
			return 38792U;
		}

		// Token: 0x0600EF10 RID: 61200 RVA: 0x0034AB57 File Offset: 0x00348D57
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SelectChargeBackRoleArg>(stream, this.oArg);
		}

		// Token: 0x0600EF11 RID: 61201 RVA: 0x0034AB67 File Offset: 0x00348D67
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SelectChargeBackRoleRes>(stream);
		}

		// Token: 0x0600EF12 RID: 61202 RVA: 0x0034AB76 File Offset: 0x00348D76
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SelectChargeBackRole.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF13 RID: 61203 RVA: 0x0034AB92 File Offset: 0x00348D92
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SelectChargeBackRole.OnTimeout(this.oArg);
		}

		// Token: 0x0400663A RID: 26170
		public SelectChargeBackRoleArg oArg = new SelectChargeBackRoleArg();

		// Token: 0x0400663B RID: 26171
		public SelectChargeBackRoleRes oRes = null;
	}
}
