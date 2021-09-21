using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001644 RID: 5700
	internal class RpcC2M_ChangeDragonGuildPosition : Rpc
	{
		// Token: 0x0600EE56 RID: 61014 RVA: 0x003499BC File Offset: 0x00347BBC
		public override uint GetRpcType()
		{
			return 3888U;
		}

		// Token: 0x0600EE57 RID: 61015 RVA: 0x003499D3 File Offset: 0x00347BD3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeDragonGuildPositionArg>(stream, this.oArg);
		}

		// Token: 0x0600EE58 RID: 61016 RVA: 0x003499E3 File Offset: 0x00347BE3
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeDragonGuildPositionRes>(stream);
		}

		// Token: 0x0600EE59 RID: 61017 RVA: 0x003499F2 File Offset: 0x00347BF2
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeDragonGuildPosition.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EE5A RID: 61018 RVA: 0x00349A0E File Offset: 0x00347C0E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeDragonGuildPosition.OnTimeout(this.oArg);
		}

		// Token: 0x0400660E RID: 26126
		public ChangeDragonGuildPositionArg oArg = new ChangeDragonGuildPositionArg();

		// Token: 0x0400660F RID: 26127
		public ChangeDragonGuildPositionRes oRes = null;
	}
}
