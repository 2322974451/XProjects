using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BigMeleePoint")]
	[Serializable]
	public class BigMeleePoint : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
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

		private uint? _point;

		private uint? _posxz;

		private IExtension extensionObject;
	}
}
