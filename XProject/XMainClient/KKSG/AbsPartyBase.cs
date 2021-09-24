using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AbsPartyBase")]
	[Serializable]
	public class AbsPartyBase : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "diff", DataFormat = DataFormat.TwosComplement)]
		public uint diff
		{
			get
			{
				return this._diff ?? 0U;
			}
			set
			{
				this._diff = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool diffSpecified
		{
			get
			{
				return this._diff != null;
			}
			set
			{
				bool flag = value == (this._diff == null);
				if (flag)
				{
					this._diff = (value ? new uint?(this.diff) : null);
				}
			}
		}

		private bool ShouldSerializediff()
		{
			return this.diffSpecified;
		}

		private void Resetdiff()
		{
			this.diffSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _type;

		private uint? _diff;

		private IExtension extensionObject;
	}
}
