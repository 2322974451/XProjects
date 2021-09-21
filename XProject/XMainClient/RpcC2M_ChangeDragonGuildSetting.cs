using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200162A RID: 5674
	internal class RpcC2M_ChangeDragonGuildSetting : Rpc
	{
		// Token: 0x0600EDE5 RID: 60901 RVA: 0x00348FD8 File Offset: 0x003471D8
		public override uint GetRpcType()
		{
			return 52505U;
		}

		// Token: 0x0600EDE6 RID: 60902 RVA: 0x00348FEF File Offset: 0x003471EF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeDragonGuildSettingArg>(stream, this.oArg);
		}

		// Token: 0x0600EDE7 RID: 60903 RVA: 0x00348FFF File Offset: 0x003471FF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeDragonGuildSettingRes>(stream);
		}

		// Token: 0x0600EDE8 RID: 60904 RVA: 0x0034900E File Offset: 0x0034720E
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeDragonGuildSetting.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EDE9 RID: 60905 RVA: 0x0034902A File Offset: 0x0034722A
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeDragonGuildSetting.OnTimeout(this.oArg);
		}

		// Token: 0x040065F6 RID: 26102
		public ChangeDragonGuildSettingArg oArg = new ChangeDragonGuildSettingArg();

		// Token: 0x040065F7 RID: 26103
		public ChangeDragonGuildSettingRes oRes = null;
	}
}
