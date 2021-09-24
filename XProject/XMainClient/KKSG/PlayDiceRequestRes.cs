using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PlayDiceRequestRes")]
	[Serializable]
	public class PlayDiceRequestRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "getValue", DataFormat = DataFormat.TwosComplement)]
		public int getValue
		{
			get
			{
				return this._getValue ?? 0;
			}
			set
			{
				this._getValue = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getValueSpecified
		{
			get
			{
				return this._getValue != null;
			}
			set
			{
				bool flag = value == (this._getValue == null);
				if (flag)
				{
					this._getValue = (value ? new int?(this.getValue) : null);
				}
			}
		}

		private bool ShouldSerializegetValue()
		{
			return this.getValueSpecified;
		}

		private void ResetgetValue()
		{
			this.getValueSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "leftDiceTime", DataFormat = DataFormat.TwosComplement)]
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

		private ErrorCode? _error;

		private int? _getValue;

		private int? _leftDiceTime;

		private IExtension extensionObject;
	}
}
