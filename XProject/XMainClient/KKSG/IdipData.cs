using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IdipData")]
	[Serializable]
	public class IdipData : IExtensible
	{

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

		[ProtoMember(2, Name = "punishInfo", DataFormat = DataFormat.Default)]
		public List<IdipPunishData> punishInfo
		{
			get
			{
				return this._punishInfo;
			}
		}

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

		private bool ShouldSerializelastSendAntiAddictionTime()
		{
			return this.lastSendAntiAddictionTimeSpecified;
		}

		private void ResetlastSendAntiAddictionTime()
		{
			this.lastSendAntiAddictionTimeSpecified = false;
		}

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

		private bool ShouldSerializeisSendAntiAddictionRemind()
		{
			return this.isSendAntiAddictionRemindSpecified;
		}

		private void ResetisSendAntiAddictionRemind()
		{
			this.isSendAntiAddictionRemindSpecified = false;
		}

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

		private bool ShouldSerializepicUrl()
		{
			return this.picUrlSpecified;
		}

		private void ResetpicUrl()
		{
			this.picUrlSpecified = false;
		}

		[ProtoMember(6, Name = "notice", DataFormat = DataFormat.Default)]
		public List<PlatNotice> notice
		{
			get
			{
				return this._notice;
			}
		}

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

		private bool ShouldSerializexinyue_hint()
		{
			return this.xinyue_hintSpecified;
		}

		private void Resetxinyue_hint()
		{
			this.xinyue_hintSpecified = false;
		}

		[ProtoMember(8, Name = "hintdata", DataFormat = DataFormat.Default)]
		public List<IdipHintData> hintdata
		{
			get
			{
				return this._hintdata;
			}
		}

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

		private bool ShouldSerializeAntiAddictionRemindCount()
		{
			return this.AntiAddictionRemindCountSpecified;
		}

		private void ResetAntiAddictionRemindCount()
		{
			this.AntiAddictionRemindCountSpecified = false;
		}

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

		private bool ShouldSerializeAdultType()
		{
			return this.AdultTypeSpecified;
		}

		private void ResetAdultType()
		{
			this.AdultTypeSpecified = false;
		}

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

		private bool ShouldSerializehgFlag()
		{
			return this.hgFlagSpecified;
		}

		private void ResethgFlag()
		{
			this.hgFlagSpecified = false;
		}

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

		private bool ShouldSerializehgBanTime()
		{
			return this.hgBanTimeSpecified;
		}

		private void ResethgBanTime()
		{
			this.hgBanTimeSpecified = false;
		}

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

		private bool ShouldSerializehgGameTime()
		{
			return this.hgGameTimeSpecified;
		}

		private void ResethgGameTime()
		{
			this.hgGameTimeSpecified = false;
		}

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

		private bool ShouldSerializeisGetHg()
		{
			return this.isGetHgSpecified;
		}

		private void ResetisGetHg()
		{
			this.isGetHgSpecified = false;
		}

		[ProtoMember(15, Name = "resume", DataFormat = DataFormat.Default)]
		public List<ResumeItem> resume
		{
			get
			{
				return this._resume;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private IdipMessage _mess = null;

		private readonly List<IdipPunishData> _punishInfo = new List<IdipPunishData>();

		private uint? _lastSendAntiAddictionTime;

		private bool? _isSendAntiAddictionRemind;

		private string _picUrl;

		private readonly List<PlatNotice> _notice = new List<PlatNotice>();

		private bool? _xinyue_hint;

		private readonly List<IdipHintData> _hintdata = new List<IdipHintData>();

		private uint? _AntiAddictionRemindCount;

		private int? _AdultType;

		private int? _hgFlag;

		private uint? _hgBanTime;

		private uint? _hgGameTime;

		private bool? _isGetHg;

		private readonly List<ResumeItem> _resume = new List<ResumeItem>();

		private IExtension extensionObject;
	}
}
