using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildBonusAppear")]
	[Serializable]
	public class GuildBonusAppear : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bonusID", DataFormat = DataFormat.TwosComplement)]
		public uint bonusID
		{
			get
			{
				return this._bonusID ?? 0U;
			}
			set
			{
				this._bonusID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusIDSpecified
		{
			get
			{
				return this._bonusID != null;
			}
			set
			{
				bool flag = value == (this._bonusID == null);
				if (flag)
				{
					this._bonusID = (value ? new uint?(this.bonusID) : null);
				}
			}
		}

		private bool ShouldSerializebonusID()
		{
			return this.bonusIDSpecified;
		}

		private void ResetbonusID()
		{
			this.bonusIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "bonusType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusType
		{
			get
			{
				return this._bonusType ?? 0U;
			}
			set
			{
				this._bonusType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusTypeSpecified
		{
			get
			{
				return this._bonusType != null;
			}
			set
			{
				bool flag = value == (this._bonusType == null);
				if (flag)
				{
					this._bonusType = (value ? new uint?(this.bonusType) : null);
				}
			}
		}

		private bool ShouldSerializebonusType()
		{
			return this.bonusTypeSpecified;
		}

		private void ResetbonusType()
		{
			this.bonusTypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "maxPeopleNum", DataFormat = DataFormat.TwosComplement)]
		public uint maxPeopleNum
		{
			get
			{
				return this._maxPeopleNum ?? 0U;
			}
			set
			{
				this._maxPeopleNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxPeopleNumSpecified
		{
			get
			{
				return this._maxPeopleNum != null;
			}
			set
			{
				bool flag = value == (this._maxPeopleNum == null);
				if (flag)
				{
					this._maxPeopleNum = (value ? new uint?(this.maxPeopleNum) : null);
				}
			}
		}

		private bool ShouldSerializemaxPeopleNum()
		{
			return this.maxPeopleNumSpecified;
		}

		private void ResetmaxPeopleNum()
		{
			this.maxPeopleNumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "bonusStatus", DataFormat = DataFormat.TwosComplement)]
		public uint bonusStatus
		{
			get
			{
				return this._bonusStatus ?? 0U;
			}
			set
			{
				this._bonusStatus = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusStatusSpecified
		{
			get
			{
				return this._bonusStatus != null;
			}
			set
			{
				bool flag = value == (this._bonusStatus == null);
				if (flag)
				{
					this._bonusStatus = (value ? new uint?(this.bonusStatus) : null);
				}
			}
		}

		private bool ShouldSerializebonusStatus()
		{
			return this.bonusStatusSpecified;
		}

		private void ResetbonusStatus()
		{
			this.bonusStatusSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "leftOpenTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftOpenTime
		{
			get
			{
				return this._leftOpenTime ?? 0U;
			}
			set
			{
				this._leftOpenTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftOpenTimeSpecified
		{
			get
			{
				return this._leftOpenTime != null;
			}
			set
			{
				bool flag = value == (this._leftOpenTime == null);
				if (flag)
				{
					this._leftOpenTime = (value ? new uint?(this.leftOpenTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftOpenTime()
		{
			return this.leftOpenTimeSpecified;
		}

		private void ResetleftOpenTime()
		{
			this.leftOpenTimeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "leftBringBackTime", DataFormat = DataFormat.TwosComplement)]
		public uint leftBringBackTime
		{
			get
			{
				return this._leftBringBackTime ?? 0U;
			}
			set
			{
				this._leftBringBackTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftBringBackTimeSpecified
		{
			get
			{
				return this._leftBringBackTime != null;
			}
			set
			{
				bool flag = value == (this._leftBringBackTime == null);
				if (flag)
				{
					this._leftBringBackTime = (value ? new uint?(this.leftBringBackTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftBringBackTime()
		{
			return this.leftBringBackTimeSpecified;
		}

		private void ResetleftBringBackTime()
		{
			this.leftBringBackTimeSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "sourceName", DataFormat = DataFormat.Default)]
		public string sourceName
		{
			get
			{
				return this._sourceName ?? "";
			}
			set
			{
				this._sourceName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sourceNameSpecified
		{
			get
			{
				return this._sourceName != null;
			}
			set
			{
				bool flag = value == (this._sourceName == null);
				if (flag)
				{
					this._sourceName = (value ? this.sourceName : null);
				}
			}
		}

		private bool ShouldSerializesourceName()
		{
			return this.sourceNameSpecified;
		}

		private void ResetsourceName()
		{
			this.sourceNameSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "alreadyGetPeopleNum", DataFormat = DataFormat.TwosComplement)]
		public uint alreadyGetPeopleNum
		{
			get
			{
				return this._alreadyGetPeopleNum ?? 0U;
			}
			set
			{
				this._alreadyGetPeopleNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool alreadyGetPeopleNumSpecified
		{
			get
			{
				return this._alreadyGetPeopleNum != null;
			}
			set
			{
				bool flag = value == (this._alreadyGetPeopleNum == null);
				if (flag)
				{
					this._alreadyGetPeopleNum = (value ? new uint?(this.alreadyGetPeopleNum) : null);
				}
			}
		}

		private bool ShouldSerializealreadyGetPeopleNum()
		{
			return this.alreadyGetPeopleNumSpecified;
		}

		private void ResetalreadyGetPeopleNum()
		{
			this.alreadyGetPeopleNumSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "needCheckInNum", DataFormat = DataFormat.TwosComplement)]
		public uint needCheckInNum
		{
			get
			{
				return this._needCheckInNum ?? 0U;
			}
			set
			{
				this._needCheckInNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needCheckInNumSpecified
		{
			get
			{
				return this._needCheckInNum != null;
			}
			set
			{
				bool flag = value == (this._needCheckInNum == null);
				if (flag)
				{
					this._needCheckInNum = (value ? new uint?(this.needCheckInNum) : null);
				}
			}
		}

		private bool ShouldSerializeneedCheckInNum()
		{
			return this.needCheckInNumSpecified;
		}

		private void ResetneedCheckInNum()
		{
			this.needCheckInNumSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "bonusContentType", DataFormat = DataFormat.TwosComplement)]
		public uint bonusContentType
		{
			get
			{
				return this._bonusContentType ?? 0U;
			}
			set
			{
				this._bonusContentType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bonusContentTypeSpecified
		{
			get
			{
				return this._bonusContentType != null;
			}
			set
			{
				bool flag = value == (this._bonusContentType == null);
				if (flag)
				{
					this._bonusContentType = (value ? new uint?(this.bonusContentType) : null);
				}
			}
		}

		private bool ShouldSerializebonusContentType()
		{
			return this.bonusContentTypeSpecified;
		}

		private void ResetbonusContentType()
		{
			this.bonusContentTypeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "sourceID", DataFormat = DataFormat.TwosComplement)]
		public ulong sourceID
		{
			get
			{
				return this._sourceID ?? 0UL;
			}
			set
			{
				this._sourceID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool sourceIDSpecified
		{
			get
			{
				return this._sourceID != null;
			}
			set
			{
				bool flag = value == (this._sourceID == null);
				if (flag)
				{
					this._sourceID = (value ? new ulong?(this.sourceID) : null);
				}
			}
		}

		private bool ShouldSerializesourceID()
		{
			return this.sourceIDSpecified;
		}

		private void ResetsourceID()
		{
			this.sourceIDSpecified = false;
		}

		[ProtoMember(12, IsRequired = false, Name = "iconUrl", DataFormat = DataFormat.Default)]
		public string iconUrl
		{
			get
			{
				return this._iconUrl ?? "";
			}
			set
			{
				this._iconUrl = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool iconUrlSpecified
		{
			get
			{
				return this._iconUrl != null;
			}
			set
			{
				bool flag = value == (this._iconUrl == null);
				if (flag)
				{
					this._iconUrl = (value ? this.iconUrl : null);
				}
			}
		}

		private bool ShouldSerializeiconUrl()
		{
			return this.iconUrlSpecified;
		}

		private void ReseticonUrl()
		{
			this.iconUrlSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _bonusID;

		private uint? _bonusType;

		private uint? _maxPeopleNum;

		private uint? _bonusStatus;

		private uint? _leftOpenTime;

		private uint? _leftBringBackTime;

		private string _sourceName;

		private uint? _alreadyGetPeopleNum;

		private uint? _needCheckInNum;

		private uint? _bonusContentType;

		private ulong? _sourceID;

		private string _iconUrl;

		private IExtension extensionObject;
	}
}
