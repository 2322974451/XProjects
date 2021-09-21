using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200063E RID: 1598
	[ProtoContract(Name = "IdipData")]
	[Serializable]
	public class IdipData : IExtensible
	{
		// Token: 0x17001F2E RID: 7982
		// (get) Token: 0x060062FA RID: 25338 RVA: 0x000BCEA8 File Offset: 0x000BB0A8
		// (set) Token: 0x060062FB RID: 25339 RVA: 0x000BCEC0 File Offset: 0x000BB0C0
		[ProtoMember(1, IsRequired = false, Name = "mess", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public IdipMessage mess
		{
			get
			{
				return this._mess;
			}
			set
			{
				this._mess = value;
			}
		}

		// Token: 0x17001F2F RID: 7983
		// (get) Token: 0x060062FC RID: 25340 RVA: 0x000BCECC File Offset: 0x000BB0CC
		[ProtoMember(2, Name = "punishInfo", DataFormat = DataFormat.Default)]
		public List<IdipPunishData> punishInfo
		{
			get
			{
				return this._punishInfo;
			}
		}

		// Token: 0x17001F30 RID: 7984
		// (get) Token: 0x060062FD RID: 25341 RVA: 0x000BCEE4 File Offset: 0x000BB0E4
		// (set) Token: 0x060062FE RID: 25342 RVA: 0x000BCF10 File Offset: 0x000BB110
		[ProtoMember(3, IsRequired = false, Name = "lastSendAntiAddictionTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastSendAntiAddictionTime
		{
			get
			{
				return this._lastSendAntiAddictionTime ?? 0U;
			}
			set
			{
				this._lastSendAntiAddictionTime = new uint?(value);
			}
		}

		// Token: 0x17001F31 RID: 7985
		// (get) Token: 0x060062FF RID: 25343 RVA: 0x000BCF20 File Offset: 0x000BB120
		// (set) Token: 0x06006300 RID: 25344 RVA: 0x000BCF40 File Offset: 0x000BB140
		[XmlIgnore]
		[Browsable(false)]
		public bool lastSendAntiAddictionTimeSpecified
		{
			get
			{
				return this._lastSendAntiAddictionTime != null;
			}
			set
			{
				bool flag = value == (this._lastSendAntiAddictionTime == null);
				if (flag)
				{
					this._lastSendAntiAddictionTime = (value ? new uint?(this.lastSendAntiAddictionTime) : null);
				}
			}
		}

		// Token: 0x06006301 RID: 25345 RVA: 0x000BCF84 File Offset: 0x000BB184
		private bool ShouldSerializelastSendAntiAddictionTime()
		{
			return this.lastSendAntiAddictionTimeSpecified;
		}

		// Token: 0x06006302 RID: 25346 RVA: 0x000BCF9C File Offset: 0x000BB19C
		private void ResetlastSendAntiAddictionTime()
		{
			this.lastSendAntiAddictionTimeSpecified = false;
		}

		// Token: 0x17001F32 RID: 7986
		// (get) Token: 0x06006303 RID: 25347 RVA: 0x000BCFA8 File Offset: 0x000BB1A8
		// (set) Token: 0x06006304 RID: 25348 RVA: 0x000BCFD4 File Offset: 0x000BB1D4
		[ProtoMember(4, IsRequired = false, Name = "isSendAntiAddictionRemind", DataFormat = DataFormat.Default)]
		public bool isSendAntiAddictionRemind
		{
			get
			{
				return this._isSendAntiAddictionRemind ?? false;
			}
			set
			{
				this._isSendAntiAddictionRemind = new bool?(value);
			}
		}

		// Token: 0x17001F33 RID: 7987
		// (get) Token: 0x06006305 RID: 25349 RVA: 0x000BCFE4 File Offset: 0x000BB1E4
		// (set) Token: 0x06006306 RID: 25350 RVA: 0x000BD004 File Offset: 0x000BB204
		[XmlIgnore]
		[Browsable(false)]
		public bool isSendAntiAddictionRemindSpecified
		{
			get
			{
				return this._isSendAntiAddictionRemind != null;
			}
			set
			{
				bool flag = value == (this._isSendAntiAddictionRemind == null);
				if (flag)
				{
					this._isSendAntiAddictionRemind = (value ? new bool?(this.isSendAntiAddictionRemind) : null);
				}
			}
		}

		// Token: 0x06006307 RID: 25351 RVA: 0x000BD048 File Offset: 0x000BB248
		private bool ShouldSerializeisSendAntiAddictionRemind()
		{
			return this.isSendAntiAddictionRemindSpecified;
		}

		// Token: 0x06006308 RID: 25352 RVA: 0x000BD060 File Offset: 0x000BB260
		private void ResetisSendAntiAddictionRemind()
		{
			this.isSendAntiAddictionRemindSpecified = false;
		}

		// Token: 0x17001F34 RID: 7988
		// (get) Token: 0x06006309 RID: 25353 RVA: 0x000BD06C File Offset: 0x000BB26C
		// (set) Token: 0x0600630A RID: 25354 RVA: 0x000BD08D File Offset: 0x000BB28D
		[ProtoMember(5, IsRequired = false, Name = "picUrl", DataFormat = DataFormat.Default)]
		public string picUrl
		{
			get
			{
				return this._picUrl ?? "";
			}
			set
			{
				this._picUrl = value;
			}
		}

		// Token: 0x17001F35 RID: 7989
		// (get) Token: 0x0600630B RID: 25355 RVA: 0x000BD098 File Offset: 0x000BB298
		// (set) Token: 0x0600630C RID: 25356 RVA: 0x000BD0B4 File Offset: 0x000BB2B4
		[XmlIgnore]
		[Browsable(false)]
		public bool picUrlSpecified
		{
			get
			{
				return this._picUrl != null;
			}
			set
			{
				bool flag = value == (this._picUrl == null);
				if (flag)
				{
					this._picUrl = (value ? this.picUrl : null);
				}
			}
		}

		// Token: 0x0600630D RID: 25357 RVA: 0x000BD0E4 File Offset: 0x000BB2E4
		private bool ShouldSerializepicUrl()
		{
			return this.picUrlSpecified;
		}

		// Token: 0x0600630E RID: 25358 RVA: 0x000BD0FC File Offset: 0x000BB2FC
		private void ResetpicUrl()
		{
			this.picUrlSpecified = false;
		}

		// Token: 0x17001F36 RID: 7990
		// (get) Token: 0x0600630F RID: 25359 RVA: 0x000BD108 File Offset: 0x000BB308
		[ProtoMember(6, Name = "notice", DataFormat = DataFormat.Default)]
		public List<PlatNotice> notice
		{
			get
			{
				return this._notice;
			}
		}

		// Token: 0x17001F37 RID: 7991
		// (get) Token: 0x06006310 RID: 25360 RVA: 0x000BD120 File Offset: 0x000BB320
		// (set) Token: 0x06006311 RID: 25361 RVA: 0x000BD14C File Offset: 0x000BB34C
		[ProtoMember(7, IsRequired = false, Name = "xinyue_hint", DataFormat = DataFormat.Default)]
		public bool xinyue_hint
		{
			get
			{
				return this._xinyue_hint ?? false;
			}
			set
			{
				this._xinyue_hint = new bool?(value);
			}
		}

		// Token: 0x17001F38 RID: 7992
		// (get) Token: 0x06006312 RID: 25362 RVA: 0x000BD15C File Offset: 0x000BB35C
		// (set) Token: 0x06006313 RID: 25363 RVA: 0x000BD17C File Offset: 0x000BB37C
		[XmlIgnore]
		[Browsable(false)]
		public bool xinyue_hintSpecified
		{
			get
			{
				return this._xinyue_hint != null;
			}
			set
			{
				bool flag = value == (this._xinyue_hint == null);
				if (flag)
				{
					this._xinyue_hint = (value ? new bool?(this.xinyue_hint) : null);
				}
			}
		}

		// Token: 0x06006314 RID: 25364 RVA: 0x000BD1C0 File Offset: 0x000BB3C0
		private bool ShouldSerializexinyue_hint()
		{
			return this.xinyue_hintSpecified;
		}

		// Token: 0x06006315 RID: 25365 RVA: 0x000BD1D8 File Offset: 0x000BB3D8
		private void Resetxinyue_hint()
		{
			this.xinyue_hintSpecified = false;
		}

		// Token: 0x17001F39 RID: 7993
		// (get) Token: 0x06006316 RID: 25366 RVA: 0x000BD1E4 File Offset: 0x000BB3E4
		[ProtoMember(8, Name = "hintdata", DataFormat = DataFormat.Default)]
		public List<IdipHintData> hintdata
		{
			get
			{
				return this._hintdata;
			}
		}

		// Token: 0x17001F3A RID: 7994
		// (get) Token: 0x06006317 RID: 25367 RVA: 0x000BD1FC File Offset: 0x000BB3FC
		// (set) Token: 0x06006318 RID: 25368 RVA: 0x000BD228 File Offset: 0x000BB428
		[ProtoMember(9, IsRequired = false, Name = "AntiAddictionRemindCount", DataFormat = DataFormat.TwosComplement)]
		public uint AntiAddictionRemindCount
		{
			get
			{
				return this._AntiAddictionRemindCount ?? 0U;
			}
			set
			{
				this._AntiAddictionRemindCount = new uint?(value);
			}
		}

		// Token: 0x17001F3B RID: 7995
		// (get) Token: 0x06006319 RID: 25369 RVA: 0x000BD238 File Offset: 0x000BB438
		// (set) Token: 0x0600631A RID: 25370 RVA: 0x000BD258 File Offset: 0x000BB458
		[XmlIgnore]
		[Browsable(false)]
		public bool AntiAddictionRemindCountSpecified
		{
			get
			{
				return this._AntiAddictionRemindCount != null;
			}
			set
			{
				bool flag = value == (this._AntiAddictionRemindCount == null);
				if (flag)
				{
					this._AntiAddictionRemindCount = (value ? new uint?(this.AntiAddictionRemindCount) : null);
				}
			}
		}

		// Token: 0x0600631B RID: 25371 RVA: 0x000BD29C File Offset: 0x000BB49C
		private bool ShouldSerializeAntiAddictionRemindCount()
		{
			return this.AntiAddictionRemindCountSpecified;
		}

		// Token: 0x0600631C RID: 25372 RVA: 0x000BD2B4 File Offset: 0x000BB4B4
		private void ResetAntiAddictionRemindCount()
		{
			this.AntiAddictionRemindCountSpecified = false;
		}

		// Token: 0x17001F3C RID: 7996
		// (get) Token: 0x0600631D RID: 25373 RVA: 0x000BD2C0 File Offset: 0x000BB4C0
		// (set) Token: 0x0600631E RID: 25374 RVA: 0x000BD2EC File Offset: 0x000BB4EC
		[ProtoMember(10, IsRequired = false, Name = "AdultType", DataFormat = DataFormat.TwosComplement)]
		public int AdultType
		{
			get
			{
				return this._AdultType ?? 0;
			}
			set
			{
				this._AdultType = new int?(value);
			}
		}

		// Token: 0x17001F3D RID: 7997
		// (get) Token: 0x0600631F RID: 25375 RVA: 0x000BD2FC File Offset: 0x000BB4FC
		// (set) Token: 0x06006320 RID: 25376 RVA: 0x000BD31C File Offset: 0x000BB51C
		[XmlIgnore]
		[Browsable(false)]
		public bool AdultTypeSpecified
		{
			get
			{
				return this._AdultType != null;
			}
			set
			{
				bool flag = value == (this._AdultType == null);
				if (flag)
				{
					this._AdultType = (value ? new int?(this.AdultType) : null);
				}
			}
		}

		// Token: 0x06006321 RID: 25377 RVA: 0x000BD360 File Offset: 0x000BB560
		private bool ShouldSerializeAdultType()
		{
			return this.AdultTypeSpecified;
		}

		// Token: 0x06006322 RID: 25378 RVA: 0x000BD378 File Offset: 0x000BB578
		private void ResetAdultType()
		{
			this.AdultTypeSpecified = false;
		}

		// Token: 0x17001F3E RID: 7998
		// (get) Token: 0x06006323 RID: 25379 RVA: 0x000BD384 File Offset: 0x000BB584
		// (set) Token: 0x06006324 RID: 25380 RVA: 0x000BD3B0 File Offset: 0x000BB5B0
		[ProtoMember(11, IsRequired = false, Name = "hgFlag", DataFormat = DataFormat.TwosComplement)]
		public int hgFlag
		{
			get
			{
				return this._hgFlag ?? 0;
			}
			set
			{
				this._hgFlag = new int?(value);
			}
		}

		// Token: 0x17001F3F RID: 7999
		// (get) Token: 0x06006325 RID: 25381 RVA: 0x000BD3C0 File Offset: 0x000BB5C0
		// (set) Token: 0x06006326 RID: 25382 RVA: 0x000BD3E0 File Offset: 0x000BB5E0
		[XmlIgnore]
		[Browsable(false)]
		public bool hgFlagSpecified
		{
			get
			{
				return this._hgFlag != null;
			}
			set
			{
				bool flag = value == (this._hgFlag == null);
				if (flag)
				{
					this._hgFlag = (value ? new int?(this.hgFlag) : null);
				}
			}
		}

		// Token: 0x06006327 RID: 25383 RVA: 0x000BD424 File Offset: 0x000BB624
		private bool ShouldSerializehgFlag()
		{
			return this.hgFlagSpecified;
		}

		// Token: 0x06006328 RID: 25384 RVA: 0x000BD43C File Offset: 0x000BB63C
		private void ResethgFlag()
		{
			this.hgFlagSpecified = false;
		}

		// Token: 0x17001F40 RID: 8000
		// (get) Token: 0x06006329 RID: 25385 RVA: 0x000BD448 File Offset: 0x000BB648
		// (set) Token: 0x0600632A RID: 25386 RVA: 0x000BD474 File Offset: 0x000BB674
		[ProtoMember(12, IsRequired = false, Name = "hgBanTime", DataFormat = DataFormat.TwosComplement)]
		public uint hgBanTime
		{
			get
			{
				return this._hgBanTime ?? 0U;
			}
			set
			{
				this._hgBanTime = new uint?(value);
			}
		}

		// Token: 0x17001F41 RID: 8001
		// (get) Token: 0x0600632B RID: 25387 RVA: 0x000BD484 File Offset: 0x000BB684
		// (set) Token: 0x0600632C RID: 25388 RVA: 0x000BD4A4 File Offset: 0x000BB6A4
		[XmlIgnore]
		[Browsable(false)]
		public bool hgBanTimeSpecified
		{
			get
			{
				return this._hgBanTime != null;
			}
			set
			{
				bool flag = value == (this._hgBanTime == null);
				if (flag)
				{
					this._hgBanTime = (value ? new uint?(this.hgBanTime) : null);
				}
			}
		}

		// Token: 0x0600632D RID: 25389 RVA: 0x000BD4E8 File Offset: 0x000BB6E8
		private bool ShouldSerializehgBanTime()
		{
			return this.hgBanTimeSpecified;
		}

		// Token: 0x0600632E RID: 25390 RVA: 0x000BD500 File Offset: 0x000BB700
		private void ResethgBanTime()
		{
			this.hgBanTimeSpecified = false;
		}

		// Token: 0x17001F42 RID: 8002
		// (get) Token: 0x0600632F RID: 25391 RVA: 0x000BD50C File Offset: 0x000BB70C
		// (set) Token: 0x06006330 RID: 25392 RVA: 0x000BD538 File Offset: 0x000BB738
		[ProtoMember(13, IsRequired = false, Name = "hgGameTime", DataFormat = DataFormat.TwosComplement)]
		public uint hgGameTime
		{
			get
			{
				return this._hgGameTime ?? 0U;
			}
			set
			{
				this._hgGameTime = new uint?(value);
			}
		}

		// Token: 0x17001F43 RID: 8003
		// (get) Token: 0x06006331 RID: 25393 RVA: 0x000BD548 File Offset: 0x000BB748
		// (set) Token: 0x06006332 RID: 25394 RVA: 0x000BD568 File Offset: 0x000BB768
		[XmlIgnore]
		[Browsable(false)]
		public bool hgGameTimeSpecified
		{
			get
			{
				return this._hgGameTime != null;
			}
			set
			{
				bool flag = value == (this._hgGameTime == null);
				if (flag)
				{
					this._hgGameTime = (value ? new uint?(this.hgGameTime) : null);
				}
			}
		}

		// Token: 0x06006333 RID: 25395 RVA: 0x000BD5AC File Offset: 0x000BB7AC
		private bool ShouldSerializehgGameTime()
		{
			return this.hgGameTimeSpecified;
		}

		// Token: 0x06006334 RID: 25396 RVA: 0x000BD5C4 File Offset: 0x000BB7C4
		private void ResethgGameTime()
		{
			this.hgGameTimeSpecified = false;
		}

		// Token: 0x17001F44 RID: 8004
		// (get) Token: 0x06006335 RID: 25397 RVA: 0x000BD5D0 File Offset: 0x000BB7D0
		// (set) Token: 0x06006336 RID: 25398 RVA: 0x000BD5FC File Offset: 0x000BB7FC
		[ProtoMember(14, IsRequired = false, Name = "isGetHg", DataFormat = DataFormat.Default)]
		public bool isGetHg
		{
			get
			{
				return this._isGetHg ?? false;
			}
			set
			{
				this._isGetHg = new bool?(value);
			}
		}

		// Token: 0x17001F45 RID: 8005
		// (get) Token: 0x06006337 RID: 25399 RVA: 0x000BD60C File Offset: 0x000BB80C
		// (set) Token: 0x06006338 RID: 25400 RVA: 0x000BD62C File Offset: 0x000BB82C
		[XmlIgnore]
		[Browsable(false)]
		public bool isGetHgSpecified
		{
			get
			{
				return this._isGetHg != null;
			}
			set
			{
				bool flag = value == (this._isGetHg == null);
				if (flag)
				{
					this._isGetHg = (value ? new bool?(this.isGetHg) : null);
				}
			}
		}

		// Token: 0x06006339 RID: 25401 RVA: 0x000BD670 File Offset: 0x000BB870
		private bool ShouldSerializeisGetHg()
		{
			return this.isGetHgSpecified;
		}

		// Token: 0x0600633A RID: 25402 RVA: 0x000BD688 File Offset: 0x000BB888
		private void ResetisGetHg()
		{
			this.isGetHgSpecified = false;
		}

		// Token: 0x17001F46 RID: 8006
		// (get) Token: 0x0600633B RID: 25403 RVA: 0x000BD694 File Offset: 0x000BB894
		[ProtoMember(15, Name = "resume", DataFormat = DataFormat.Default)]
		public List<ResumeItem> resume
		{
			get
			{
				return this._resume;
			}
		}

		// Token: 0x0600633C RID: 25404 RVA: 0x000BD6AC File Offset: 0x000BB8AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040017FB RID: 6139
		private IdipMessage _mess = null;

		// Token: 0x040017FC RID: 6140
		private readonly List<IdipPunishData> _punishInfo = new List<IdipPunishData>();

		// Token: 0x040017FD RID: 6141
		private uint? _lastSendAntiAddictionTime;

		// Token: 0x040017FE RID: 6142
		private bool? _isSendAntiAddictionRemind;

		// Token: 0x040017FF RID: 6143
		private string _picUrl;

		// Token: 0x04001800 RID: 6144
		private readonly List<PlatNotice> _notice = new List<PlatNotice>();

		// Token: 0x04001801 RID: 6145
		private bool? _xinyue_hint;

		// Token: 0x04001802 RID: 6146
		private readonly List<IdipHintData> _hintdata = new List<IdipHintData>();

		// Token: 0x04001803 RID: 6147
		private uint? _AntiAddictionRemindCount;

		// Token: 0x04001804 RID: 6148
		private int? _AdultType;

		// Token: 0x04001805 RID: 6149
		private int? _hgFlag;

		// Token: 0x04001806 RID: 6150
		private uint? _hgBanTime;

		// Token: 0x04001807 RID: 6151
		private uint? _hgGameTime;

		// Token: 0x04001808 RID: 6152
		private bool? _isGetHg;

		// Token: 0x04001809 RID: 6153
		private readonly List<ResumeItem> _resume = new List<ResumeItem>();

		// Token: 0x0400180A RID: 6154
		private IExtension extensionObject;
	}
}
