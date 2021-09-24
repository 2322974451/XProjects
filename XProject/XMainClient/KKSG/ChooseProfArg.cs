using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChooseProfArg")]
	[Serializable]
	public class ChooseProfArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "prof", DataFormat = DataFormat.TwosComplement)]
		public RoleType prof
		{
			get
			{
				return this._prof ?? RoleType.Role_INVALID;
			}
			set
			{
				this._prof = new RoleType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool profSpecified
		{
			get
			{
				return this._prof != null;
			}
			set
			{
				bool flag = value == (this._prof == null);
				if (flag)
				{
					this._prof = (value ? new RoleType?(this.prof) : null);
				}
			}
		}

		private bool ShouldSerializeprof()
		{
			return this.profSpecified;
		}

		private void Resetprof()
		{
			this.profSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private RoleType? _prof;

		private IExtension extensionObject;
	}
}
