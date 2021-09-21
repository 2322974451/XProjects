using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011A6 RID: 4518
	internal class RpcC2M_AddBlackListNew : Rpc
	{
		// Token: 0x0600DB5F RID: 56159 RVA: 0x0032EF0C File Offset: 0x0032D10C
		public override uint GetRpcType()
		{
			return 265U;
		}

		// Token: 0x0600DB60 RID: 56160 RVA: 0x0032EF23 File Offset: 0x0032D123
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AddBlackListArg>(stream, this.oArg);
		}

		// Token: 0x0600DB61 RID: 56161 RVA: 0x0032EF33 File Offset: 0x0032D133
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AddBlackListRes>(stream);
		}

		// Token: 0x0600DB62 RID: 56162 RVA: 0x0032EF42 File Offset: 0x0032D142
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AddBlackListNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600DB63 RID: 56163 RVA: 0x0032EF5E File Offset: 0x0032D15E
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AddBlackListNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006260 RID: 25184
		public AddBlackListArg oArg = new AddBlackListArg();

		// Token: 0x04006261 RID: 25185
		public AddBlackListRes oRes = null;
	}
}
