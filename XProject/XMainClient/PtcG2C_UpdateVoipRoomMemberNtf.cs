using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020011CC RID: 4556
	internal class PtcG2C_UpdateVoipRoomMemberNtf : Protocol
	{
		// Token: 0x0600DBF8 RID: 56312 RVA: 0x0032FB44 File Offset: 0x0032DD44
		public override uint GetProtoType()
		{
			return 25546U;
		}

		// Token: 0x0600DBF9 RID: 56313 RVA: 0x0032FB5B File Offset: 0x0032DD5B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateVoipRoomMemberNtf>(stream, this.Data);
		}

		// Token: 0x0600DBFA RID: 56314 RVA: 0x0032FB6B File Offset: 0x0032DD6B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateVoipRoomMemberNtf>(stream);
		}

		// Token: 0x0600DBFB RID: 56315 RVA: 0x0032FB7A File Offset: 0x0032DD7A
		public override void Process()
		{
			Process_PtcG2C_UpdateVoipRoomMemberNtf.Process(this);
		}

		// Token: 0x0400627C RID: 25212
		public UpdateVoipRoomMemberNtf Data = new UpdateVoipRoomMemberNtf();
	}
}
