using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200105F RID: 4191
	internal class RpcC2G_AddTempAttr : Rpc
	{
		// Token: 0x0600D635 RID: 54837 RVA: 0x00325C70 File Offset: 0x00323E70
		public override uint GetRpcType()
		{
			return 22021U;
		}

		// Token: 0x0600D636 RID: 54838 RVA: 0x00325C87 File Offset: 0x00323E87
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddTempAttrArg>(stream, this.oArg);
		}

		// Token: 0x0600D637 RID: 54839 RVA: 0x00325C97 File Offset: 0x00323E97
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddTempAttrRes>(stream);
		}

		// Token: 0x0600D638 RID: 54840 RVA: 0x00325CA6 File Offset: 0x00323EA6
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AddTempAttr.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D639 RID: 54841 RVA: 0x00325CC2 File Offset: 0x00323EC2
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AddTempAttr.OnTimeout(this.oArg);
		}

		// Token: 0x0400616D RID: 24941
		public AddTempAttrArg oArg = new AddTempAttrArg();

		// Token: 0x0400616E RID: 24942
		public AddTempAttrRes oRes = new AddTempAttrRes();
	}
}
