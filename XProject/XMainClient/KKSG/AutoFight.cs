using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AutoFight")]
	[Serializable]
	public class AutoFight : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "autof", DataFormat = DataFormat.Default)]
		public bool autof
		{
			get
			{
				return this._autof ?? false;
			}
			set
			{
				this._autof = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool autofSpecified
		{
			get
			{
				return this._autof != null;
			}
			set
			{
				bool flag = value == (this._autof == null);
				if (flag)
				{
					this._autof = (value ? new bool?(this.autof) : null);
				}
			}
		}

		private bool ShouldSerializeautof()
		{
			return this.autofSpecified;
		}

		private void Resetautof()
		{
			this.autofSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _autof;

		private IExtension extensionObject;
	}
}
