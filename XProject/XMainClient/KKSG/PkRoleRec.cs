using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkRoleRec")]
	[Serializable]
	public class PkRoleRec : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
		public uint win
		{
			get
			{
				return this._win ?? 0U;
			}
			set
			{
				this._win = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winSpecified
		{
			get
			{
				return this._win != null;
			}
			set
			{
				bool flag = value == (this._win == null);
				if (flag)
				{
					this._win = (value ? new uint?(this.win) : null);
				}
			}
		}

		private bool ShouldSerializewin()
		{
			return this.winSpecified;
		}

		private void Resetwin()
		{
			this.winSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
		public uint lose
		{
			get
			{
				return this._lose ?? 0U;
			}
			set
			{
				this._lose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool loseSpecified
		{
			get
			{
				return this._lose != null;
			}
			set
			{
				bool flag = value == (this._lose == null);
				if (flag)
				{
					this._lose = (value ? new uint?(this.lose) : null);
				}
			}
		}

		private bool ShouldSerializelose()
		{
			return this.loseSpecified;
		}

		private void Resetlose()
		{
			this.loseSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
		public uint draw
		{
			get
			{
				return this._draw ?? 0U;
			}
			set
			{
				this._draw = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool drawSpecified
		{
			get
			{
				return this._draw != null;
			}
			set
			{
				bool flag = value == (this._draw == null);
				if (flag)
				{
					this._draw = (value ? new uint?(this.draw) : null);
				}
			}
		}

		private bool ShouldSerializedraw()
		{
			return this.drawSpecified;
		}

		private void Resetdraw()
		{
			this.drawSpecified = false;
		}

		[ProtoMember(5, Name = "records", DataFormat = DataFormat.TwosComplement)]
		public List<uint> records
		{
			get
			{
				return this._records;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _point;

		private uint? _win;

		private uint? _lose;

		private uint? _draw;

		private readonly List<uint> _records = new List<uint>();

		private IExtension extensionObject;
	}
}
