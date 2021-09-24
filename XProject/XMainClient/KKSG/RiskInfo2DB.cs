using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskInfo2DB")]
	[Serializable]
	public class RiskInfo2DB : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "infos", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RiskMapInfos infos
		{
			get
			{
				return this._infos;
			}
			set
			{
				this._infos = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "updatetime", DataFormat = DataFormat.TwosComplement)]
		public int updatetime
		{
			get
			{
				return this._updatetime ?? 0;
			}
			set
			{
				this._updatetime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool updatetimeSpecified
		{
			get
			{
				return this._updatetime != null;
			}
			set
			{
				bool flag = value == (this._updatetime == null);
				if (flag)
				{
					this._updatetime = (value ? new int?(this.updatetime) : null);
				}
			}
		}

		private bool ShouldSerializeupdatetime()
		{
			return this.updatetimeSpecified;
		}

		private void Resetupdatetime()
		{
			this.updatetimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "getDiceTime", DataFormat = DataFormat.TwosComplement)]
		public int getDiceTime
		{
			get
			{
				return this._getDiceTime ?? 0;
			}
			set
			{
				this._getDiceTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getDiceTimeSpecified
		{
			get
			{
				return this._getDiceTime != null;
			}
			set
			{
				bool flag = value == (this._getDiceTime == null);
				if (flag)
				{
					this._getDiceTime = (value ? new int?(this.getDiceTime) : null);
				}
			}
		}

		private bool ShouldSerializegetDiceTime()
		{
			return this.getDiceTimeSpecified;
		}

		private void ResetgetDiceTime()
		{
			this.getDiceTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "getDiceNum", DataFormat = DataFormat.TwosComplement)]
		public int getDiceNum
		{
			get
			{
				return this._getDiceNum ?? 0;
			}
			set
			{
				this._getDiceNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getDiceNumSpecified
		{
			get
			{
				return this._getDiceNum != null;
			}
			set
			{
				bool flag = value == (this._getDiceNum == null);
				if (flag)
				{
					this._getDiceNum = (value ? new int?(this.getDiceNum) : null);
				}
			}
		}

		private bool ShouldSerializegetDiceNum()
		{
			return this.getDiceNumSpecified;
		}

		private void ResetgetDiceNum()
		{
			this.getDiceNumSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "riskInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleRiskInfo riskInfo
		{
			get
			{
				return this._riskInfo;
			}
			set
			{
				this._riskInfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RiskMapInfos _infos = null;

		private int? _updatetime;

		private int? _getDiceTime;

		private int? _getDiceNum;

		private RoleRiskInfo _riskInfo = null;

		private IExtension extensionObject;
	}
}
