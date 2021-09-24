using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GMCmdRes")]
	[Serializable]
	public class GMCmdRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.Default)]
		public bool result
		{
			get
			{
				return this._result ?? false;
			}
			set
			{
				this._result = new bool?(value);
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
					this._result = (value ? new bool?(this.result) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "outputMessage", DataFormat = DataFormat.Default)]
		public string outputMessage
		{
			get
			{
				return this._outputMessage ?? "";
			}
			set
			{
				this._outputMessage = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool outputMessageSpecified
		{
			get
			{
				return this._outputMessage != null;
			}
			set
			{
				bool flag = value == (this._outputMessage == null);
				if (flag)
				{
					this._outputMessage = (value ? this.outputMessage : null);
				}
			}
		}

		private bool ShouldSerializeoutputMessage()
		{
			return this.outputMessageSpecified;
		}

		private void ResetoutputMessage()
		{
			this.outputMessageSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "datablob", DataFormat = DataFormat.Default)]
		public byte[] datablob
		{
			get
			{
				return this._datablob ?? null;
			}
			set
			{
				this._datablob = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool datablobSpecified
		{
			get
			{
				return this._datablob != null;
			}
			set
			{
				bool flag = value == (this._datablob == null);
				if (flag)
				{
					this._datablob = (value ? this.datablob : null);
				}
			}
		}

		private bool ShouldSerializedatablob()
		{
			return this.datablobSpecified;
		}

		private void Resetdatablob()
		{
			this.datablobSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _result;

		private string _outputMessage;

		private byte[] _datablob;

		private IExtension extensionObject;
	}
}
