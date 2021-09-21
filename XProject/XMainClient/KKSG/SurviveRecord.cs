using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200065F RID: 1631
	[ProtoContract(Name = "SurviveRecord")]
	[Serializable]
	public class SurviveRecord : IExtensible
	{
		// Token: 0x17002075 RID: 8309
		// (get) Token: 0x060066CA RID: 26314 RVA: 0x000C4584 File Offset: 0x000C2784
		// (set) Token: 0x060066CB RID: 26315 RVA: 0x000C45B0 File Offset: 0x000C27B0
		[ProtoMember(1, IsRequired = false, Name = "lastweekuptime", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekuptime
		{
			get
			{
				return this._lastweekuptime ?? 0U;
			}
			set
			{
				this._lastweekuptime = new uint?(value);
			}
		}

		// Token: 0x17002076 RID: 8310
		// (get) Token: 0x060066CC RID: 26316 RVA: 0x000C45C0 File Offset: 0x000C27C0
		// (set) Token: 0x060066CD RID: 26317 RVA: 0x000C45E0 File Offset: 0x000C27E0
		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekuptimeSpecified
		{
			get
			{
				return this._lastweekuptime != null;
			}
			set
			{
				bool flag = value == (this._lastweekuptime == null);
				if (flag)
				{
					this._lastweekuptime = (value ? new uint?(this.lastweekuptime) : null);
				}
			}
		}

		// Token: 0x060066CE RID: 26318 RVA: 0x000C4624 File Offset: 0x000C2824
		private bool ShouldSerializelastweekuptime()
		{
			return this.lastweekuptimeSpecified;
		}

		// Token: 0x060066CF RID: 26319 RVA: 0x000C463C File Offset: 0x000C283C
		private void Resetlastweekuptime()
		{
			this.lastweekuptimeSpecified = false;
		}

		// Token: 0x17002077 RID: 8311
		// (get) Token: 0x060066D0 RID: 26320 RVA: 0x000C4648 File Offset: 0x000C2848
		// (set) Token: 0x060066D1 RID: 26321 RVA: 0x000C4674 File Offset: 0x000C2874
		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17002078 RID: 8312
		// (get) Token: 0x060066D2 RID: 26322 RVA: 0x000C4684 File Offset: 0x000C2884
		// (set) Token: 0x060066D3 RID: 26323 RVA: 0x000C46A4 File Offset: 0x000C28A4
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x060066D4 RID: 26324 RVA: 0x000C46E8 File Offset: 0x000C28E8
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x060066D5 RID: 26325 RVA: 0x000C4700 File Offset: 0x000C2900
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x17002079 RID: 8313
		// (get) Token: 0x060066D6 RID: 26326 RVA: 0x000C470C File Offset: 0x000C290C
		// (set) Token: 0x060066D7 RID: 26327 RVA: 0x000C4738 File Offset: 0x000C2938
		[ProtoMember(3, IsRequired = false, Name = "topcount", DataFormat = DataFormat.TwosComplement)]
		public uint topcount
		{
			get
			{
				return this._topcount ?? 0U;
			}
			set
			{
				this._topcount = new uint?(value);
			}
		}

		// Token: 0x1700207A RID: 8314
		// (get) Token: 0x060066D8 RID: 26328 RVA: 0x000C4748 File Offset: 0x000C2948
		// (set) Token: 0x060066D9 RID: 26329 RVA: 0x000C4768 File Offset: 0x000C2968
		[XmlIgnore]
		[Browsable(false)]
		public bool topcountSpecified
		{
			get
			{
				return this._topcount != null;
			}
			set
			{
				bool flag = value == (this._topcount == null);
				if (flag)
				{
					this._topcount = (value ? new uint?(this.topcount) : null);
				}
			}
		}

		// Token: 0x060066DA RID: 26330 RVA: 0x000C47AC File Offset: 0x000C29AC
		private bool ShouldSerializetopcount()
		{
			return this.topcountSpecified;
		}

		// Token: 0x060066DB RID: 26331 RVA: 0x000C47C4 File Offset: 0x000C29C4
		private void Resettopcount()
		{
			this.topcountSpecified = false;
		}

		// Token: 0x1700207B RID: 8315
		// (get) Token: 0x060066DC RID: 26332 RVA: 0x000C47D0 File Offset: 0x000C29D0
		// (set) Token: 0x060066DD RID: 26333 RVA: 0x000C47FC File Offset: 0x000C29FC
		[ProtoMember(4, IsRequired = false, Name = "givereward", DataFormat = DataFormat.Default)]
		public bool givereward
		{
			get
			{
				return this._givereward ?? false;
			}
			set
			{
				this._givereward = new bool?(value);
			}
		}

		// Token: 0x1700207C RID: 8316
		// (get) Token: 0x060066DE RID: 26334 RVA: 0x000C480C File Offset: 0x000C2A0C
		// (set) Token: 0x060066DF RID: 26335 RVA: 0x000C482C File Offset: 0x000C2A2C
		[XmlIgnore]
		[Browsable(false)]
		public bool giverewardSpecified
		{
			get
			{
				return this._givereward != null;
			}
			set
			{
				bool flag = value == (this._givereward == null);
				if (flag)
				{
					this._givereward = (value ? new bool?(this.givereward) : null);
				}
			}
		}

		// Token: 0x060066E0 RID: 26336 RVA: 0x000C4870 File Offset: 0x000C2A70
		private bool ShouldSerializegivereward()
		{
			return this.giverewardSpecified;
		}

		// Token: 0x060066E1 RID: 26337 RVA: 0x000C4888 File Offset: 0x000C2A88
		private void Resetgivereward()
		{
			this.giverewardSpecified = false;
		}

		// Token: 0x060066E2 RID: 26338 RVA: 0x000C4894 File Offset: 0x000C2A94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040018D6 RID: 6358
		private uint? _lastweekuptime;

		// Token: 0x040018D7 RID: 6359
		private uint? _point;

		// Token: 0x040018D8 RID: 6360
		private uint? _topcount;

		// Token: 0x040018D9 RID: 6361
		private bool? _givereward;

		// Token: 0x040018DA RID: 6362
		private IExtension extensionObject;
	}
}
