using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200063C RID: 1596
	[ProtoContract(Name = "WeeklyTaskInfo")]
	[Serializable]
	public class WeeklyTaskInfo : IExtensible
	{
		// Token: 0x17001F18 RID: 7960
		// (get) Token: 0x060062B4 RID: 25268 RVA: 0x000BC5E8 File Offset: 0x000BA7E8
		// (set) Token: 0x060062B5 RID: 25269 RVA: 0x000BC614 File Offset: 0x000BA814
		[ProtoMember(1, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public uint index
		{
			get
			{
				return this._index ?? 0U;
			}
			set
			{
				this._index = new uint?(value);
			}
		}

		// Token: 0x17001F19 RID: 7961
		// (get) Token: 0x060062B6 RID: 25270 RVA: 0x000BC624 File Offset: 0x000BA824
		// (set) Token: 0x060062B7 RID: 25271 RVA: 0x000BC644 File Offset: 0x000BA844
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new uint?(this.index) : null);
				}
			}
		}

		// Token: 0x060062B8 RID: 25272 RVA: 0x000BC688 File Offset: 0x000BA888
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x060062B9 RID: 25273 RVA: 0x000BC6A0 File Offset: 0x000BA8A0
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x17001F1A RID: 7962
		// (get) Token: 0x060062BA RID: 25274 RVA: 0x000BC6AC File Offset: 0x000BA8AC
		// (set) Token: 0x060062BB RID: 25275 RVA: 0x000BC6D8 File Offset: 0x000BA8D8
		[ProtoMember(2, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17001F1B RID: 7963
		// (get) Token: 0x060062BC RID: 25276 RVA: 0x000BC6E8 File Offset: 0x000BA8E8
		// (set) Token: 0x060062BD RID: 25277 RVA: 0x000BC708 File Offset: 0x000BA908
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

		// Token: 0x060062BE RID: 25278 RVA: 0x000BC74C File Offset: 0x000BA94C
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060062BF RID: 25279 RVA: 0x000BC764 File Offset: 0x000BA964
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17001F1C RID: 7964
		// (get) Token: 0x060062C0 RID: 25280 RVA: 0x000BC770 File Offset: 0x000BA970
		// (set) Token: 0x060062C1 RID: 25281 RVA: 0x000BC79C File Offset: 0x000BA99C
		[ProtoMember(3, IsRequired = false, Name = "step", DataFormat = DataFormat.TwosComplement)]
		public uint step
		{
			get
			{
				return this._step ?? 0U;
			}
			set
			{
				this._step = new uint?(value);
			}
		}

		// Token: 0x17001F1D RID: 7965
		// (get) Token: 0x060062C2 RID: 25282 RVA: 0x000BC7AC File Offset: 0x000BA9AC
		// (set) Token: 0x060062C3 RID: 25283 RVA: 0x000BC7CC File Offset: 0x000BA9CC
		[XmlIgnore]
		[Browsable(false)]
		public bool stepSpecified
		{
			get
			{
				return this._step != null;
			}
			set
			{
				bool flag = value == (this._step == null);
				if (flag)
				{
					this._step = (value ? new uint?(this.step) : null);
				}
			}
		}

		// Token: 0x060062C4 RID: 25284 RVA: 0x000BC810 File Offset: 0x000BAA10
		private bool ShouldSerializestep()
		{
			return this.stepSpecified;
		}

		// Token: 0x060062C5 RID: 25285 RVA: 0x000BC828 File Offset: 0x000BAA28
		private void Resetstep()
		{
			this.stepSpecified = false;
		}

		// Token: 0x17001F1E RID: 7966
		// (get) Token: 0x060062C6 RID: 25286 RVA: 0x000BC834 File Offset: 0x000BAA34
		// (set) Token: 0x060062C7 RID: 25287 RVA: 0x000BC860 File Offset: 0x000BAA60
		[ProtoMember(4, IsRequired = false, Name = "is_rewarded", DataFormat = DataFormat.Default)]
		public bool is_rewarded
		{
			get
			{
				return this._is_rewarded ?? false;
			}
			set
			{
				this._is_rewarded = new bool?(value);
			}
		}

		// Token: 0x17001F1F RID: 7967
		// (get) Token: 0x060062C8 RID: 25288 RVA: 0x000BC870 File Offset: 0x000BAA70
		// (set) Token: 0x060062C9 RID: 25289 RVA: 0x000BC890 File Offset: 0x000BAA90
		[XmlIgnore]
		[Browsable(false)]
		public bool is_rewardedSpecified
		{
			get
			{
				return this._is_rewarded != null;
			}
			set
			{
				bool flag = value == (this._is_rewarded == null);
				if (flag)
				{
					this._is_rewarded = (value ? new bool?(this.is_rewarded) : null);
				}
			}
		}

		// Token: 0x060062CA RID: 25290 RVA: 0x000BC8D4 File Offset: 0x000BAAD4
		private bool ShouldSerializeis_rewarded()
		{
			return this.is_rewardedSpecified;
		}

		// Token: 0x060062CB RID: 25291 RVA: 0x000BC8EC File Offset: 0x000BAAEC
		private void Resetis_rewarded()
		{
			this.is_rewardedSpecified = false;
		}

		// Token: 0x17001F20 RID: 7968
		// (get) Token: 0x060062CC RID: 25292 RVA: 0x000BC8F8 File Offset: 0x000BAAF8
		// (set) Token: 0x060062CD RID: 25293 RVA: 0x000BC924 File Offset: 0x000BAB24
		[ProtoMember(5, IsRequired = false, Name = "ask_help", DataFormat = DataFormat.Default)]
		public bool ask_help
		{
			get
			{
				return this._ask_help ?? false;
			}
			set
			{
				this._ask_help = new bool?(value);
			}
		}

		// Token: 0x17001F21 RID: 7969
		// (get) Token: 0x060062CE RID: 25294 RVA: 0x000BC934 File Offset: 0x000BAB34
		// (set) Token: 0x060062CF RID: 25295 RVA: 0x000BC954 File Offset: 0x000BAB54
		[XmlIgnore]
		[Browsable(false)]
		public bool ask_helpSpecified
		{
			get
			{
				return this._ask_help != null;
			}
			set
			{
				bool flag = value == (this._ask_help == null);
				if (flag)
				{
					this._ask_help = (value ? new bool?(this.ask_help) : null);
				}
			}
		}

		// Token: 0x060062D0 RID: 25296 RVA: 0x000BC998 File Offset: 0x000BAB98
		private bool ShouldSerializeask_help()
		{
			return this.ask_helpSpecified;
		}

		// Token: 0x060062D1 RID: 25297 RVA: 0x000BC9B0 File Offset: 0x000BABB0
		private void Resetask_help()
		{
			this.ask_helpSpecified = false;
		}

		// Token: 0x17001F22 RID: 7970
		// (get) Token: 0x060062D2 RID: 25298 RVA: 0x000BC9BC File Offset: 0x000BABBC
		// (set) Token: 0x060062D3 RID: 25299 RVA: 0x000BC9E8 File Offset: 0x000BABE8
		[ProtoMember(6, IsRequired = false, Name = "refresh_count", DataFormat = DataFormat.TwosComplement)]
		public uint refresh_count
		{
			get
			{
				return this._refresh_count ?? 0U;
			}
			set
			{
				this._refresh_count = new uint?(value);
			}
		}

		// Token: 0x17001F23 RID: 7971
		// (get) Token: 0x060062D4 RID: 25300 RVA: 0x000BC9F8 File Offset: 0x000BABF8
		// (set) Token: 0x060062D5 RID: 25301 RVA: 0x000BCA18 File Offset: 0x000BAC18
		[XmlIgnore]
		[Browsable(false)]
		public bool refresh_countSpecified
		{
			get
			{
				return this._refresh_count != null;
			}
			set
			{
				bool flag = value == (this._refresh_count == null);
				if (flag)
				{
					this._refresh_count = (value ? new uint?(this.refresh_count) : null);
				}
			}
		}

		// Token: 0x060062D6 RID: 25302 RVA: 0x000BCA5C File Offset: 0x000BAC5C
		private bool ShouldSerializerefresh_count()
		{
			return this.refresh_countSpecified;
		}

		// Token: 0x060062D7 RID: 25303 RVA: 0x000BCA74 File Offset: 0x000BAC74
		private void Resetrefresh_count()
		{
			this.refresh_countSpecified = false;
		}

		// Token: 0x060062D8 RID: 25304 RVA: 0x000BCA80 File Offset: 0x000BAC80
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017EE RID: 6126
		private uint? _index;

		// Token: 0x040017EF RID: 6127
		private uint? _id;

		// Token: 0x040017F0 RID: 6128
		private uint? _step;

		// Token: 0x040017F1 RID: 6129
		private bool? _is_rewarded;

		// Token: 0x040017F2 RID: 6130
		private bool? _ask_help;

		// Token: 0x040017F3 RID: 6131
		private uint? _refresh_count;

		// Token: 0x040017F4 RID: 6132
		private IExtension extensionObject;
	}
}
