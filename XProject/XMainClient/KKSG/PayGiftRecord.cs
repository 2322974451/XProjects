using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000628 RID: 1576
	[ProtoContract(Name = "PayGiftRecord")]
	[Serializable]
	public class PayGiftRecord : IExtensible
	{
		// Token: 0x17001E66 RID: 7782
		// (get) Token: 0x060060A4 RID: 24740 RVA: 0x000B8528 File Offset: 0x000B6728
		// (set) Token: 0x060060A5 RID: 24741 RVA: 0x000B8554 File Offset: 0x000B6754
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x17001E67 RID: 7783
		// (get) Token: 0x060060A6 RID: 24742 RVA: 0x000B8564 File Offset: 0x000B6764
		// (set) Token: 0x060060A7 RID: 24743 RVA: 0x000B8584 File Offset: 0x000B6784
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060060A8 RID: 24744 RVA: 0x000B85C8 File Offset: 0x000B67C8
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060060A9 RID: 24745 RVA: 0x000B85E0 File Offset: 0x000B67E0
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001E68 RID: 7784
		// (get) Token: 0x060060AA RID: 24746 RVA: 0x000B85EC File Offset: 0x000B67EC
		// (set) Token: 0x060060AB RID: 24747 RVA: 0x000B8618 File Offset: 0x000B6818
		[ProtoMember(2, IsRequired = false, Name = "buycount", DataFormat = DataFormat.TwosComplement)]
		public uint buycount
		{
			get
			{
				return this._buycount ?? 0U;
			}
			set
			{
				this._buycount = new uint?(value);
			}
		}

		// Token: 0x17001E69 RID: 7785
		// (get) Token: 0x060060AC RID: 24748 RVA: 0x000B8628 File Offset: 0x000B6828
		// (set) Token: 0x060060AD RID: 24749 RVA: 0x000B8648 File Offset: 0x000B6848
		[XmlIgnore]
		[Browsable(false)]
		public bool buycountSpecified
		{
			get
			{
				return this._buycount != null;
			}
			set
			{
				bool flag = value == (this._buycount == null);
				if (flag)
				{
					this._buycount = (value ? new uint?(this.buycount) : null);
				}
			}
		}

		// Token: 0x060060AE RID: 24750 RVA: 0x000B868C File Offset: 0x000B688C
		private bool ShouldSerializebuycount()
		{
			return this.buycountSpecified;
		}

		// Token: 0x060060AF RID: 24751 RVA: 0x000B86A4 File Offset: 0x000B68A4
		private void Resetbuycount()
		{
			this.buycountSpecified = false;
		}

		// Token: 0x17001E6A RID: 7786
		// (get) Token: 0x060060B0 RID: 24752 RVA: 0x000B86B0 File Offset: 0x000B68B0
		// (set) Token: 0x060060B1 RID: 24753 RVA: 0x000B86DC File Offset: 0x000B68DC
		[ProtoMember(3, IsRequired = false, Name = "lastBuyTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastBuyTime
		{
			get
			{
				return this._lastBuyTime ?? 0U;
			}
			set
			{
				this._lastBuyTime = new uint?(value);
			}
		}

		// Token: 0x17001E6B RID: 7787
		// (get) Token: 0x060060B2 RID: 24754 RVA: 0x000B86EC File Offset: 0x000B68EC
		// (set) Token: 0x060060B3 RID: 24755 RVA: 0x000B870C File Offset: 0x000B690C
		[XmlIgnore]
		[Browsable(false)]
		public bool lastBuyTimeSpecified
		{
			get
			{
				return this._lastBuyTime != null;
			}
			set
			{
				bool flag = value == (this._lastBuyTime == null);
				if (flag)
				{
					this._lastBuyTime = (value ? new uint?(this.lastBuyTime) : null);
				}
			}
		}

		// Token: 0x060060B4 RID: 24756 RVA: 0x000B8750 File Offset: 0x000B6950
		private bool ShouldSerializelastBuyTime()
		{
			return this.lastBuyTimeSpecified;
		}

		// Token: 0x060060B5 RID: 24757 RVA: 0x000B8768 File Offset: 0x000B6968
		private void ResetlastBuyTime()
		{
			this.lastBuyTimeSpecified = false;
		}

		// Token: 0x17001E6C RID: 7788
		// (get) Token: 0x060060B6 RID: 24758 RVA: 0x000B8774 File Offset: 0x000B6974
		// (set) Token: 0x060060B7 RID: 24759 RVA: 0x000B87A0 File Offset: 0x000B69A0
		[ProtoMember(4, IsRequired = false, Name = "reqTime", DataFormat = DataFormat.TwosComplement)]
		public uint reqTime
		{
			get
			{
				return this._reqTime ?? 0U;
			}
			set
			{
				this._reqTime = new uint?(value);
			}
		}

		// Token: 0x17001E6D RID: 7789
		// (get) Token: 0x060060B8 RID: 24760 RVA: 0x000B87B0 File Offset: 0x000B69B0
		// (set) Token: 0x060060B9 RID: 24761 RVA: 0x000B87D0 File Offset: 0x000B69D0
		[XmlIgnore]
		[Browsable(false)]
		public bool reqTimeSpecified
		{
			get
			{
				return this._reqTime != null;
			}
			set
			{
				bool flag = value == (this._reqTime == null);
				if (flag)
				{
					this._reqTime = (value ? new uint?(this.reqTime) : null);
				}
			}
		}

		// Token: 0x060060BA RID: 24762 RVA: 0x000B8814 File Offset: 0x000B6A14
		private bool ShouldSerializereqTime()
		{
			return this.reqTimeSpecified;
		}

		// Token: 0x060060BB RID: 24763 RVA: 0x000B882C File Offset: 0x000B6A2C
		private void ResetreqTime()
		{
			this.reqTimeSpecified = false;
		}

		// Token: 0x060060BC RID: 24764 RVA: 0x000B8838 File Offset: 0x000B6A38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001774 RID: 6004
		private uint? _id;

		// Token: 0x04001775 RID: 6005
		private uint? _buycount;

		// Token: 0x04001776 RID: 6006
		private uint? _lastBuyTime;

		// Token: 0x04001777 RID: 6007
		private uint? _reqTime;

		// Token: 0x04001778 RID: 6008
		private IExtension extensionObject;
	}
}
