using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000635 RID: 1589
	[ProtoContract(Name = "RiskGridInfo")]
	[Serializable]
	public class RiskGridInfo : IExtensible
	{
		// Token: 0x17001EC1 RID: 7873
		// (get) Token: 0x060061B0 RID: 25008 RVA: 0x000BA5C4 File Offset: 0x000B87C4
		// (set) Token: 0x060061B1 RID: 25009 RVA: 0x000BA5F0 File Offset: 0x000B87F0
		[ProtoMember(1, IsRequired = false, Name = "x", DataFormat = DataFormat.TwosComplement)]
		public int x
		{
			get
			{
				return this._x ?? 0;
			}
			set
			{
				this._x = new int?(value);
			}
		}

		// Token: 0x17001EC2 RID: 7874
		// (get) Token: 0x060061B2 RID: 25010 RVA: 0x000BA600 File Offset: 0x000B8800
		// (set) Token: 0x060061B3 RID: 25011 RVA: 0x000BA620 File Offset: 0x000B8820
		[XmlIgnore]
		[Browsable(false)]
		public bool xSpecified
		{
			get
			{
				return this._x != null;
			}
			set
			{
				bool flag = value == (this._x == null);
				if (flag)
				{
					this._x = (value ? new int?(this.x) : null);
				}
			}
		}

		// Token: 0x060061B4 RID: 25012 RVA: 0x000BA664 File Offset: 0x000B8864
		private bool ShouldSerializex()
		{
			return this.xSpecified;
		}

		// Token: 0x060061B5 RID: 25013 RVA: 0x000BA67C File Offset: 0x000B887C
		private void Resetx()
		{
			this.xSpecified = false;
		}

		// Token: 0x17001EC3 RID: 7875
		// (get) Token: 0x060061B6 RID: 25014 RVA: 0x000BA688 File Offset: 0x000B8888
		// (set) Token: 0x060061B7 RID: 25015 RVA: 0x000BA6B4 File Offset: 0x000B88B4
		[ProtoMember(2, IsRequired = false, Name = "y", DataFormat = DataFormat.TwosComplement)]
		public int y
		{
			get
			{
				return this._y ?? 0;
			}
			set
			{
				this._y = new int?(value);
			}
		}

		// Token: 0x17001EC4 RID: 7876
		// (get) Token: 0x060061B8 RID: 25016 RVA: 0x000BA6C4 File Offset: 0x000B88C4
		// (set) Token: 0x060061B9 RID: 25017 RVA: 0x000BA6E4 File Offset: 0x000B88E4
		[XmlIgnore]
		[Browsable(false)]
		public bool ySpecified
		{
			get
			{
				return this._y != null;
			}
			set
			{
				bool flag = value == (this._y == null);
				if (flag)
				{
					this._y = (value ? new int?(this.y) : null);
				}
			}
		}

		// Token: 0x060061BA RID: 25018 RVA: 0x000BA728 File Offset: 0x000B8928
		private bool ShouldSerializey()
		{
			return this.ySpecified;
		}

		// Token: 0x060061BB RID: 25019 RVA: 0x000BA740 File Offset: 0x000B8940
		private void Resety()
		{
			this.ySpecified = false;
		}

		// Token: 0x17001EC5 RID: 7877
		// (get) Token: 0x060061BC RID: 25020 RVA: 0x000BA74C File Offset: 0x000B894C
		// (set) Token: 0x060061BD RID: 25021 RVA: 0x000BA778 File Offset: 0x000B8978
		[ProtoMember(3, IsRequired = false, Name = "gridType", DataFormat = DataFormat.TwosComplement)]
		public RiskGridType gridType
		{
			get
			{
				return this._gridType ?? RiskGridType.RISK_GRID_EMPTY;
			}
			set
			{
				this._gridType = new RiskGridType?(value);
			}
		}

		// Token: 0x17001EC6 RID: 7878
		// (get) Token: 0x060061BE RID: 25022 RVA: 0x000BA788 File Offset: 0x000B8988
		// (set) Token: 0x060061BF RID: 25023 RVA: 0x000BA7A8 File Offset: 0x000B89A8
		[XmlIgnore]
		[Browsable(false)]
		public bool gridTypeSpecified
		{
			get
			{
				return this._gridType != null;
			}
			set
			{
				bool flag = value == (this._gridType == null);
				if (flag)
				{
					this._gridType = (value ? new RiskGridType?(this.gridType) : null);
				}
			}
		}

		// Token: 0x060061C0 RID: 25024 RVA: 0x000BA7EC File Offset: 0x000B89EC
		private bool ShouldSerializegridType()
		{
			return this.gridTypeSpecified;
		}

		// Token: 0x060061C1 RID: 25025 RVA: 0x000BA804 File Offset: 0x000B8A04
		private void ResetgridType()
		{
			this.gridTypeSpecified = false;
		}

		// Token: 0x17001EC7 RID: 7879
		// (get) Token: 0x060061C2 RID: 25026 RVA: 0x000BA810 File Offset: 0x000B8A10
		// (set) Token: 0x060061C3 RID: 25027 RVA: 0x000BA828 File Offset: 0x000B8A28
		[ProtoMember(4, IsRequired = false, Name = "rewardItem", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief rewardItem
		{
			get
			{
				return this._rewardItem;
			}
			set
			{
				this._rewardItem = value;
			}
		}

		// Token: 0x17001EC8 RID: 7880
		// (get) Token: 0x060061C4 RID: 25028 RVA: 0x000BA834 File Offset: 0x000B8A34
		// (set) Token: 0x060061C5 RID: 25029 RVA: 0x000BA860 File Offset: 0x000B8A60
		[ProtoMember(5, IsRequired = false, Name = "boxState", DataFormat = DataFormat.TwosComplement)]
		public RiskBoxState boxState
		{
			get
			{
				return this._boxState ?? RiskBoxState.RISK_BOX_LOCKED;
			}
			set
			{
				this._boxState = new RiskBoxState?(value);
			}
		}

		// Token: 0x17001EC9 RID: 7881
		// (get) Token: 0x060061C6 RID: 25030 RVA: 0x000BA870 File Offset: 0x000B8A70
		// (set) Token: 0x060061C7 RID: 25031 RVA: 0x000BA890 File Offset: 0x000B8A90
		[XmlIgnore]
		[Browsable(false)]
		public bool boxStateSpecified
		{
			get
			{
				return this._boxState != null;
			}
			set
			{
				bool flag = value == (this._boxState == null);
				if (flag)
				{
					this._boxState = (value ? new RiskBoxState?(this.boxState) : null);
				}
			}
		}

		// Token: 0x060061C8 RID: 25032 RVA: 0x000BA8D4 File Offset: 0x000B8AD4
		private bool ShouldSerializeboxState()
		{
			return this.boxStateSpecified;
		}

		// Token: 0x060061C9 RID: 25033 RVA: 0x000BA8EC File Offset: 0x000B8AEC
		private void ResetboxState()
		{
			this.boxStateSpecified = false;
		}

		// Token: 0x060061CA RID: 25034 RVA: 0x000BA8F8 File Offset: 0x000B8AF8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017B7 RID: 6071
		private int? _x;

		// Token: 0x040017B8 RID: 6072
		private int? _y;

		// Token: 0x040017B9 RID: 6073
		private RiskGridType? _gridType;

		// Token: 0x040017BA RID: 6074
		private ItemBrief _rewardItem = null;

		// Token: 0x040017BB RID: 6075
		private RiskBoxState? _boxState;

		// Token: 0x040017BC RID: 6076
		private IExtension extensionObject;
	}
}
