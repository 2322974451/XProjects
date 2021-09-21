using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001C0 RID: 448
	[ProtoContract(Name = "UpdateVoipRoomMemberNtf")]
	[Serializable]
	public class UpdateVoipRoomMemberNtf : IExtensible
	{
		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x06001A1C RID: 6684 RVA: 0x00033B98 File Offset: 0x00031D98
		[ProtoMember(1, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<VoipRoomMember> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x06001A1D RID: 6685 RVA: 0x00033BB0 File Offset: 0x00031DB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400067D RID: 1661
		private readonly List<VoipRoomMember> _dataList = new List<VoipRoomMember>();

		// Token: 0x0400067E RID: 1662
		private IExtension extensionObject;
	}
}
