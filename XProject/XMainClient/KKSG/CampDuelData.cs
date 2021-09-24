using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CampDuelData")]
	[Serializable]
	public class CampDuelData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "campid", DataFormat = DataFormat.TwosComplement)]
		public uint campid
		{
			get
			{
				return this._campid ?? 0U;
			}
			set
			{
				this._campid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool campidSpecified
		{
			get
			{
				return this._campid != null;
			}
			set
			{
				bool flag = value == (this._campid == null);
				if (flag)
				{
					this._campid = (value ? new uint?(this.campid) : null);
				}
			}
		}

		private bool ShouldSerializecampid()
		{
			return this.campidSpecified;
		}

		private void Resetcampid()
		{
			this.campidSpecified = false;
		}

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

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "freeInspireCount", DataFormat = DataFormat.TwosComplement)]
		public uint freeInspireCount
		{
			get
			{
				return this._freeInspireCount ?? 0U;
			}
			set
			{
				this._freeInspireCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool freeInspireCountSpecified
		{
			get
			{
				return this._freeInspireCount != null;
			}
			set
			{
				bool flag = value == (this._freeInspireCount == null);
				if (flag)
				{
					this._freeInspireCount = (value ? new uint?(this.freeInspireCount) : null);
				}
			}
		}

		private bool ShouldSerializefreeInspireCount()
		{
			return this.freeInspireCountSpecified;
		}

		private void ResetfreeInspireCount()
		{
			this.freeInspireCountSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "dragonCoinInspireCount", DataFormat = DataFormat.TwosComplement)]
		public uint dragonCoinInspireCount
		{
			get
			{
				return this._dragonCoinInspireCount ?? 0U;
			}
			set
			{
				this._dragonCoinInspireCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonCoinInspireCountSpecified
		{
			get
			{
				return this._dragonCoinInspireCount != null;
			}
			set
			{
				bool flag = value == (this._dragonCoinInspireCount == null);
				if (flag)
				{
					this._dragonCoinInspireCount = (value ? new uint?(this.dragonCoinInspireCount) : null);
				}
			}
		}

		private bool ShouldSerializedragonCoinInspireCount()
		{
			return this.dragonCoinInspireCountSpecified;
		}

		private void ResetdragonCoinInspireCount()
		{
			this.dragonCoinInspireCountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "isGiveReward", DataFormat = DataFormat.Default)]
		public bool isGiveReward
		{
			get
			{
				return this._isGiveReward ?? false;
			}
			set
			{
				this._isGiveReward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isGiveRewardSpecified
		{
			get
			{
				return this._isGiveReward != null;
			}
			set
			{
				bool flag = value == (this._isGiveReward == null);
				if (flag)
				{
					this._isGiveReward = (value ? new bool?(this.isGiveReward) : null);
				}
			}
		}

		private bool ShouldSerializeisGiveReward()
		{
			return this.isGiveRewardSpecified;
		}

		private void ResetisGiveReward()
		{
			this.isGiveRewardSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "isSendEmail", DataFormat = DataFormat.Default)]
		public bool isSendEmail
		{
			get
			{
				return this._isSendEmail ?? false;
			}
			set
			{
				this._isSendEmail = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isSendEmailSpecified
		{
			get
			{
				return this._isSendEmail != null;
			}
			set
			{
				bool flag = value == (this._isSendEmail == null);
				if (flag)
				{
					this._isSendEmail = (value ? new bool?(this.isSendEmail) : null);
				}
			}
		}

		private bool ShouldSerializeisSendEmail()
		{
			return this.isSendEmailSpecified;
		}

		private void ResetisSendEmail()
		{
			this.isSendEmailSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _campid;

		private uint? _point;

		private uint? _lastUpdateTime;

		private uint? _freeInspireCount;

		private uint? _dragonCoinInspireCount;

		private bool? _isGiveReward;

		private bool? _isSendEmail;

		private IExtension extensionObject;
	}
}
