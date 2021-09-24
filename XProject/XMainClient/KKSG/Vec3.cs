using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Vec3")]
	[Serializable]
	public class Vec3 : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "x", DataFormat = DataFormat.FixedSize)]
		public float x
		{
			get
			{
				return this._x ?? 0f;
			}
			set
			{
				this._x = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool xSpecified
		{
			get
			{
				return this._x != null;
			}
			set
			{
				bool flag = value == (this._x == null);
				if (flag)
				{
					this._x = (value ? new float?(this.x) : null);
				}
			}
		}

		private bool ShouldSerializex()
		{
			return this.xSpecified;
		}

		private void Resetx()
		{
			this.xSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "y", DataFormat = DataFormat.FixedSize)]
		public float y
		{
			get
			{
				return this._y ?? 0f;
			}
			set
			{
				this._y = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ySpecified
		{
			get
			{
				return this._y != null;
			}
			set
			{
				bool flag = value == (this._y == null);
				if (flag)
				{
					this._y = (value ? new float?(this.y) : null);
				}
			}
		}

		private bool ShouldSerializey()
		{
			return this.ySpecified;
		}

		private void Resety()
		{
			this.ySpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "z", DataFormat = DataFormat.FixedSize)]
		public float z
		{
			get
			{
				return this._z ?? 0f;
			}
			set
			{
				this._z = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool zSpecified
		{
			get
			{
				return this._z != null;
			}
			set
			{
				bool flag = value == (this._z == null);
				if (flag)
				{
					this._z = (value ? new float?(this.z) : null);
				}
			}
		}

		private bool ShouldSerializez()
		{
			return this.zSpecified;
		}

		private void Resetz()
		{
			this.zSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private float? _x;

		private float? _y;

		private float? _z;

		private IExtension extensionObject;
	}
}
