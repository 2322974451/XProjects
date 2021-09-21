using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200068E RID: 1678
	[ProtoContract(Name = "BossRushData")]
	[Serializable]
	public class BossRushData : IExtensible
	{
		// Token: 0x1700225C RID: 8796
		// (get) Token: 0x06006C8F RID: 27791 RVA: 0x000CFB34 File Offset: 0x000CDD34
		// (set) Token: 0x06006C90 RID: 27792 RVA: 0x000CFB60 File Offset: 0x000CDD60
		[ProtoMember(1, IsRequired = false, Name = "confid", DataFormat = DataFormat.TwosComplement)]
		public int confid
		{
			get
			{
				return this._confid ?? 0;
			}
			set
			{
				this._confid = new int?(value);
			}
		}

		// Token: 0x1700225D RID: 8797
		// (get) Token: 0x06006C91 RID: 27793 RVA: 0x000CFB70 File Offset: 0x000CDD70
		// (set) Token: 0x06006C92 RID: 27794 RVA: 0x000CFB90 File Offset: 0x000CDD90
		[XmlIgnore]
		[Browsable(false)]
		public bool confidSpecified
		{
			get
			{
				return this._confid != null;
			}
			set
			{
				bool flag = value == (this._confid == null);
				if (flag)
				{
					this._confid = (value ? new int?(this.confid) : null);
				}
			}
		}

		// Token: 0x06006C93 RID: 27795 RVA: 0x000CFBD4 File Offset: 0x000CDDD4
		private bool ShouldSerializeconfid()
		{
			return this.confidSpecified;
		}

		// Token: 0x06006C94 RID: 27796 RVA: 0x000CFBEC File Offset: 0x000CDDEC
		private void Resetconfid()
		{
			this.confidSpecified = false;
		}

		// Token: 0x1700225E RID: 8798
		// (get) Token: 0x06006C95 RID: 27797 RVA: 0x000CFBF8 File Offset: 0x000CDDF8
		// (set) Token: 0x06006C96 RID: 27798 RVA: 0x000CFC24 File Offset: 0x000CDE24
		[ProtoMember(2, IsRequired = false, Name = "buffid1", DataFormat = DataFormat.TwosComplement)]
		public int buffid1
		{
			get
			{
				return this._buffid1 ?? 0;
			}
			set
			{
				this._buffid1 = new int?(value);
			}
		}

		// Token: 0x1700225F RID: 8799
		// (get) Token: 0x06006C97 RID: 27799 RVA: 0x000CFC34 File Offset: 0x000CDE34
		// (set) Token: 0x06006C98 RID: 27800 RVA: 0x000CFC54 File Offset: 0x000CDE54
		[XmlIgnore]
		[Browsable(false)]
		public bool buffid1Specified
		{
			get
			{
				return this._buffid1 != null;
			}
			set
			{
				bool flag = value == (this._buffid1 == null);
				if (flag)
				{
					this._buffid1 = (value ? new int?(this.buffid1) : null);
				}
			}
		}

		// Token: 0x06006C99 RID: 27801 RVA: 0x000CFC98 File Offset: 0x000CDE98
		private bool ShouldSerializebuffid1()
		{
			return this.buffid1Specified;
		}

		// Token: 0x06006C9A RID: 27802 RVA: 0x000CFCB0 File Offset: 0x000CDEB0
		private void Resetbuffid1()
		{
			this.buffid1Specified = false;
		}

		// Token: 0x17002260 RID: 8800
		// (get) Token: 0x06006C9B RID: 27803 RVA: 0x000CFCBC File Offset: 0x000CDEBC
		// (set) Token: 0x06006C9C RID: 27804 RVA: 0x000CFCE8 File Offset: 0x000CDEE8
		[ProtoMember(3, IsRequired = false, Name = "buffid2", DataFormat = DataFormat.TwosComplement)]
		public int buffid2
		{
			get
			{
				return this._buffid2 ?? 0;
			}
			set
			{
				this._buffid2 = new int?(value);
			}
		}

		// Token: 0x17002261 RID: 8801
		// (get) Token: 0x06006C9D RID: 27805 RVA: 0x000CFCF8 File Offset: 0x000CDEF8
		// (set) Token: 0x06006C9E RID: 27806 RVA: 0x000CFD18 File Offset: 0x000CDF18
		[XmlIgnore]
		[Browsable(false)]
		public bool buffid2Specified
		{
			get
			{
				return this._buffid2 != null;
			}
			set
			{
				bool flag = value == (this._buffid2 == null);
				if (flag)
				{
					this._buffid2 = (value ? new int?(this.buffid2) : null);
				}
			}
		}

		// Token: 0x06006C9F RID: 27807 RVA: 0x000CFD5C File Offset: 0x000CDF5C
		private bool ShouldSerializebuffid2()
		{
			return this.buffid2Specified;
		}

		// Token: 0x06006CA0 RID: 27808 RVA: 0x000CFD74 File Offset: 0x000CDF74
		private void Resetbuffid2()
		{
			this.buffid2Specified = false;
		}

		// Token: 0x17002262 RID: 8802
		// (get) Token: 0x06006CA1 RID: 27809 RVA: 0x000CFD80 File Offset: 0x000CDF80
		// (set) Token: 0x06006CA2 RID: 27810 RVA: 0x000CFDAC File Offset: 0x000CDFAC
		[ProtoMember(4, IsRequired = false, Name = "currank", DataFormat = DataFormat.TwosComplement)]
		public int currank
		{
			get
			{
				return this._currank ?? 0;
			}
			set
			{
				this._currank = new int?(value);
			}
		}

		// Token: 0x17002263 RID: 8803
		// (get) Token: 0x06006CA3 RID: 27811 RVA: 0x000CFDBC File Offset: 0x000CDFBC
		// (set) Token: 0x06006CA4 RID: 27812 RVA: 0x000CFDDC File Offset: 0x000CDFDC
		[XmlIgnore]
		[Browsable(false)]
		public bool currankSpecified
		{
			get
			{
				return this._currank != null;
			}
			set
			{
				bool flag = value == (this._currank == null);
				if (flag)
				{
					this._currank = (value ? new int?(this.currank) : null);
				}
			}
		}

		// Token: 0x06006CA5 RID: 27813 RVA: 0x000CFE20 File Offset: 0x000CE020
		private bool ShouldSerializecurrank()
		{
			return this.currankSpecified;
		}

		// Token: 0x06006CA6 RID: 27814 RVA: 0x000CFE38 File Offset: 0x000CE038
		private void Resetcurrank()
		{
			this.currankSpecified = false;
		}

		// Token: 0x17002264 RID: 8804
		// (get) Token: 0x06006CA7 RID: 27815 RVA: 0x000CFE44 File Offset: 0x000CE044
		// (set) Token: 0x06006CA8 RID: 27816 RVA: 0x000CFE70 File Offset: 0x000CE070
		[ProtoMember(5, IsRequired = false, Name = "maxrank", DataFormat = DataFormat.TwosComplement)]
		public int maxrank
		{
			get
			{
				return this._maxrank ?? 0;
			}
			set
			{
				this._maxrank = new int?(value);
			}
		}

		// Token: 0x17002265 RID: 8805
		// (get) Token: 0x06006CA9 RID: 27817 RVA: 0x000CFE80 File Offset: 0x000CE080
		// (set) Token: 0x06006CAA RID: 27818 RVA: 0x000CFEA0 File Offset: 0x000CE0A0
		[XmlIgnore]
		[Browsable(false)]
		public bool maxrankSpecified
		{
			get
			{
				return this._maxrank != null;
			}
			set
			{
				bool flag = value == (this._maxrank == null);
				if (flag)
				{
					this._maxrank = (value ? new int?(this.maxrank) : null);
				}
			}
		}

		// Token: 0x06006CAB RID: 27819 RVA: 0x000CFEE4 File Offset: 0x000CE0E4
		private bool ShouldSerializemaxrank()
		{
			return this.maxrankSpecified;
		}

		// Token: 0x06006CAC RID: 27820 RVA: 0x000CFEFC File Offset: 0x000CE0FC
		private void Resetmaxrank()
		{
			this.maxrankSpecified = false;
		}

		// Token: 0x17002266 RID: 8806
		// (get) Token: 0x06006CAD RID: 27821 RVA: 0x000CFF08 File Offset: 0x000CE108
		// (set) Token: 0x06006CAE RID: 27822 RVA: 0x000CFF34 File Offset: 0x000CE134
		[ProtoMember(6, IsRequired = false, Name = "currefreshcount", DataFormat = DataFormat.TwosComplement)]
		public int currefreshcount
		{
			get
			{
				return this._currefreshcount ?? 0;
			}
			set
			{
				this._currefreshcount = new int?(value);
			}
		}

		// Token: 0x17002267 RID: 8807
		// (get) Token: 0x06006CAF RID: 27823 RVA: 0x000CFF44 File Offset: 0x000CE144
		// (set) Token: 0x06006CB0 RID: 27824 RVA: 0x000CFF64 File Offset: 0x000CE164
		[XmlIgnore]
		[Browsable(false)]
		public bool currefreshcountSpecified
		{
			get
			{
				return this._currefreshcount != null;
			}
			set
			{
				bool flag = value == (this._currefreshcount == null);
				if (flag)
				{
					this._currefreshcount = (value ? new int?(this.currefreshcount) : null);
				}
			}
		}

		// Token: 0x06006CB1 RID: 27825 RVA: 0x000CFFA8 File Offset: 0x000CE1A8
		private bool ShouldSerializecurrefreshcount()
		{
			return this.currefreshcountSpecified;
		}

		// Token: 0x06006CB2 RID: 27826 RVA: 0x000CFFC0 File Offset: 0x000CE1C0
		private void Resetcurrefreshcount()
		{
			this.currefreshcountSpecified = false;
		}

		// Token: 0x17002268 RID: 8808
		// (get) Token: 0x06006CB3 RID: 27827 RVA: 0x000CFFCC File Offset: 0x000CE1CC
		// (set) Token: 0x06006CB4 RID: 27828 RVA: 0x000CFFF8 File Offset: 0x000CE1F8
		[ProtoMember(7, IsRequired = false, Name = "maxrefreshcount", DataFormat = DataFormat.TwosComplement)]
		public int maxrefreshcount
		{
			get
			{
				return this._maxrefreshcount ?? 0;
			}
			set
			{
				this._maxrefreshcount = new int?(value);
			}
		}

		// Token: 0x17002269 RID: 8809
		// (get) Token: 0x06006CB5 RID: 27829 RVA: 0x000D0008 File Offset: 0x000CE208
		// (set) Token: 0x06006CB6 RID: 27830 RVA: 0x000D0028 File Offset: 0x000CE228
		[XmlIgnore]
		[Browsable(false)]
		public bool maxrefreshcountSpecified
		{
			get
			{
				return this._maxrefreshcount != null;
			}
			set
			{
				bool flag = value == (this._maxrefreshcount == null);
				if (flag)
				{
					this._maxrefreshcount = (value ? new int?(this.maxrefreshcount) : null);
				}
			}
		}

		// Token: 0x06006CB7 RID: 27831 RVA: 0x000D006C File Offset: 0x000CE26C
		private bool ShouldSerializemaxrefreshcount()
		{
			return this.maxrefreshcountSpecified;
		}

		// Token: 0x06006CB8 RID: 27832 RVA: 0x000D0084 File Offset: 0x000CE284
		private void Resetmaxrefreshcount()
		{
			this.maxrefreshcountSpecified = false;
		}

		// Token: 0x1700226A RID: 8810
		// (get) Token: 0x06006CB9 RID: 27833 RVA: 0x000D0090 File Offset: 0x000CE290
		// (set) Token: 0x06006CBA RID: 27834 RVA: 0x000D00BC File Offset: 0x000CE2BC
		[ProtoMember(8, IsRequired = false, Name = "joincounttoday", DataFormat = DataFormat.TwosComplement)]
		public int joincounttoday
		{
			get
			{
				return this._joincounttoday ?? 0;
			}
			set
			{
				this._joincounttoday = new int?(value);
			}
		}

		// Token: 0x1700226B RID: 8811
		// (get) Token: 0x06006CBB RID: 27835 RVA: 0x000D00CC File Offset: 0x000CE2CC
		// (set) Token: 0x06006CBC RID: 27836 RVA: 0x000D00EC File Offset: 0x000CE2EC
		[XmlIgnore]
		[Browsable(false)]
		public bool joincounttodaySpecified
		{
			get
			{
				return this._joincounttoday != null;
			}
			set
			{
				bool flag = value == (this._joincounttoday == null);
				if (flag)
				{
					this._joincounttoday = (value ? new int?(this.joincounttoday) : null);
				}
			}
		}

		// Token: 0x06006CBD RID: 27837 RVA: 0x000D0130 File Offset: 0x000CE330
		private bool ShouldSerializejoincounttoday()
		{
			return this.joincounttodaySpecified;
		}

		// Token: 0x06006CBE RID: 27838 RVA: 0x000D0148 File Offset: 0x000CE348
		private void Resetjoincounttoday()
		{
			this.joincounttodaySpecified = false;
		}

		// Token: 0x1700226C RID: 8812
		// (get) Token: 0x06006CBF RID: 27839 RVA: 0x000D0154 File Offset: 0x000CE354
		// (set) Token: 0x06006CC0 RID: 27840 RVA: 0x000D0180 File Offset: 0x000CE380
		[ProtoMember(9, IsRequired = false, Name = "joincountmax", DataFormat = DataFormat.TwosComplement)]
		public int joincountmax
		{
			get
			{
				return this._joincountmax ?? 0;
			}
			set
			{
				this._joincountmax = new int?(value);
			}
		}

		// Token: 0x1700226D RID: 8813
		// (get) Token: 0x06006CC1 RID: 27841 RVA: 0x000D0190 File Offset: 0x000CE390
		// (set) Token: 0x06006CC2 RID: 27842 RVA: 0x000D01B0 File Offset: 0x000CE3B0
		[XmlIgnore]
		[Browsable(false)]
		public bool joincountmaxSpecified
		{
			get
			{
				return this._joincountmax != null;
			}
			set
			{
				bool flag = value == (this._joincountmax == null);
				if (flag)
				{
					this._joincountmax = (value ? new int?(this.joincountmax) : null);
				}
			}
		}

		// Token: 0x06006CC3 RID: 27843 RVA: 0x000D01F4 File Offset: 0x000CE3F4
		private bool ShouldSerializejoincountmax()
		{
			return this.joincountmaxSpecified;
		}

		// Token: 0x06006CC4 RID: 27844 RVA: 0x000D020C File Offset: 0x000CE40C
		private void Resetjoincountmax()
		{
			this.joincountmaxSpecified = false;
		}

		// Token: 0x06006CC5 RID: 27845 RVA: 0x000D0218 File Offset: 0x000CE418
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A0D RID: 6669
		private int? _confid;

		// Token: 0x04001A0E RID: 6670
		private int? _buffid1;

		// Token: 0x04001A0F RID: 6671
		private int? _buffid2;

		// Token: 0x04001A10 RID: 6672
		private int? _currank;

		// Token: 0x04001A11 RID: 6673
		private int? _maxrank;

		// Token: 0x04001A12 RID: 6674
		private int? _currefreshcount;

		// Token: 0x04001A13 RID: 6675
		private int? _maxrefreshcount;

		// Token: 0x04001A14 RID: 6676
		private int? _joincounttoday;

		// Token: 0x04001A15 RID: 6677
		private int? _joincountmax;

		// Token: 0x04001A16 RID: 6678
		private IExtension extensionObject;
	}
}
