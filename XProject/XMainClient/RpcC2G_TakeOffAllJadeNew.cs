using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020016AB RID: 5803
	internal class RpcC2G_TakeOffAllJadeNew : Rpc
	{
		// Token: 0x0600F005 RID: 61445 RVA: 0x0034C264 File Offset: 0x0034A464
		public override uint GetRpcType()
		{
			return 33760U;
		}

		// Token: 0x0600F006 RID: 61446 RVA: 0x0034C27B File Offset: 0x0034A47B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TakeOffAllJadeNewArg>(stream, this.oArg);
		}

		// Token: 0x0600F007 RID: 61447 RVA: 0x0034C28B File Offset: 0x0034A48B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TakeOffAllJadeNewRes>(stream);
		}

		// Token: 0x0600F008 RID: 61448 RVA: 0x0034C29A File Offset: 0x0034A49A
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_TakeOffAllJadeNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600F009 RID: 61449 RVA: 0x0034C2B6 File Offset: 0x0034A4B6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_TakeOffAllJadeNew.OnTimeout(this.oArg);
		}

		// Token: 0x0400666B RID: 26219
		public TakeOffAllJadeNewArg oArg = new TakeOffAllJadeNewArg();

		// Token: 0x0400666C RID: 26220
		public TakeOffAllJadeNewRes oRes = null;
	}
}
