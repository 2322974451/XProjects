using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013B2 RID: 5042
	internal class RpcC2M_JoinFmRoom : Rpc
	{
		// Token: 0x0600E3C5 RID: 58309 RVA: 0x0033ACC0 File Offset: 0x00338EC0
		public override uint GetRpcType()
		{
			return 25303U;
		}

		// Token: 0x0600E3C6 RID: 58310 RVA: 0x0033ACD7 File Offset: 0x00338ED7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinLargeRoomArg>(stream, this.oArg);
		}

		// Token: 0x0600E3C7 RID: 58311 RVA: 0x0033ACE7 File Offset: 0x00338EE7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JoinLargeRoomRes>(stream);
		}

		// Token: 0x0600E3C8 RID: 58312 RVA: 0x0033ACF6 File Offset: 0x00338EF6
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_JoinFmRoom.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E3C9 RID: 58313 RVA: 0x0033AD12 File Offset: 0x00338F12
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_JoinFmRoom.OnTimeout(this.oArg);
		}

		// Token: 0x040063FF RID: 25599
		public JoinLargeRoomArg oArg = new JoinLargeRoomArg();

		// Token: 0x04006400 RID: 25600
		public JoinLargeRoomRes oRes = null;
	}
}
