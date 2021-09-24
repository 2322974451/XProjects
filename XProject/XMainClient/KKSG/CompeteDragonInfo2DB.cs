using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CompeteDragonInfo2DB")]
	[Serializable]
	public class CompeteDragonInfo2DB : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "updateDay", DataFormat = DataFormat.TwosComplement)]
		public int updateDay
		{
			get
			{
				return this._updateDay ?? 0;
			}
			set
			{
				this._updateDay = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updateDaySpecified
		{
			get
			{
				return this._updateDay != null;
			}
			set
			{
				bool flag = value == (this._updateDay == null);
				if (flag)
				{
					this._updateDay = (value ? new int?(this.updateDay) : null);
				}
			}
		}

		private bool ShouldSerializeupdateDay()
		{
			return this.updateDaySpecified;
		}

		private void ResetupdateDay()
		{
			this.updateDaySpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "throughCount", DataFormat = DataFormat.TwosComplement)]
		public uint throughCount
		{
			get
			{
				return this._throughCount ?? 0U;
			}
			set
			{
				this._throughCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool throughCountSpecified
		{
			get
			{
				return this._throughCount != null;
			}
			set
			{
				bool flag = value == (this._throughCount == null);
				if (flag)
				{
					this._throughCount = (value ? new uint?(this.throughCount) : null);
				}
			}
		}

		private bool ShouldSerializethroughCount()
		{
			return this.throughCountSpecified;
		}

		private void ResetthroughCount()
		{
			this.throughCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "getRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint getRewardCount
		{
			get
			{
				return this._getRewardCount ?? 0U;
			}
			set
			{
				this._getRewardCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getRewardCountSpecified
		{
			get
			{
				return this._getRewardCount != null;
			}
			set
			{
				bool flag = value == (this._getRewardCount == null);
				if (flag)
				{
					this._getRewardCount = (value ? new uint?(this.getRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializegetRewardCount()
		{
			return this.getRewardCountSpecified;
		}

		private void ResetgetRewardCount()
		{
			this.getRewardCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _updateDay;

		private uint? _throughCount;

		private uint? _getRewardCount;

		private IExtension extensionObject;
	}
}
