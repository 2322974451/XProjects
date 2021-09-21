using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200104F RID: 4175
	internal class RpcC2G_Revive : Rpc
	{
		// Token: 0x0600D5F2 RID: 54770 RVA: 0x00325388 File Offset: 0x00323588
		public override uint GetRpcType()
		{
			return 29831U;
		}

		// Token: 0x0600D5F3 RID: 54771 RVA: 0x0032539F File Offset: 0x0032359F
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReviveArg>(stream, this.oArg);
		}

		// Token: 0x0600D5F4 RID: 54772 RVA: 0x003253AF File Offset: 0x003235AF
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReviveRes>(stream);
		}

		// Token: 0x0600D5F5 RID: 54773 RVA: 0x003253BE File Offset: 0x003235BE
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Revive.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D5F6 RID: 54774 RVA: 0x003253DA File Offset: 0x003235DA
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Revive.OnTimeout(this.oArg);
		}

		// Token: 0x0400615A RID: 24922
		public ReviveArg oArg = new ReviveArg();

		// Token: 0x0400615B RID: 24923
		public ReviveRes oRes = new ReviveRes();
	}
}
