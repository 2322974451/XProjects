using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000591 RID: 1425
	[ProtoContract(Name = "PayConsume")]
	[Serializable]
	public class PayConsume : IExtensible
	{
		// Token: 0x17001745 RID: 5957
		// (get) Token: 0x06004BA5 RID: 19365 RVA: 0x0008FDBC File Offset: 0x0008DFBC
		// (set) Token: 0x06004BA6 RID: 19366 RVA: 0x0008FDE8 File Offset: 0x0008DFE8
		[ProtoMember(1, IsRequired = false, Name = "lastconsumetime", DataFormat = DataFormat.TwosComplement)]
		public uint lastconsumetime
		{
			get
			{
				return this._lastconsumetime ?? 0U;
			}
			set
			{
				this._lastconsumetime = new uint?(value);
			}
		}

		// Token: 0x17001746 RID: 5958
		// (get) Token: 0x06004BA7 RID: 19367 RVA: 0x0008FDF8 File Offset: 0x0008DFF8
		// (set) Token: 0x06004BA8 RID: 19368 RVA: 0x0008FE18 File Offset: 0x0008E018
		[XmlIgnore]
		[Browsable(false)]
		public bool lastconsumetimeSpecified
		{
			get
			{
				return this._lastconsumetime != null;
			}
			set
			{
				bool flag = value == (this._lastconsumetime == null);
				if (flag)
				{
					this._lastconsumetime = (value ? new uint?(this.lastconsumetime) : null);
				}
			}
		}

		// Token: 0x06004BA9 RID: 19369 RVA: 0x0008FE5C File Offset: 0x0008E05C
		private bool ShouldSerializelastconsumetime()
		{
			return this.lastconsumetimeSpecified;
		}

		// Token: 0x06004BAA RID: 19370 RVA: 0x0008FE74 File Offset: 0x0008E074
		private void Resetlastconsumetime()
		{
			this.lastconsumetimeSpecified = false;
		}

		// Token: 0x17001747 RID: 5959
		// (get) Token: 0x06004BAB RID: 19371 RVA: 0x0008FE80 File Offset: 0x0008E080
		// (set) Token: 0x06004BAC RID: 19372 RVA: 0x0008FEAC File Offset: 0x0008E0AC
		[ProtoMember(2, IsRequired = false, Name = "consumescore", DataFormat = DataFormat.TwosComplement)]
		public uint consumescore
		{
			get
			{
				return this._consumescore ?? 0U;
			}
			set
			{
				this._consumescore = new uint?(value);
			}
		}

		// Token: 0x17001748 RID: 5960
		// (get) Token: 0x06004BAD RID: 19373 RVA: 0x0008FEBC File Offset: 0x0008E0BC
		// (set) Token: 0x06004BAE RID: 19374 RVA: 0x0008FEDC File Offset: 0x0008E0DC
		[XmlIgnore]
		[Browsable(false)]
		public bool consumescoreSpecified
		{
			get
			{
				return this._consumescore != null;
			}
			set
			{
				bool flag = value == (this._consumescore == null);
				if (flag)
				{
					this._consumescore = (value ? new uint?(this.consumescore) : null);
				}
			}
		}

		// Token: 0x06004BAF RID: 19375 RVA: 0x0008FF20 File Offset: 0x0008E120
		private bool ShouldSerializeconsumescore()
		{
			return this.consumescoreSpecified;
		}

		// Token: 0x06004BB0 RID: 19376 RVA: 0x0008FF38 File Offset: 0x0008E138
		private void Resetconsumescore()
		{
			this.consumescoreSpecified = false;
		}

		// Token: 0x17001749 RID: 5961
		// (get) Token: 0x06004BB1 RID: 19377 RVA: 0x0008FF44 File Offset: 0x0008E144
		// (set) Token: 0x06004BB2 RID: 19378 RVA: 0x0008FF70 File Offset: 0x0008E170
		[ProtoMember(3, IsRequired = false, Name = "maxconsumelv", DataFormat = DataFormat.TwosComplement)]
		public uint maxconsumelv
		{
			get
			{
				return this._maxconsumelv ?? 0U;
			}
			set
			{
				this._maxconsumelv = new uint?(value);
			}
		}

		// Token: 0x1700174A RID: 5962
		// (get) Token: 0x06004BB3 RID: 19379 RVA: 0x0008FF80 File Offset: 0x0008E180
		// (set) Token: 0x06004BB4 RID: 19380 RVA: 0x0008FFA0 File Offset: 0x0008E1A0
		[XmlIgnore]
		[Browsable(false)]
		public bool maxconsumelvSpecified
		{
			get
			{
				return this._maxconsumelv != null;
			}
			set
			{
				bool flag = value == (this._maxconsumelv == null);
				if (flag)
				{
					this._maxconsumelv = (value ? new uint?(this.maxconsumelv) : null);
				}
			}
		}

		// Token: 0x06004BB5 RID: 19381 RVA: 0x0008FFE4 File Offset: 0x0008E1E4
		private bool ShouldSerializemaxconsumelv()
		{
			return this.maxconsumelvSpecified;
		}

		// Token: 0x06004BB6 RID: 19382 RVA: 0x0008FFFC File Offset: 0x0008E1FC
		private void Resetmaxconsumelv()
		{
			this.maxconsumelvSpecified = false;
		}

		// Token: 0x1700174B RID: 5963
		// (get) Token: 0x06004BB7 RID: 19383 RVA: 0x00090008 File Offset: 0x0008E208
		// (set) Token: 0x06004BB8 RID: 19384 RVA: 0x00090034 File Offset: 0x0008E234
		[ProtoMember(4, IsRequired = false, Name = "thismonthcost", DataFormat = DataFormat.TwosComplement)]
		public uint thismonthcost
		{
			get
			{
				return this._thismonthcost ?? 0U;
			}
			set
			{
				this._thismonthcost = new uint?(value);
			}
		}

		// Token: 0x1700174C RID: 5964
		// (get) Token: 0x06004BB9 RID: 19385 RVA: 0x00090044 File Offset: 0x0008E244
		// (set) Token: 0x06004BBA RID: 19386 RVA: 0x00090064 File Offset: 0x0008E264
		[XmlIgnore]
		[Browsable(false)]
		public bool thismonthcostSpecified
		{
			get
			{
				return this._thismonthcost != null;
			}
			set
			{
				bool flag = value == (this._thismonthcost == null);
				if (flag)
				{
					this._thismonthcost = (value ? new uint?(this.thismonthcost) : null);
				}
			}
		}

		// Token: 0x06004BBB RID: 19387 RVA: 0x000900A8 File Offset: 0x0008E2A8
		private bool ShouldSerializethismonthcost()
		{
			return this.thismonthcostSpecified;
		}

		// Token: 0x06004BBC RID: 19388 RVA: 0x000900C0 File Offset: 0x0008E2C0
		private void Resetthismonthcost()
		{
			this.thismonthcostSpecified = false;
		}

		// Token: 0x1700174D RID: 5965
		// (get) Token: 0x06004BBD RID: 19389 RVA: 0x000900CC File Offset: 0x0008E2CC
		[ProtoMember(5, Name = "setid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> setid
		{
			get
			{
				return this._setid;
			}
		}

		// Token: 0x1700174E RID: 5966
		// (get) Token: 0x06004BBE RID: 19390 RVA: 0x000900E4 File Offset: 0x0008E2E4
		// (set) Token: 0x06004BBF RID: 19391 RVA: 0x00090110 File Offset: 0x0008E310
		[ProtoMember(6, IsRequired = false, Name = "lastcheckdowntime", DataFormat = DataFormat.TwosComplement)]
		public uint lastcheckdowntime
		{
			get
			{
				return this._lastcheckdowntime ?? 0U;
			}
			set
			{
				this._lastcheckdowntime = new uint?(value);
			}
		}

		// Token: 0x1700174F RID: 5967
		// (get) Token: 0x06004BC0 RID: 19392 RVA: 0x00090120 File Offset: 0x0008E320
		// (set) Token: 0x06004BC1 RID: 19393 RVA: 0x00090140 File Offset: 0x0008E340
		[XmlIgnore]
		[Browsable(false)]
		public bool lastcheckdowntimeSpecified
		{
			get
			{
				return this._lastcheckdowntime != null;
			}
			set
			{
				bool flag = value == (this._lastcheckdowntime == null);
				if (flag)
				{
					this._lastcheckdowntime = (value ? new uint?(this.lastcheckdowntime) : null);
				}
			}
		}

		// Token: 0x06004BC2 RID: 19394 RVA: 0x00090184 File Offset: 0x0008E384
		private bool ShouldSerializelastcheckdowntime()
		{
			return this.lastcheckdowntimeSpecified;
		}

		// Token: 0x06004BC3 RID: 19395 RVA: 0x0009019C File Offset: 0x0008E39C
		private void Resetlastcheckdowntime()
		{
			this.lastcheckdowntimeSpecified = false;
		}

		// Token: 0x17001750 RID: 5968
		// (get) Token: 0x06004BC4 RID: 19396 RVA: 0x000901A8 File Offset: 0x0008E3A8
		[ProtoMember(7, Name = "activateid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> activateid
		{
			get
			{
				return this._activateid;
			}
		}

		// Token: 0x06004BC5 RID: 19397 RVA: 0x000901C0 File Offset: 0x0008E3C0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012C8 RID: 4808
		private uint? _lastconsumetime;

		// Token: 0x040012C9 RID: 4809
		private uint? _consumescore;

		// Token: 0x040012CA RID: 4810
		private uint? _maxconsumelv;

		// Token: 0x040012CB RID: 4811
		private uint? _thismonthcost;

		// Token: 0x040012CC RID: 4812
		private readonly List<uint> _setid = new List<uint>();

		// Token: 0x040012CD RID: 4813
		private uint? _lastcheckdowntime;

		// Token: 0x040012CE RID: 4814
		private readonly List<uint> _activateid = new List<uint>();

		// Token: 0x040012CF RID: 4815
		private IExtension extensionObject;
	}
}
