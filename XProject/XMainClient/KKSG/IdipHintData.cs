using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IdipHintData")]
	[Serializable]
	public class IdipHintData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "systemid", DataFormat = DataFormat.TwosComplement)]
		public uint systemid
		{
			get
			{
				return this._systemid ?? 0U;
			}
			set
			{
				this._systemid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool systemidSpecified
		{
			get
			{
				return this._systemid != null;
			}
			set
			{
				bool flag = value == (this._systemid == null);
				if (flag)
				{
					this._systemid = (value ? new uint?(this.systemid) : null);
				}
			}
		}

		private bool ShouldSerializesystemid()
		{
			return this.systemidSpecified;
		}

		private void Resetsystemid()
		{
			this.systemidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "ishint", DataFormat = DataFormat.Default)]
		public bool ishint
		{
			get
			{
				return this._ishint ?? false;
			}
			set
			{
				this._ishint = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ishintSpecified
		{
			get
			{
				return this._ishint != null;
			}
			set
			{
				bool flag = value == (this._ishint == null);
				if (flag)
				{
					this._ishint = (value ? new bool?(this.ishint) : null);
				}
			}
		}

		private bool ShouldSerializeishint()
		{
			return this.ishintSpecified;
		}

		private void Resetishint()
		{
			this.ishintSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _systemid;

		private bool? _ishint;

		private IExtension extensionObject;
	}
}
