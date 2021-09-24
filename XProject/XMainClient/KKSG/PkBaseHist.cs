using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkBaseHist")]
	[Serializable]
	public class PkBaseHist : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "win", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "lose", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "draw", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(4, IsRequired = false, Name = "lastwin", DataFormat = DataFormat.TwosComplement)]
		public uint lastwin
		{
			get
			{
				return this._lastwin ?? 0U;
			}
			set
			{
				this._lastwin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastwinSpecified
		{
			get
			{
				return this._lastwin != null;
			}
			set
			{
				bool flag = value == (this._lastwin == null);
				if (flag)
				{
					this._lastwin = (value ? new uint?(this.lastwin) : null);
				}
			}
		}

		private bool ShouldSerializelastwin()
		{
			return this.lastwinSpecified;
		}

		private void Resetlastwin()
		{
			this.lastwinSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "lastlose", DataFormat = DataFormat.TwosComplement)]
		public uint lastlose
		{
			get
			{
				return this._lastlose ?? 0U;
			}
			set
			{
				this._lastlose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastloseSpecified
		{
			get
			{
				return this._lastlose != null;
			}
			set
			{
				bool flag = value == (this._lastlose == null);
				if (flag)
				{
					this._lastlose = (value ? new uint?(this.lastlose) : null);
				}
			}
		}

		private bool ShouldSerializelastlose()
		{
			return this.lastloseSpecified;
		}

		private void Resetlastlose()
		{
			this.lastloseSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint continuewin
		{
			get
			{
				return this._continuewin ?? 0U;
			}
			set
			{
				this._continuewin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinSpecified
		{
			get
			{
				return this._continuewin != null;
			}
			set
			{
				bool flag = value == (this._continuewin == null);
				if (flag)
				{
					this._continuewin = (value ? new uint?(this.continuewin) : null);
				}
			}
		}

		private bool ShouldSerializecontinuewin()
		{
			return this.continuewinSpecified;
		}

		private void Resetcontinuewin()
		{
			this.continuewinSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint continuelose
		{
			get
			{
				return this._continuelose ?? 0U;
			}
			set
			{
				this._continuelose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continueloseSpecified
		{
			get
			{
				return this._continuelose != null;
			}
			set
			{
				bool flag = value == (this._continuelose == null);
				if (flag)
				{
					this._continuelose = (value ? new uint?(this.continuelose) : null);
				}
			}
		}

		private bool ShouldSerializecontinuelose()
		{
			return this.continueloseSpecified;
		}

		private void Resetcontinuelose()
		{
			this.continueloseSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _win;

		private uint? _lose;

		private uint? _draw;

		private uint? _lastwin;

		private uint? _lastlose;

		private uint? _continuewin;

		private uint? _continuelose;

		private IExtension extensionObject;
	}
}
