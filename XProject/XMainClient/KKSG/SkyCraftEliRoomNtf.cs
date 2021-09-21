using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003DF RID: 991
	[ProtoContract(Name = "SkyCraftEliRoomNtf")]
	[Serializable]
	public class SkyCraftEliRoomNtf : IExtensible
	{
		// Token: 0x17001038 RID: 4152
		// (get) Token: 0x060034B8 RID: 13496 RVA: 0x0006513C File Offset: 0x0006333C
		// (set) Token: 0x060034B9 RID: 13497 RVA: 0x00065154 File Offset: 0x00063354
		[ProtoMember(1, IsRequired = false, Name = "room", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SCEliRoomInfo room
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

		// Token: 0x060034BA RID: 13498 RVA: 0x00065160 File Offset: 0x00063360
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000D17 RID: 3351
		private SCEliRoomInfo _room = null;

		// Token: 0x04000D18 RID: 3352
		private IExtension extensionObject;
	}
}
