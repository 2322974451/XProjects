using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200149E RID: 5278
	internal class RpcC2M_ClickNewNotice : Rpc
	{
		// Token: 0x0600E781 RID: 59265 RVA: 0x00340184 File Offset: 0x0033E384
		public override uint GetRpcType()
		{
			return 50366U;
		}

		// Token: 0x0600E782 RID: 59266 RVA: 0x0034019B File Offset: 0x0033E39B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ClickNewNoticeArg>(stream, this.oArg);
		}

		// Token: 0x0600E783 RID: 59267 RVA: 0x003401AB File Offset: 0x0033E3AB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ClickNewNoticeRes>(stream);
		}

		// Token: 0x0600E784 RID: 59268 RVA: 0x003401BA File Offset: 0x0033E3BA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ClickNewNotice.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E785 RID: 59269 RVA: 0x003401D6 File Offset: 0x0033E3D6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ClickNewNotice.OnTimeout(this.oArg);
		}

		// Token: 0x040064B1 RID: 25777
		public ClickNewNoticeArg oArg = new ClickNewNoticeArg();

		// Token: 0x040064B2 RID: 25778
		public ClickNewNoticeRes oRes = null;
	}
}
