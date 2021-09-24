using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaAddExpData")]
	[Serializable]
	public class MobaAddExpData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "addexp", DataFormat = DataFormat.TwosComplement)]
		public double addexp
		{
			get
			{
				return this._addexp ?? 0.0;
			}
			set
			{
				this._addexp = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool addexpSpecified
		{
			get
			{
				return this._addexp != null;
			}
			set
			{
				bool flag = value == (this._addexp == null);
				if (flag)
				{
					this._addexp = (value ? new double?(this.addexp) : null);
				}
			}
		}

		private bool ShouldSerializeaddexp()
		{
			return this.addexpSpecified;
		}

		private void Resetaddexp()
		{
			this.addexpSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "posxz", DataFormat = DataFormat.TwosComplement)]
		public uint posxz
		{
			get
			{
				return this._posxz ?? 0U;
			}
			set
			{
				this._posxz = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool posxzSpecified
		{
			get
			{
				return this._posxz != null;
			}
			set
			{
				bool flag = value == (this._posxz == null);
				if (flag)
				{
					this._posxz = (value ? new uint?(this.posxz) : null);
				}
			}
		}

		private bool ShouldSerializeposxz()
		{
			return this.posxzSpecified;
		}

		private void Resetposxz()
		{
			this.posxzSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private double? _addexp;

		private uint? _posxz;

		private IExtension extensionObject;
	}
}
