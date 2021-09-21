using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200119E RID: 4510
	internal class PtcM2C_FriendOpNtfNew : Protocol
	{
		// Token: 0x0600DB3C RID: 56124 RVA: 0x0032EC34 File Offset: 0x0032CE34
		public override uint GetProtoType()
		{
			return 22609U;
		}

		// Token: 0x0600DB3D RID: 56125 RVA: 0x0032EC4B File Offset: 0x0032CE4B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FriendOpNotify>(stream, this.Data);
		}

		// Token: 0x0600DB3E RID: 56126 RVA: 0x0032EC5B File Offset: 0x0032CE5B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<FriendOpNotify>(stream);
		}

		// Token: 0x0600DB3F RID: 56127 RVA: 0x0032EC6A File Offset: 0x0032CE6A
		public override void Process()
		{
			Process_PtcM2C_FriendOpNtfNew.Process(this);
		}

		// Token: 0x04006259 RID: 25177
		public FriendOpNotify Data = new FriendOpNotify();
	}
}
