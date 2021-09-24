using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SelectRoleNewRes")]
	[Serializable]
	public class SelectRoleNewRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "banTime", DataFormat = DataFormat.TwosComplement)]
		public int banTime
		{
			get
			{
				return this._banTime ?? 0;
			}
			set
			{
				this._banTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool banTimeSpecified
		{
			get
			{
				return this._banTime != null;
			}
			set
			{
				bool flag = value == (this._banTime == null);
				if (flag)
				{
					this._banTime = (value ? new int?(this.banTime) : null);
				}
			}
		}

		private bool ShouldSerializebanTime()
		{
			return this.banTimeSpecified;
		}

		private void ResetbanTime()
		{
			this.banTimeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public int endTime
		{
			get
			{
				return this._endTime ?? 0;
			}
			set
			{
				this._endTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new int?(this.endTime) : null);
				}
			}
		}

		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "reason", DataFormat = DataFormat.Default)]
		public string reason
		{
			get
			{
				return this._reason ?? "";
			}
			set
			{
				this._reason = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? this.reason : null);
				}
			}
		}

		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private int? _banTime;

		private int? _endTime;

		private string _reason;

		private IExtension extensionObject;
	}
}
