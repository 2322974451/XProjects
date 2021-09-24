using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetEnhanceAttrArg")]
	[Serializable]
	public class GetEnhanceAttrArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "prof", DataFormat = DataFormat.TwosComplement)]
		public uint prof
		{
			get
			{
				return this._prof ?? 0U;
			}
			set
			{
				this._prof = new uint?(value);
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
					this._prof = (value ? new uint?(this.prof) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "equippos", DataFormat = DataFormat.TwosComplement)]
		public uint equippos
		{
			get
			{
				return this._equippos ?? 0U;
			}
			set
			{
				this._equippos = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool equipposSpecified
		{
			get
			{
				return this._equippos != null;
			}
			set
			{
				bool flag = value == (this._equippos == null);
				if (flag)
				{
					this._equippos = (value ? new uint?(this.equippos) : null);
				}
			}
		}

		private bool ShouldSerializeequippos()
		{
			return this.equipposSpecified;
		}

		private void Resetequippos()
		{
			this.equipposSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "enhancelevel", DataFormat = DataFormat.TwosComplement)]
		public uint enhancelevel
		{
			get
			{
				return this._enhancelevel ?? 0U;
			}
			set
			{
				this._enhancelevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool enhancelevelSpecified
		{
			get
			{
				return this._enhancelevel != null;
			}
			set
			{
				bool flag = value == (this._enhancelevel == null);
				if (flag)
				{
					this._enhancelevel = (value ? new uint?(this.enhancelevel) : null);
				}
			}
		}

		private bool ShouldSerializeenhancelevel()
		{
			return this.enhancelevelSpecified;
		}

		private void Resetenhancelevel()
		{
			this.enhancelevelSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _prof;

		private uint? _equippos;

		private uint? _enhancelevel;

		private IExtension extensionObject;
	}
}
