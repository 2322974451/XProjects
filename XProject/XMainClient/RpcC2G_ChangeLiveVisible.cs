using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001512 RID: 5394
	internal class RpcC2G_ChangeLiveVisible : Rpc
	{
		// Token: 0x0600E95F RID: 59743 RVA: 0x003429B0 File Offset: 0x00340BB0
		public override uint GetRpcType()
		{
			return 56831U;
		}

		// Token: 0x0600E960 RID: 59744 RVA: 0x003429C7 File Offset: 0x00340BC7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeLiveVisibleArg>(stream, this.oArg);
		}

		// Token: 0x0600E961 RID: 59745 RVA: 0x003429D7 File Offset: 0x00340BD7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeLiveVisibleRes>(stream);
		}

		// Token: 0x0600E962 RID: 59746 RVA: 0x003429E6 File Offset: 0x00340BE6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeLiveVisible.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E963 RID: 59747 RVA: 0x00342A02 File Offset: 0x00340C02
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeLiveVisible.OnTimeout(this.oArg);
		}

		// Token: 0x0400650E RID: 25870
		public ChangeLiveVisibleArg oArg = new ChangeLiveVisibleArg();

		// Token: 0x0400650F RID: 25871
		public ChangeLiveVisibleRes oRes = null;
	}
}
