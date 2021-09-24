using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "EnterBMReadySceneRes")]
	[Serializable]
	public class EnterBMReadySceneRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "group", DataFormat = DataFormat.TwosComplement)]
		public uint group
		{
			get
			{
				return this._group ?? 0U;
			}
			set
			{
				this._group = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupSpecified
		{
			get
			{
				return this._group != null;
			}
			set
			{
				bool flag = value == (this._group == null);
				if (flag)
				{
					this._group = (value ? new uint?(this.group) : null);
				}
			}
		}

		private bool ShouldSerializegroup()
		{
			return this.groupSpecified;
		}

		private void Resetgroup()
		{
			this.groupSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private uint? _group;

		private IExtension extensionObject;
	}
}
