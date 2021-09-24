using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "Position")]
	[Serializable]
	public class Position : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uid", DataFormat = DataFormat.TwosComplement)]
		public ulong uid
		{
			get
			{
				return this._uid ?? 0UL;
			}
			set
			{
				this._uid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uidSpecified
		{
			get
			{
				return this._uid != null;
			}
			set
			{
				bool flag = value == (this._uid == null);
				if (flag)
				{
					this._uid = (value ? new ulong?(this.uid) : null);
				}
			}
		}

		private bool ShouldSerializeuid()
		{
			return this.uidSpecified;
		}

		private void Resetuid()
		{
			this.uidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "pos_x", DataFormat = DataFormat.TwosComplement)]
		public int pos_x
		{
			get
			{
				return this._pos_x ?? 0;
			}
			set
			{
				this._pos_x = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pos_xSpecified
		{
			get
			{
				return this._pos_x != null;
			}
			set
			{
				bool flag = value == (this._pos_x == null);
				if (flag)
				{
					this._pos_x = (value ? new int?(this.pos_x) : null);
				}
			}
		}

		private bool ShouldSerializepos_x()
		{
			return this.pos_xSpecified;
		}

		private void Resetpos_x()
		{
			this.pos_xSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "pos_y", DataFormat = DataFormat.TwosComplement)]
		public int pos_y
		{
			get
			{
				return this._pos_y ?? 0;
			}
			set
			{
				this._pos_y = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pos_ySpecified
		{
			get
			{
				return this._pos_y != null;
			}
			set
			{
				bool flag = value == (this._pos_y == null);
				if (flag)
				{
					this._pos_y = (value ? new int?(this.pos_y) : null);
				}
			}
		}

		private bool ShouldSerializepos_y()
		{
			return this.pos_ySpecified;
		}

		private void Resetpos_y()
		{
			this.pos_ySpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "pos_z", DataFormat = DataFormat.TwosComplement)]
		public int pos_z
		{
			get
			{
				return this._pos_z ?? 0;
			}
			set
			{
				this._pos_z = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pos_zSpecified
		{
			get
			{
				return this._pos_z != null;
			}
			set
			{
				bool flag = value == (this._pos_z == null);
				if (flag)
				{
					this._pos_z = (value ? new int?(this.pos_z) : null);
				}
			}
		}

		private bool ShouldSerializepos_z()
		{
			return this.pos_zSpecified;
		}

		private void Resetpos_z()
		{
			this.pos_zSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "face", DataFormat = DataFormat.TwosComplement)]
		public int face
		{
			get
			{
				return this._face ?? 0;
			}
			set
			{
				this._face = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool faceSpecified
		{
			get
			{
				return this._face != null;
			}
			set
			{
				bool flag = value == (this._face == null);
				if (flag)
				{
					this._face = (value ? new int?(this.face) : null);
				}
			}
		}

		private bool ShouldSerializeface()
		{
			return this.faceSpecified;
		}

		private void Resetface()
		{
			this.faceSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "bTransfer", DataFormat = DataFormat.Default)]
		public bool bTransfer
		{
			get
			{
				return this._bTransfer ?? false;
			}
			set
			{
				this._bTransfer = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bTransferSpecified
		{
			get
			{
				return this._bTransfer != null;
			}
			set
			{
				bool flag = value == (this._bTransfer == null);
				if (flag)
				{
					this._bTransfer = (value ? new bool?(this.bTransfer) : null);
				}
			}
		}

		private bool ShouldSerializebTransfer()
		{
			return this.bTransferSpecified;
		}

		private void ResetbTransfer()
		{
			this.bTransferSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uid;

		private int? _pos_x;

		private int? _pos_y;

		private int? _pos_z;

		private int? _face;

		private bool? _bTransfer;

		private IExtension extensionObject;
	}
}
