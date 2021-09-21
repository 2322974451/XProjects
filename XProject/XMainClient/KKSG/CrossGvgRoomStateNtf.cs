using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000545 RID: 1349
	[ProtoContract(Name = "CrossGvgRoomStateNtf")]
	[Serializable]
	public class CrossGvgRoomStateNtf : IExtensible
	{
		// Token: 0x17001512 RID: 5394
		// (get) Token: 0x060044F2 RID: 17650 RVA: 0x000831BC File Offset: 0x000813BC
		// (set) Token: 0x060044F3 RID: 17651 RVA: 0x000831D4 File Offset: 0x000813D4
		[ProtoMember(1, IsRequired = false, Name = "room", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CrossGvgRoomInfo room
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

		// Token: 0x17001513 RID: 5395
		// (get) Token: 0x060044F4 RID: 17652 RVA: 0x000831E0 File Offset: 0x000813E0
		// (set) Token: 0x060044F5 RID: 17653 RVA: 0x000831F8 File Offset: 0x000813F8
		[ProtoMember(2, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CrossGvgRacePointRecord record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		// Token: 0x060044F6 RID: 17654 RVA: 0x00083204 File Offset: 0x00081404
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400113B RID: 4411
		private CrossGvgRoomInfo _room = null;

		// Token: 0x0400113C RID: 4412
		private CrossGvgRacePointRecord _record = null;

		// Token: 0x0400113D RID: 4413
		private IExtension extensionObject;
	}
}
