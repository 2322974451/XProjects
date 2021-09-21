using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004BD RID: 1213
	[ProtoContract(Name = "FetchDragonGuildListArg")]
	[Serializable]
	public class FetchDragonGuildListArg : IExtensible
	{
		// Token: 0x17001353 RID: 4947
		// (get) Token: 0x06003F18 RID: 16152 RVA: 0x000784B0 File Offset: 0x000766B0
		// (set) Token: 0x06003F19 RID: 16153 RVA: 0x000784DC File Offset: 0x000766DC
		[ProtoMember(1, IsRequired = false, Name = "start", DataFormat = DataFormat.TwosComplement)]
		public int start
		{
			get
			{
				return this._start ?? 0;
			}
			set
			{
				this._start = new int?(value);
			}
		}

		// Token: 0x17001354 RID: 4948
		// (get) Token: 0x06003F1A RID: 16154 RVA: 0x000784EC File Offset: 0x000766EC
		// (set) Token: 0x06003F1B RID: 16155 RVA: 0x0007850C File Offset: 0x0007670C
		[XmlIgnore]
		[Browsable(false)]
		public bool startSpecified
		{
			get
			{
				return this._start != null;
			}
			set
			{
				bool flag = value == (this._start == null);
				if (flag)
				{
					this._start = (value ? new int?(this.start) : null);
				}
			}
		}

		// Token: 0x06003F1C RID: 16156 RVA: 0x00078550 File Offset: 0x00076750
		private bool ShouldSerializestart()
		{
			return this.startSpecified;
		}

		// Token: 0x06003F1D RID: 16157 RVA: 0x00078568 File Offset: 0x00076768
		private void Resetstart()
		{
			this.startSpecified = false;
		}

		// Token: 0x17001355 RID: 4949
		// (get) Token: 0x06003F1E RID: 16158 RVA: 0x00078574 File Offset: 0x00076774
		// (set) Token: 0x06003F1F RID: 16159 RVA: 0x000785A0 File Offset: 0x000767A0
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public int count
		{
			get
			{
				return this._count ?? 0;
			}
			set
			{
				this._count = new int?(value);
			}
		}

		// Token: 0x17001356 RID: 4950
		// (get) Token: 0x06003F20 RID: 16160 RVA: 0x000785B0 File Offset: 0x000767B0
		// (set) Token: 0x06003F21 RID: 16161 RVA: 0x000785D0 File Offset: 0x000767D0
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new int?(this.count) : null);
				}
			}
		}

		// Token: 0x06003F22 RID: 16162 RVA: 0x00078614 File Offset: 0x00076814
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06003F23 RID: 16163 RVA: 0x0007862C File Offset: 0x0007682C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17001357 RID: 4951
		// (get) Token: 0x06003F24 RID: 16164 RVA: 0x00078638 File Offset: 0x00076838
		// (set) Token: 0x06003F25 RID: 16165 RVA: 0x00078664 File Offset: 0x00076864
		[ProtoMember(3, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public int reason
		{
			get
			{
				return this._reason ?? 0;
			}
			set
			{
				this._reason = new int?(value);
			}
		}

		// Token: 0x17001358 RID: 4952
		// (get) Token: 0x06003F26 RID: 16166 RVA: 0x00078674 File Offset: 0x00076874
		// (set) Token: 0x06003F27 RID: 16167 RVA: 0x00078694 File Offset: 0x00076894
		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new int?(this.reason) : null);
				}
			}
		}

		// Token: 0x06003F28 RID: 16168 RVA: 0x000786D8 File Offset: 0x000768D8
		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		// Token: 0x06003F29 RID: 16169 RVA: 0x000786F0 File Offset: 0x000768F0
		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		// Token: 0x17001359 RID: 4953
		// (get) Token: 0x06003F2A RID: 16170 RVA: 0x000786FC File Offset: 0x000768FC
		// (set) Token: 0x06003F2B RID: 16171 RVA: 0x00078728 File Offset: 0x00076928
		[ProtoMember(4, IsRequired = false, Name = "sortType", DataFormat = DataFormat.TwosComplement)]
		public int sortType
		{
			get
			{
				return this._sortType ?? 0;
			}
			set
			{
				this._sortType = new int?(value);
			}
		}

		// Token: 0x1700135A RID: 4954
		// (get) Token: 0x06003F2C RID: 16172 RVA: 0x00078738 File Offset: 0x00076938
		// (set) Token: 0x06003F2D RID: 16173 RVA: 0x00078758 File Offset: 0x00076958
		[XmlIgnore]
		[Browsable(false)]
		public bool sortTypeSpecified
		{
			get
			{
				return this._sortType != null;
			}
			set
			{
				bool flag = value == (this._sortType == null);
				if (flag)
				{
					this._sortType = (value ? new int?(this.sortType) : null);
				}
			}
		}

		// Token: 0x06003F2E RID: 16174 RVA: 0x0007879C File Offset: 0x0007699C
		private bool ShouldSerializesortType()
		{
			return this.sortTypeSpecified;
		}

		// Token: 0x06003F2F RID: 16175 RVA: 0x000787B4 File Offset: 0x000769B4
		private void ResetsortType()
		{
			this.sortTypeSpecified = false;
		}

		// Token: 0x1700135B RID: 4955
		// (get) Token: 0x06003F30 RID: 16176 RVA: 0x000787C0 File Offset: 0x000769C0
		// (set) Token: 0x06003F31 RID: 16177 RVA: 0x000787EC File Offset: 0x000769EC
		[ProtoMember(5, IsRequired = false, Name = "reverse", DataFormat = DataFormat.Default)]
		public bool reverse
		{
			get
			{
				return this._reverse ?? false;
			}
			set
			{
				this._reverse = new bool?(value);
			}
		}

		// Token: 0x1700135C RID: 4956
		// (get) Token: 0x06003F32 RID: 16178 RVA: 0x000787FC File Offset: 0x000769FC
		// (set) Token: 0x06003F33 RID: 16179 RVA: 0x0007881C File Offset: 0x00076A1C
		[XmlIgnore]
		[Browsable(false)]
		public bool reverseSpecified
		{
			get
			{
				return this._reverse != null;
			}
			set
			{
				bool flag = value == (this._reverse == null);
				if (flag)
				{
					this._reverse = (value ? new bool?(this.reverse) : null);
				}
			}
		}

		// Token: 0x06003F34 RID: 16180 RVA: 0x00078860 File Offset: 0x00076A60
		private bool ShouldSerializereverse()
		{
			return this.reverseSpecified;
		}

		// Token: 0x06003F35 RID: 16181 RVA: 0x00078878 File Offset: 0x00076A78
		private void Resetreverse()
		{
			this.reverseSpecified = false;
		}

		// Token: 0x1700135D RID: 4957
		// (get) Token: 0x06003F36 RID: 16182 RVA: 0x00078884 File Offset: 0x00076A84
		// (set) Token: 0x06003F37 RID: 16183 RVA: 0x000788A5 File Offset: 0x00076AA5
		[ProtoMember(6, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x1700135E RID: 4958
		// (get) Token: 0x06003F38 RID: 16184 RVA: 0x000788B0 File Offset: 0x00076AB0
		// (set) Token: 0x06003F39 RID: 16185 RVA: 0x000788CC File Offset: 0x00076ACC
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06003F3A RID: 16186 RVA: 0x000788FC File Offset: 0x00076AFC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003F3B RID: 16187 RVA: 0x00078914 File Offset: 0x00076B14
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06003F3C RID: 16188 RVA: 0x00078920 File Offset: 0x00076B20
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FB4 RID: 4020
		private int? _start;

		// Token: 0x04000FB5 RID: 4021
		private int? _count;

		// Token: 0x04000FB6 RID: 4022
		private int? _reason;

		// Token: 0x04000FB7 RID: 4023
		private int? _sortType;

		// Token: 0x04000FB8 RID: 4024
		private bool? _reverse;

		// Token: 0x04000FB9 RID: 4025
		private string _name;

		// Token: 0x04000FBA RID: 4026
		private IExtension extensionObject;
	}
}
