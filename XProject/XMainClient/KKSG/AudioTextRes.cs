using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AudioTextRes")]
	[Serializable]
	public class AudioTextRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "file_text", DataFormat = DataFormat.Default)]
		public string file_text
		{
			get
			{
				return this._file_text ?? "";
			}
			set
			{
				this._file_text = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool file_textSpecified
		{
			get
			{
				return this._file_text != null;
			}
			set
			{
				bool flag = value == (this._file_text == null);
				if (flag)
				{
					this._file_text = (value ? this.file_text : null);
				}
			}
		}

		private bool ShouldSerializefile_text()
		{
			return this.file_textSpecified;
		}

		private void Resetfile_text()
		{
			this.file_textSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private string _file_text;

		private IExtension extensionObject;
	}
}
