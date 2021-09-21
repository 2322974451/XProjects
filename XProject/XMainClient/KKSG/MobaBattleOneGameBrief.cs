using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200071E RID: 1822
	[ProtoContract(Name = "MobaBattleOneGameBrief")]
	[Serializable]
	public class MobaBattleOneGameBrief : IExtensible
	{
		// Token: 0x1700277C RID: 10108
		// (get) Token: 0x06007C8F RID: 31887 RVA: 0x000EE280 File Offset: 0x000EC480
		// (set) Token: 0x06007C90 RID: 31888 RVA: 0x000EE2AC File Offset: 0x000EC4AC
		[ProtoMember(1, IsRequired = false, Name = "tag", DataFormat = DataFormat.TwosComplement)]
		public uint tag
		{
			get
			{
				return this._tag ?? 0U;
			}
			set
			{
				this._tag = new uint?(value);
			}
		}

		// Token: 0x1700277D RID: 10109
		// (get) Token: 0x06007C91 RID: 31889 RVA: 0x000EE2BC File Offset: 0x000EC4BC
		// (set) Token: 0x06007C92 RID: 31890 RVA: 0x000EE2DC File Offset: 0x000EC4DC
		[XmlIgnore]
		[Browsable(false)]
		public bool tagSpecified
		{
			get
			{
				return this._tag != null;
			}
			set
			{
				bool flag = value == (this._tag == null);
				if (flag)
				{
					this._tag = (value ? new uint?(this.tag) : null);
				}
			}
		}

		// Token: 0x06007C93 RID: 31891 RVA: 0x000EE320 File Offset: 0x000EC520
		private bool ShouldSerializetag()
		{
			return this.tagSpecified;
		}

		// Token: 0x06007C94 RID: 31892 RVA: 0x000EE338 File Offset: 0x000EC538
		private void Resettag()
		{
			this.tagSpecified = false;
		}

		// Token: 0x1700277E RID: 10110
		// (get) Token: 0x06007C95 RID: 31893 RVA: 0x000EE344 File Offset: 0x000EC544
		// (set) Token: 0x06007C96 RID: 31894 RVA: 0x000EE370 File Offset: 0x000EC570
		[ProtoMember(2, IsRequired = false, Name = "date", DataFormat = DataFormat.TwosComplement)]
		public uint date
		{
			get
			{
				return this._date ?? 0U;
			}
			set
			{
				this._date = new uint?(value);
			}
		}

		// Token: 0x1700277F RID: 10111
		// (get) Token: 0x06007C97 RID: 31895 RVA: 0x000EE380 File Offset: 0x000EC580
		// (set) Token: 0x06007C98 RID: 31896 RVA: 0x000EE3A0 File Offset: 0x000EC5A0
		[XmlIgnore]
		[Browsable(false)]
		public bool dateSpecified
		{
			get
			{
				return this._date != null;
			}
			set
			{
				bool flag = value == (this._date == null);
				if (flag)
				{
					this._date = (value ? new uint?(this.date) : null);
				}
			}
		}

		// Token: 0x06007C99 RID: 31897 RVA: 0x000EE3E4 File Offset: 0x000EC5E4
		private bool ShouldSerializedate()
		{
			return this.dateSpecified;
		}

		// Token: 0x06007C9A RID: 31898 RVA: 0x000EE3FC File Offset: 0x000EC5FC
		private void Resetdate()
		{
			this.dateSpecified = false;
		}

		// Token: 0x17002780 RID: 10112
		// (get) Token: 0x06007C9B RID: 31899 RVA: 0x000EE408 File Offset: 0x000EC608
		// (set) Token: 0x06007C9C RID: 31900 RVA: 0x000EE434 File Offset: 0x000EC634
		[ProtoMember(3, IsRequired = false, Name = "heroid", DataFormat = DataFormat.TwosComplement)]
		public uint heroid
		{
			get
			{
				return this._heroid ?? 0U;
			}
			set
			{
				this._heroid = new uint?(value);
			}
		}

		// Token: 0x17002781 RID: 10113
		// (get) Token: 0x06007C9D RID: 31901 RVA: 0x000EE444 File Offset: 0x000EC644
		// (set) Token: 0x06007C9E RID: 31902 RVA: 0x000EE464 File Offset: 0x000EC664
		[XmlIgnore]
		[Browsable(false)]
		public bool heroidSpecified
		{
			get
			{
				return this._heroid != null;
			}
			set
			{
				bool flag = value == (this._heroid == null);
				if (flag)
				{
					this._heroid = (value ? new uint?(this.heroid) : null);
				}
			}
		}

		// Token: 0x06007C9F RID: 31903 RVA: 0x000EE4A8 File Offset: 0x000EC6A8
		private bool ShouldSerializeheroid()
		{
			return this.heroidSpecified;
		}

		// Token: 0x06007CA0 RID: 31904 RVA: 0x000EE4C0 File Offset: 0x000EC6C0
		private void Resetheroid()
		{
			this.heroidSpecified = false;
		}

		// Token: 0x17002782 RID: 10114
		// (get) Token: 0x06007CA1 RID: 31905 RVA: 0x000EE4CC File Offset: 0x000EC6CC
		// (set) Token: 0x06007CA2 RID: 31906 RVA: 0x000EE4F8 File Offset: 0x000EC6F8
		[ProtoMember(4, IsRequired = false, Name = "iswin", DataFormat = DataFormat.Default)]
		public bool iswin
		{
			get
			{
				return this._iswin ?? false;
			}
			set
			{
				this._iswin = new bool?(value);
			}
		}

		// Token: 0x17002783 RID: 10115
		// (get) Token: 0x06007CA3 RID: 31907 RVA: 0x000EE508 File Offset: 0x000EC708
		// (set) Token: 0x06007CA4 RID: 31908 RVA: 0x000EE528 File Offset: 0x000EC728
		[XmlIgnore]
		[Browsable(false)]
		public bool iswinSpecified
		{
			get
			{
				return this._iswin != null;
			}
			set
			{
				bool flag = value == (this._iswin == null);
				if (flag)
				{
					this._iswin = (value ? new bool?(this.iswin) : null);
				}
			}
		}

		// Token: 0x06007CA5 RID: 31909 RVA: 0x000EE56C File Offset: 0x000EC76C
		private bool ShouldSerializeiswin()
		{
			return this.iswinSpecified;
		}

		// Token: 0x06007CA6 RID: 31910 RVA: 0x000EE584 File Offset: 0x000EC784
		private void Resetiswin()
		{
			this.iswinSpecified = false;
		}

		// Token: 0x17002784 RID: 10116
		// (get) Token: 0x06007CA7 RID: 31911 RVA: 0x000EE590 File Offset: 0x000EC790
		// (set) Token: 0x06007CA8 RID: 31912 RVA: 0x000EE5BC File Offset: 0x000EC7BC
		[ProtoMember(5, IsRequired = false, Name = "isescape", DataFormat = DataFormat.Default)]
		public bool isescape
		{
			get
			{
				return this._isescape ?? false;
			}
			set
			{
				this._isescape = new bool?(value);
			}
		}

		// Token: 0x17002785 RID: 10117
		// (get) Token: 0x06007CA9 RID: 31913 RVA: 0x000EE5CC File Offset: 0x000EC7CC
		// (set) Token: 0x06007CAA RID: 31914 RVA: 0x000EE5EC File Offset: 0x000EC7EC
		[XmlIgnore]
		[Browsable(false)]
		public bool isescapeSpecified
		{
			get
			{
				return this._isescape != null;
			}
			set
			{
				bool flag = value == (this._isescape == null);
				if (flag)
				{
					this._isescape = (value ? new bool?(this.isescape) : null);
				}
			}
		}

		// Token: 0x06007CAB RID: 31915 RVA: 0x000EE630 File Offset: 0x000EC830
		private bool ShouldSerializeisescape()
		{
			return this.isescapeSpecified;
		}

		// Token: 0x06007CAC RID: 31916 RVA: 0x000EE648 File Offset: 0x000EC848
		private void Resetisescape()
		{
			this.isescapeSpecified = false;
		}

		// Token: 0x17002786 RID: 10118
		// (get) Token: 0x06007CAD RID: 31917 RVA: 0x000EE654 File Offset: 0x000EC854
		// (set) Token: 0x06007CAE RID: 31918 RVA: 0x000EE680 File Offset: 0x000EC880
		[ProtoMember(6, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		// Token: 0x17002787 RID: 10119
		// (get) Token: 0x06007CAF RID: 31919 RVA: 0x000EE690 File Offset: 0x000EC890
		// (set) Token: 0x06007CB0 RID: 31920 RVA: 0x000EE6B0 File Offset: 0x000EC8B0
		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		// Token: 0x06007CB1 RID: 31921 RVA: 0x000EE6F4 File Offset: 0x000EC8F4
		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		// Token: 0x06007CB2 RID: 31922 RVA: 0x000EE70C File Offset: 0x000EC90C
		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		// Token: 0x17002788 RID: 10120
		// (get) Token: 0x06007CB3 RID: 31923 RVA: 0x000EE718 File Offset: 0x000EC918
		// (set) Token: 0x06007CB4 RID: 31924 RVA: 0x000EE744 File Offset: 0x000EC944
		[ProtoMember(7, IsRequired = false, Name = "islosemvp", DataFormat = DataFormat.Default)]
		public bool islosemvp
		{
			get
			{
				return this._islosemvp ?? false;
			}
			set
			{
				this._islosemvp = new bool?(value);
			}
		}

		// Token: 0x17002789 RID: 10121
		// (get) Token: 0x06007CB5 RID: 31925 RVA: 0x000EE754 File Offset: 0x000EC954
		// (set) Token: 0x06007CB6 RID: 31926 RVA: 0x000EE774 File Offset: 0x000EC974
		[XmlIgnore]
		[Browsable(false)]
		public bool islosemvpSpecified
		{
			get
			{
				return this._islosemvp != null;
			}
			set
			{
				bool flag = value == (this._islosemvp == null);
				if (flag)
				{
					this._islosemvp = (value ? new bool?(this.islosemvp) : null);
				}
			}
		}

		// Token: 0x06007CB7 RID: 31927 RVA: 0x000EE7B8 File Offset: 0x000EC9B8
		private bool ShouldSerializeislosemvp()
		{
			return this.islosemvpSpecified;
		}

		// Token: 0x06007CB8 RID: 31928 RVA: 0x000EE7D0 File Offset: 0x000EC9D0
		private void Resetislosemvp()
		{
			this.islosemvpSpecified = false;
		}

		// Token: 0x06007CB9 RID: 31929 RVA: 0x000EE7DC File Offset: 0x000EC9DC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001D58 RID: 7512
		private uint? _tag;

		// Token: 0x04001D59 RID: 7513
		private uint? _date;

		// Token: 0x04001D5A RID: 7514
		private uint? _heroid;

		// Token: 0x04001D5B RID: 7515
		private bool? _iswin;

		// Token: 0x04001D5C RID: 7516
		private bool? _isescape;

		// Token: 0x04001D5D RID: 7517
		private bool? _ismvp;

		// Token: 0x04001D5E RID: 7518
		private bool? _islosemvp;

		// Token: 0x04001D5F RID: 7519
		private IExtension extensionObject;
	}
}
