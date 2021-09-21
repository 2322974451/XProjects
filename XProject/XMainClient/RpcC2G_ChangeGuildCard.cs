using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200107F RID: 4223
	internal class RpcC2G_ChangeGuildCard : Rpc
	{
		// Token: 0x0600D6B8 RID: 54968 RVA: 0x003268C0 File Offset: 0x00324AC0
		public override uint GetRpcType()
		{
			return 55997U;
		}

		// Token: 0x0600D6B9 RID: 54969 RVA: 0x003268D7 File Offset: 0x00324AD7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeGuildCardArg>(stream, this.oArg);
		}

		// Token: 0x0600D6BA RID: 54970 RVA: 0x003268E7 File Offset: 0x00324AE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeGuildCardRes>(stream);
		}

		// Token: 0x0600D6BB RID: 54971 RVA: 0x003268F6 File Offset: 0x00324AF6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeGuildCard.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D6BC RID: 54972 RVA: 0x00326912 File Offset: 0x00324B12
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeGuildCard.OnTimeout(this.oArg);
		}

		// Token: 0x04006186 RID: 24966
		public ChangeGuildCardArg oArg = new ChangeGuildCardArg();

		// Token: 0x04006187 RID: 24967
		public ChangeGuildCardRes oRes = new ChangeGuildCardRes();
	}
}
