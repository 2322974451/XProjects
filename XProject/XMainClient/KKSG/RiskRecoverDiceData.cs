using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "RiskRecoverDiceData")]
	[Serializable]
	public class RiskRecoverDiceData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "diceNum", DataFormat = DataFormat.TwosComplement)]
		public int diceNum
		{
			get
			{
				return this._diceNum ?? 0;
			}
			set
			{
				this._diceNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool diceNumSpecified
		{
			get
			{
				return this._diceNum != null;
			}
			set
			{
				bool flag = value == (this._diceNum == null);
				if (flag)
				{
					this._diceNum = (value ? new int?(this.diceNum) : null);
				}
			}
		}

		private bool ShouldSerializediceNum()
		{
			return this.diceNumSpecified;
		}

		private void ResetdiceNum()
		{
			this.diceNumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leftDiceTime", DataFormat = DataFormat.TwosComplement)]
		public int leftDiceTime
		{
			get
			{
				return this._leftDiceTime ?? 0;
			}
			set
			{
				this._leftDiceTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftDiceTimeSpecified
		{
			get
			{
				return this._leftDiceTime != null;
			}
			set
			{
				bool flag = value == (this._leftDiceTime == null);
				if (flag)
				{
					this._leftDiceTime = (value ? new int?(this.leftDiceTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftDiceTime()
		{
			return this.leftDiceTimeSpecified;
		}

		private void ResetleftDiceTime()
		{
			this.leftDiceTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _diceNum;

		private int? _leftDiceTime;

		private IExtension extensionObject;
	}
}
