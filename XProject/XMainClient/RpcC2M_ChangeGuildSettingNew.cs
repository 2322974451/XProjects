using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001297 RID: 4759
	internal class RpcC2M_ChangeGuildSettingNew : Rpc
	{
		// Token: 0x0600DF3D RID: 57149 RVA: 0x0033443C File Offset: 0x0033263C
		public override uint GetRpcType()
		{
			return 55897U;
		}

		// Token: 0x0600DF3E RID: 57150 RVA: 0x00334453 File Offset: 0x00332653
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeGuildSettingArg>(stream, this.oArg);
		}

		// Token: 0x0600DF3F RID: 57151 RVA: 0x00334463 File Offset: 0x00332663
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeGuildSettingRes>(stream);
		}

		// Token: 0x0600DF40 RID: 57152 RVA: 0x00334472 File Offset: 0x00332672
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeGuildSettingNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DF41 RID: 57153 RVA: 0x0033448E File Offset: 0x0033268E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeGuildSettingNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400631F RID: 25375
		public ChangeGuildSettingArg oArg = new ChangeGuildSettingArg();

		// Token: 0x04006320 RID: 25376
		public ChangeGuildSettingRes oRes = null;
	}
}
