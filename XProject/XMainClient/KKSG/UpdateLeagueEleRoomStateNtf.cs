using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003A1 RID: 929
	[ProtoContract(Name = "UpdateLeagueEleRoomStateNtf")]
	[Serializable]
	public class UpdateLeagueEleRoomStateNtf : IExtensible
	{
		// Token: 0x17000F7A RID: 3962
		// (get) Token: 0x0600321C RID: 12828 RVA: 0x000607A0 File Offset: 0x0005E9A0
		// (set) Token: 0x0600321D RID: 12829 RVA: 0x000607B8 File Offset: 0x0005E9B8
		[ProtoMember(1, IsRequired = false, Name = "room", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LBEleRoomInfo room
		{
			get
			{
				return this._room;
			}
			set
			{
				this._room = value;
			}
		}

		// Token: 0x0600321E RID: 12830 RVA: 0x000607C4 File Offset: 0x0005E9C4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000C71 RID: 3185
		private LBEleRoomInfo _room = null;

		// Token: 0x04000C72 RID: 3186
		private IExtension extensionObject;
	}
}
