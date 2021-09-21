using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011C9 RID: 4553
	internal class PtcG2C_JoinRoomReply : Protocol
	{
		// Token: 0x0600DBEC RID: 56300 RVA: 0x0032FA7C File Offset: 0x0032DC7C
		public override uint GetProtoType()
		{
			return 23084U;
		}

		// Token: 0x0600DBED RID: 56301 RVA: 0x0032FA93 File Offset: 0x0032DC93
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JoinRoomReply>(stream, this.Data);
		}

		// Token: 0x0600DBEE RID: 56302 RVA: 0x0032FAA3 File Offset: 0x0032DCA3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<JoinRoomReply>(stream);
		}

		// Token: 0x0600DBEF RID: 56303 RVA: 0x0032FAB2 File Offset: 0x0032DCB2
		public override void Process()
		{
			Process_PtcG2C_JoinRoomReply.Process(this);
		}

		// Token: 0x0400627A RID: 25210
		public JoinRoomReply Data = new JoinRoomReply();
	}
}
