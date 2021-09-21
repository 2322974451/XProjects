using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000614 RID: 1556
	[ProtoContract(Name = "LoginReward")]
	[Serializable]
	public class LoginReward : IExtensible
	{
		// Token: 0x17001D8E RID: 7566
		// (get) Token: 0x06005E36 RID: 24118 RVA: 0x000B397C File Offset: 0x000B1B7C
		// (set) Token: 0x06005E37 RID: 24119 RVA: 0x000B39A8 File Offset: 0x000B1BA8
		[ProtoMember(1, IsRequired = false, Name = "day", DataFormat = DataFormat.TwosComplement)]
		public int day
		{
			get
			{
				return this._day ?? 0;
			}
			set
			{
				this._day = new int?(value);
			}
		}

		// Token: 0x17001D8F RID: 7567
		// (get) Token: 0x06005E38 RID: 24120 RVA: 0x000B39B8 File Offset: 0x000B1BB8
		// (set) Token: 0x06005E39 RID: 24121 RVA: 0x000B39D8 File Offset: 0x000B1BD8
		[XmlIgnore]
		[Browsable(false)]
		public bool daySpecified
		{
			get
			{
				return this._day != null;
			}
			set
			{
				bool flag = value == (this._day == null);
				if (flag)
				{
					this._day = (value ? new int?(this.day) : null);
				}
			}
		}

		// Token: 0x06005E3A RID: 24122 RVA: 0x000B3A1C File Offset: 0x000B1C1C
		private bool ShouldSerializeday()
		{
			return this.daySpecified;
		}

		// Token: 0x06005E3B RID: 24123 RVA: 0x000B3A34 File Offset: 0x000B1C34
		private void Resetday()
		{
			this.daySpecified = false;
		}

		// Token: 0x17001D90 RID: 7568
		// (get) Token: 0x06005E3C RID: 24124 RVA: 0x000B3A40 File Offset: 0x000B1C40
		// (set) Token: 0x06005E3D RID: 24125 RVA: 0x000B3A6C File Offset: 0x000B1C6C
		[ProtoMember(2, IsRequired = false, Name = "itemID", DataFormat = DataFormat.TwosComplement)]
		public uint itemID
		{
			get
			{
				return this._itemID ?? 0U;
			}
			set
			{
				this._itemID = new uint?(value);
			}
		}

		// Token: 0x17001D91 RID: 7569
		// (get) Token: 0x06005E3E RID: 24126 RVA: 0x000B3A7C File Offset: 0x000B1C7C
		// (set) Token: 0x06005E3F RID: 24127 RVA: 0x000B3A9C File Offset: 0x000B1C9C
		[XmlIgnore]
		[Browsable(false)]
		public bool itemIDSpecified
		{
			get
			{
				return this._itemID != null;
			}
			set
			{
				bool flag = value == (this._itemID == null);
				if (flag)
				{
					this._itemID = (value ? new uint?(this.itemID) : null);
				}
			}
		}

		// Token: 0x06005E40 RID: 24128 RVA: 0x000B3AE0 File Offset: 0x000B1CE0
		private bool ShouldSerializeitemID()
		{
			return this.itemIDSpecified;
		}

		// Token: 0x06005E41 RID: 24129 RVA: 0x000B3AF8 File Offset: 0x000B1CF8
		private void ResetitemID()
		{
			this.itemIDSpecified = false;
		}

		// Token: 0x17001D92 RID: 7570
		// (get) Token: 0x06005E42 RID: 24130 RVA: 0x000B3B04 File Offset: 0x000B1D04
		// (set) Token: 0x06005E43 RID: 24131 RVA: 0x000B3B30 File Offset: 0x000B1D30
		[ProtoMember(3, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LoginRewardState state
		{
			get
			{
				return this._state ?? LoginRewardState.LOGINRS_CANNOT;
			}
			set
			{
				this._state = new LoginRewardState?(value);
			}
		}

		// Token: 0x17001D93 RID: 7571
		// (get) Token: 0x06005E44 RID: 24132 RVA: 0x000B3B40 File Offset: 0x000B1D40
		// (set) Token: 0x06005E45 RID: 24133 RVA: 0x000B3B60 File Offset: 0x000B1D60
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new LoginRewardState?(this.state) : null);
				}
			}
		}

		// Token: 0x06005E46 RID: 24134 RVA: 0x000B3BA4 File Offset: 0x000B1DA4
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x06005E47 RID: 24135 RVA: 0x000B3BBC File Offset: 0x000B1DBC
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x17001D94 RID: 7572
		// (get) Token: 0x06005E48 RID: 24136 RVA: 0x000B3BC8 File Offset: 0x000B1DC8
		[ProtoMember(4, Name = "items", DataFormat = DataFormat.Default)]
		public List<ItemBrief> items
		{
			get
			{
				return this._items;
			}
		}

		// Token: 0x06005E49 RID: 24137 RVA: 0x000B3BE0 File Offset: 0x000B1DE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016E1 RID: 5857
		private int? _day;

		// Token: 0x040016E2 RID: 5858
		private uint? _itemID;

		// Token: 0x040016E3 RID: 5859
		private LoginRewardState? _state;

		// Token: 0x040016E4 RID: 5860
		private readonly List<ItemBrief> _items = new List<ItemBrief>();

		// Token: 0x040016E5 RID: 5861
		private IExtension extensionObject;
	}
}
