using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AchieveBriefInfo")]
	[Serializable]
	public class AchieveBriefInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "achieveClassifyType", DataFormat = DataFormat.TwosComplement)]
		public uint achieveClassifyType
		{
			get
			{
				return this._achieveClassifyType ?? 0U;
			}
			set
			{
				this._achieveClassifyType = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool achieveClassifyTypeSpecified
		{
			get
			{
				return this._achieveClassifyType != null;
			}
			set
			{
				bool flag = value == (this._achieveClassifyType == null);
				if (flag)
				{
					this._achieveClassifyType = (value ? new uint?(this.achieveClassifyType) : null);
				}
			}
		}

		private bool ShouldSerializeachieveClassifyType()
		{
			return this.achieveClassifyTypeSpecified;
		}

		private void ResetachieveClassifyType()
		{
			this.achieveClassifyTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "achievePoint", DataFormat = DataFormat.TwosComplement)]
		public uint achievePoint
		{
			get
			{
				return this._achievePoint ?? 0U;
			}
			set
			{
				this._achievePoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool achievePointSpecified
		{
			get
			{
				return this._achievePoint != null;
			}
			set
			{
				bool flag = value == (this._achievePoint == null);
				if (flag)
				{
					this._achievePoint = (value ? new uint?(this.achievePoint) : null);
				}
			}
		}

		private bool ShouldSerializeachievePoint()
		{
			return this.achievePointSpecified;
		}

		private void ResetachievePoint()
		{
			this.achievePointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "maxAchievePoint", DataFormat = DataFormat.TwosComplement)]
		public uint maxAchievePoint
		{
			get
			{
				return this._maxAchievePoint ?? 0U;
			}
			set
			{
				this._maxAchievePoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxAchievePointSpecified
		{
			get
			{
				return this._maxAchievePoint != null;
			}
			set
			{
				bool flag = value == (this._maxAchievePoint == null);
				if (flag)
				{
					this._maxAchievePoint = (value ? new uint?(this.maxAchievePoint) : null);
				}
			}
		}

		private bool ShouldSerializemaxAchievePoint()
		{
			return this.maxAchievePointSpecified;
		}

		private void ResetmaxAchievePoint()
		{
			this.maxAchievePointSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "canRewardCount", DataFormat = DataFormat.TwosComplement)]
		public uint canRewardCount
		{
			get
			{
				return this._canRewardCount ?? 0U;
			}
			set
			{
				this._canRewardCount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool canRewardCountSpecified
		{
			get
			{
				return this._canRewardCount != null;
			}
			set
			{
				bool flag = value == (this._canRewardCount == null);
				if (flag)
				{
					this._canRewardCount = (value ? new uint?(this.canRewardCount) : null);
				}
			}
		}

		private bool ShouldSerializecanRewardCount()
		{
			return this.canRewardCountSpecified;
		}

		private void ResetcanRewardCount()
		{
			this.canRewardCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _achieveClassifyType;

		private uint? _achievePoint;

		private uint? _maxAchievePoint;

		private uint? _canRewardCount;

		private IExtension extensionObject;
	}
}
