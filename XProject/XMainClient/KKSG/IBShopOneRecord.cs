using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200062D RID: 1581
	[ProtoContract(Name = "IBShopOneRecord")]
	[Serializable]
	public class IBShopOneRecord : IExtensible
	{
		// Token: 0x17001E8F RID: 7823
		// (get) Token: 0x0600611F RID: 24863 RVA: 0x000B9464 File Offset: 0x000B7664
		// (set) Token: 0x06006120 RID: 24864 RVA: 0x000B9490 File Offset: 0x000B7690
		[ProtoMember(1, IsRequired = false, Name = "nGoodsID", DataFormat = DataFormat.TwosComplement)]
		public uint nGoodsID
		{
			get
			{
				return this._nGoodsID ?? 0U;
			}
			set
			{
				this._nGoodsID = new uint?(value);
			}
		}

		// Token: 0x17001E90 RID: 7824
		// (get) Token: 0x06006121 RID: 24865 RVA: 0x000B94A0 File Offset: 0x000B76A0
		// (set) Token: 0x06006122 RID: 24866 RVA: 0x000B94C0 File Offset: 0x000B76C0
		[XmlIgnore]
		[Browsable(false)]
		public bool nGoodsIDSpecified
		{
			get
			{
				return this._nGoodsID != null;
			}
			set
			{
				bool flag = value == (this._nGoodsID == null);
				if (flag)
				{
					this._nGoodsID = (value ? new uint?(this.nGoodsID) : null);
				}
			}
		}

		// Token: 0x06006123 RID: 24867 RVA: 0x000B9504 File Offset: 0x000B7704
		private bool ShouldSerializenGoodsID()
		{
			return this.nGoodsIDSpecified;
		}

		// Token: 0x06006124 RID: 24868 RVA: 0x000B951C File Offset: 0x000B771C
		private void ResetnGoodsID()
		{
			this.nGoodsIDSpecified = false;
		}

		// Token: 0x17001E91 RID: 7825
		// (get) Token: 0x06006125 RID: 24869 RVA: 0x000B9528 File Offset: 0x000B7728
		// (set) Token: 0x06006126 RID: 24870 RVA: 0x000B9554 File Offset: 0x000B7754
		[ProtoMember(2, IsRequired = false, Name = "activity", DataFormat = DataFormat.TwosComplement)]
		public uint activity
		{
			get
			{
				return this._activity ?? 0U;
			}
			set
			{
				this._activity = new uint?(value);
			}
		}

		// Token: 0x17001E92 RID: 7826
		// (get) Token: 0x06006127 RID: 24871 RVA: 0x000B9564 File Offset: 0x000B7764
		// (set) Token: 0x06006128 RID: 24872 RVA: 0x000B9584 File Offset: 0x000B7784
		[XmlIgnore]
		[Browsable(false)]
		public bool activitySpecified
		{
			get
			{
				return this._activity != null;
			}
			set
			{
				bool flag = value == (this._activity == null);
				if (flag)
				{
					this._activity = (value ? new uint?(this.activity) : null);
				}
			}
		}

		// Token: 0x06006129 RID: 24873 RVA: 0x000B95C8 File Offset: 0x000B77C8
		private bool ShouldSerializeactivity()
		{
			return this.activitySpecified;
		}

		// Token: 0x0600612A RID: 24874 RVA: 0x000B95E0 File Offset: 0x000B77E0
		private void Resetactivity()
		{
			this.activitySpecified = false;
		}

		// Token: 0x17001E93 RID: 7827
		// (get) Token: 0x0600612B RID: 24875 RVA: 0x000B95EC File Offset: 0x000B77EC
		// (set) Token: 0x0600612C RID: 24876 RVA: 0x000B9618 File Offset: 0x000B7818
		[ProtoMember(3, IsRequired = false, Name = "activitytime", DataFormat = DataFormat.TwosComplement)]
		public uint activitytime
		{
			get
			{
				return this._activitytime ?? 0U;
			}
			set
			{
				this._activitytime = new uint?(value);
			}
		}

		// Token: 0x17001E94 RID: 7828
		// (get) Token: 0x0600612D RID: 24877 RVA: 0x000B9628 File Offset: 0x000B7828
		// (set) Token: 0x0600612E RID: 24878 RVA: 0x000B9648 File Offset: 0x000B7848
		[XmlIgnore]
		[Browsable(false)]
		public bool activitytimeSpecified
		{
			get
			{
				return this._activitytime != null;
			}
			set
			{
				bool flag = value == (this._activitytime == null);
				if (flag)
				{
					this._activitytime = (value ? new uint?(this.activitytime) : null);
				}
			}
		}

		// Token: 0x0600612F RID: 24879 RVA: 0x000B968C File Offset: 0x000B788C
		private bool ShouldSerializeactivitytime()
		{
			return this.activitytimeSpecified;
		}

		// Token: 0x06006130 RID: 24880 RVA: 0x000B96A4 File Offset: 0x000B78A4
		private void Resetactivitytime()
		{
			this.activitytimeSpecified = false;
		}

		// Token: 0x17001E95 RID: 7829
		// (get) Token: 0x06006131 RID: 24881 RVA: 0x000B96B0 File Offset: 0x000B78B0
		// (set) Token: 0x06006132 RID: 24882 RVA: 0x000B96DC File Offset: 0x000B78DC
		[ProtoMember(4, IsRequired = false, Name = "nItemCount", DataFormat = DataFormat.TwosComplement)]
		public uint nItemCount
		{
			get
			{
				return this._nItemCount ?? 0U;
			}
			set
			{
				this._nItemCount = new uint?(value);
			}
		}

		// Token: 0x17001E96 RID: 7830
		// (get) Token: 0x06006133 RID: 24883 RVA: 0x000B96EC File Offset: 0x000B78EC
		// (set) Token: 0x06006134 RID: 24884 RVA: 0x000B970C File Offset: 0x000B790C
		[XmlIgnore]
		[Browsable(false)]
		public bool nItemCountSpecified
		{
			get
			{
				return this._nItemCount != null;
			}
			set
			{
				bool flag = value == (this._nItemCount == null);
				if (flag)
				{
					this._nItemCount = (value ? new uint?(this.nItemCount) : null);
				}
			}
		}

		// Token: 0x06006135 RID: 24885 RVA: 0x000B9750 File Offset: 0x000B7950
		private bool ShouldSerializenItemCount()
		{
			return this.nItemCountSpecified;
		}

		// Token: 0x06006136 RID: 24886 RVA: 0x000B9768 File Offset: 0x000B7968
		private void ResetnItemCount()
		{
			this.nItemCountSpecified = false;
		}

		// Token: 0x17001E97 RID: 7831
		// (get) Token: 0x06006137 RID: 24887 RVA: 0x000B9774 File Offset: 0x000B7974
		// (set) Token: 0x06006138 RID: 24888 RVA: 0x000B97A0 File Offset: 0x000B79A0
		[ProtoMember(5, IsRequired = false, Name = "nUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint nUpdateTime
		{
			get
			{
				return this._nUpdateTime ?? 0U;
			}
			set
			{
				this._nUpdateTime = new uint?(value);
			}
		}

		// Token: 0x17001E98 RID: 7832
		// (get) Token: 0x06006139 RID: 24889 RVA: 0x000B97B0 File Offset: 0x000B79B0
		// (set) Token: 0x0600613A RID: 24890 RVA: 0x000B97D0 File Offset: 0x000B79D0
		[XmlIgnore]
		[Browsable(false)]
		public bool nUpdateTimeSpecified
		{
			get
			{
				return this._nUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._nUpdateTime == null);
				if (flag)
				{
					this._nUpdateTime = (value ? new uint?(this.nUpdateTime) : null);
				}
			}
		}

		// Token: 0x0600613B RID: 24891 RVA: 0x000B9814 File Offset: 0x000B7A14
		private bool ShouldSerializenUpdateTime()
		{
			return this.nUpdateTimeSpecified;
		}

		// Token: 0x0600613C RID: 24892 RVA: 0x000B982C File Offset: 0x000B7A2C
		private void ResetnUpdateTime()
		{
			this.nUpdateTimeSpecified = false;
		}

		// Token: 0x0600613D RID: 24893 RVA: 0x000B9838 File Offset: 0x000B7A38
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001790 RID: 6032
		private uint? _nGoodsID;

		// Token: 0x04001791 RID: 6033
		private uint? _activity;

		// Token: 0x04001792 RID: 6034
		private uint? _activitytime;

		// Token: 0x04001793 RID: 6035
		private uint? _nItemCount;

		// Token: 0x04001794 RID: 6036
		private uint? _nUpdateTime;

		// Token: 0x04001795 RID: 6037
		private IExtension extensionObject;
	}
}
