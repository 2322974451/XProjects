using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CommendFirstPassRes")]
	[Serializable]
	public class CommendFirstPassRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "commendNum", DataFormat = DataFormat.TwosComplement)]
		public int commendNum
		{
			get
			{
				return this._commendNum ?? 0;
			}
			set
			{
				this._commendNum = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool commendNumSpecified
		{
			get
			{
				return this._commendNum != null;
			}
			set
			{
				bool flag = value == (this._commendNum == null);
				if (flag)
				{
					this._commendNum = (value ? new int?(this.commendNum) : null);
				}
			}
		}

		private bool ShouldSerializecommendNum()
		{
			return this.commendNumSpecified;
		}

		private void ResetcommendNum()
		{
			this.commendNumSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "starLevel", DataFormat = DataFormat.TwosComplement)]
		public int starLevel
		{
			get
			{
				return this._starLevel ?? 0;
			}
			set
			{
				this._starLevel = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool starLevelSpecified
		{
			get
			{
				return this._starLevel != null;
			}
			set
			{
				bool flag = value == (this._starLevel == null);
				if (flag)
				{
					this._starLevel = (value ? new int?(this.starLevel) : null);
				}
			}
		}

		private bool ShouldSerializestarLevel()
		{
			return this.starLevelSpecified;
		}

		private void ResetstarLevel()
		{
			this.starLevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _commendNum;

		private int? _starLevel;

		private IExtension extensionObject;
	}
}
