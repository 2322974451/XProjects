using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetAchieveBrifInfoRes")]
	[Serializable]
	public class GetAchieveBrifInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
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

		[ProtoMember(4, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<AchieveBriefInfo> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "rewardId", DataFormat = DataFormat.TwosComplement)]
		public uint rewardId
		{
			get
			{
				return this._rewardId ?? 0U;
			}
			set
			{
				this._rewardId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rewardIdSpecified
		{
			get
			{
				return this._rewardId != null;
			}
			set
			{
				bool flag = value == (this._rewardId == null);
				if (flag)
				{
					this._rewardId = (value ? new uint?(this.rewardId) : null);
				}
			}
		}

		private bool ShouldSerializerewardId()
		{
			return this.rewardIdSpecified;
		}

		private void ResetrewardId()
		{
			this.rewardIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _achievePoint;

		private uint? _maxAchievePoint;

		private readonly List<AchieveBriefInfo> _dataList = new List<AchieveBriefInfo>();

		private uint? _rewardId;

		private IExtension extensionObject;
	}
}
