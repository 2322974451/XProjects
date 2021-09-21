using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015C1 RID: 5569
	internal class RpcC2G_DragonGroupRecord : Rpc
	{
		// Token: 0x0600EC28 RID: 60456 RVA: 0x00346AEC File Offset: 0x00344CEC
		public override uint GetRpcType()
		{
			return 62181U;
		}

		// Token: 0x0600EC29 RID: 60457 RVA: 0x00346B03 File Offset: 0x00344D03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGroupRecordC2S>(stream, this.oArg);
		}

		// Token: 0x0600EC2A RID: 60458 RVA: 0x00346B13 File Offset: 0x00344D13
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGroupRecordS2C>(stream);
		}

		// Token: 0x0600EC2B RID: 60459 RVA: 0x00346B22 File Offset: 0x00344D22
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DragonGroupRecord.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EC2C RID: 60460 RVA: 0x00346B3E File Offset: 0x00344D3E
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DragonGroupRecord.OnTimeout(this.oArg);
		}

		// Token: 0x0400659C RID: 26012
		public DragonGroupRecordC2S oArg = new DragonGroupRecordC2S();

		// Token: 0x0400659D RID: 26013
		public DragonGroupRecordS2C oRes = null;
	}
}
