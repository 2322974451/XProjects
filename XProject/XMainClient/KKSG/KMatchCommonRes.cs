using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KMatchCommonRes")]
	[Serializable]
	public class KMatchCommonRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "problem_name", DataFormat = DataFormat.Default)]
		public string problem_name
		{
			get
			{
				return this._problem_name ?? "";
			}
			set
			{
				this._problem_name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool problem_nameSpecified
		{
			get
			{
				return this._problem_name != null;
			}
			set
			{
				bool flag = value == (this._problem_name == null);
				if (flag)
				{
					this._problem_name = (value ? this.problem_name : null);
				}
			}
		}

		private bool ShouldSerializeproblem_name()
		{
			return this.problem_nameSpecified;
		}

		private void Resetproblem_name()
		{
			this.problem_nameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "endtime", DataFormat = DataFormat.TwosComplement)]
		public uint endtime
		{
			get
			{
				return this._endtime ?? 0U;
			}
			set
			{
				this._endtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool endtimeSpecified
		{
			get
			{
				return this._endtime != null;
			}
			set
			{
				bool flag = value == (this._endtime == null);
				if (flag)
				{
					this._endtime = (value ? new uint?(this.endtime) : null);
				}
			}
		}

		private bool ShouldSerializeendtime()
		{
			return this.endtimeSpecified;
		}

		private void Resetendtime()
		{
			this.endtimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private string _problem_name;

		private uint? _endtime;

		private IExtension extensionObject;
	}
}
