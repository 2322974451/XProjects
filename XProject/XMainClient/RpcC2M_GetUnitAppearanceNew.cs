using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001446 RID: 5190
	internal class RpcC2M_GetUnitAppearanceNew : Rpc
	{
		// Token: 0x0600E622 RID: 58914 RVA: 0x0033DEB0 File Offset: 0x0033C0B0
		public override uint GetRpcType()
		{
			return 40593U;
		}

		// Token: 0x0600E623 RID: 58915 RVA: 0x0033DEC7 File Offset: 0x0033C0C7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetUnitAppearanceArg>(stream, this.oArg);
		}

		// Token: 0x0600E624 RID: 58916 RVA: 0x0033DED7 File Offset: 0x0033C0D7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetUnitAppearanceRes>(stream);
		}

		// Token: 0x0600E625 RID: 58917 RVA: 0x0033DEE6 File Offset: 0x0033C0E6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetUnitAppearanceNew.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E626 RID: 58918 RVA: 0x0033DF02 File Offset: 0x0033C102
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetUnitAppearanceNew.OnTimeout(this.oArg);
		}

		// Token: 0x04006472 RID: 25714
		public GetUnitAppearanceArg oArg = new GetUnitAppearanceArg();

		// Token: 0x04006473 RID: 25715
		public GetUnitAppearanceRes oRes = null;
	}
}
