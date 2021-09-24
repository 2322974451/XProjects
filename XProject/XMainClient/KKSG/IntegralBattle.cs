using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "IntegralBattle")]
	[Serializable]
	public class IntegralBattle : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildone", DataFormat = DataFormat.TwosComplement)]
		public ulong guildone
		{
			get
			{
				return this._guildone ?? 0UL;
			}
			set
			{
				this._guildone = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildoneSpecified
		{
			get
			{
				return this._guildone != null;
			}
			set
			{
				bool flag = value == (this._guildone == null);
				if (flag)
				{
					this._guildone = (value ? new ulong?(this.guildone) : null);
				}
			}
		}

		private bool ShouldSerializeguildone()
		{
			return this.guildoneSpecified;
		}

		private void Resetguildone()
		{
			this.guildoneSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "guildtwo", DataFormat = DataFormat.TwosComplement)]
		public ulong guildtwo
		{
			get
			{
				return this._guildtwo ?? 0UL;
			}
			set
			{
				this._guildtwo = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildtwoSpecified
		{
			get
			{
				return this._guildtwo != null;
			}
			set
			{
				bool flag = value == (this._guildtwo == null);
				if (flag)
				{
					this._guildtwo = (value ? new ulong?(this.guildtwo) : null);
				}
			}
		}

		private bool ShouldSerializeguildtwo()
		{
			return this.guildtwoSpecified;
		}

		private void Resetguildtwo()
		{
			this.guildtwoSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "isdo", DataFormat = DataFormat.Default)]
		public bool isdo
		{
			get
			{
				return this._isdo ?? false;
			}
			set
			{
				this._isdo = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isdoSpecified
		{
			get
			{
				return this._isdo != null;
			}
			set
			{
				bool flag = value == (this._isdo == null);
				if (flag)
				{
					this._isdo = (value ? new bool?(this.isdo) : null);
				}
			}
		}

		private bool ShouldSerializeisdo()
		{
			return this.isdoSpecified;
		}

		private void Resetisdo()
		{
			this.isdoSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "guildonescore", DataFormat = DataFormat.TwosComplement)]
		public uint guildonescore
		{
			get
			{
				return this._guildonescore ?? 0U;
			}
			set
			{
				this._guildonescore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildonescoreSpecified
		{
			get
			{
				return this._guildonescore != null;
			}
			set
			{
				bool flag = value == (this._guildonescore == null);
				if (flag)
				{
					this._guildonescore = (value ? new uint?(this.guildonescore) : null);
				}
			}
		}

		private bool ShouldSerializeguildonescore()
		{
			return this.guildonescoreSpecified;
		}

		private void Resetguildonescore()
		{
			this.guildonescoreSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "guildtwoscore", DataFormat = DataFormat.TwosComplement)]
		public uint guildtwoscore
		{
			get
			{
				return this._guildtwoscore ?? 0U;
			}
			set
			{
				this._guildtwoscore = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildtwoscoreSpecified
		{
			get
			{
				return this._guildtwoscore != null;
			}
			set
			{
				bool flag = value == (this._guildtwoscore == null);
				if (flag)
				{
					this._guildtwoscore = (value ? new uint?(this.guildtwoscore) : null);
				}
			}
		}

		private bool ShouldSerializeguildtwoscore()
		{
			return this.guildtwoscoreSpecified;
		}

		private void Resetguildtwoscore()
		{
			this.guildtwoscoreSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "nameone", DataFormat = DataFormat.Default)]
		public string nameone
		{
			get
			{
				return this._nameone ?? "";
			}
			set
			{
				this._nameone = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameoneSpecified
		{
			get
			{
				return this._nameone != null;
			}
			set
			{
				bool flag = value == (this._nameone == null);
				if (flag)
				{
					this._nameone = (value ? this.nameone : null);
				}
			}
		}

		private bool ShouldSerializenameone()
		{
			return this.nameoneSpecified;
		}

		private void Resetnameone()
		{
			this.nameoneSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "nametwo", DataFormat = DataFormat.Default)]
		public string nametwo
		{
			get
			{
				return this._nametwo ?? "";
			}
			set
			{
				this._nametwo = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nametwoSpecified
		{
			get
			{
				return this._nametwo != null;
			}
			set
			{
				bool flag = value == (this._nametwo == null);
				if (flag)
				{
					this._nametwo = (value ? this.nametwo : null);
				}
			}
		}

		private bool ShouldSerializenametwo()
		{
			return this.nametwoSpecified;
		}

		private void Resetnametwo()
		{
			this.nametwoSpecified = false;
		}

		[ProtoMember(8, IsRequired = false, Name = "iconone", DataFormat = DataFormat.TwosComplement)]
		public uint iconone
		{
			get
			{
				return this._iconone ?? 0U;
			}
			set
			{
				this._iconone = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool icononeSpecified
		{
			get
			{
				return this._iconone != null;
			}
			set
			{
				bool flag = value == (this._iconone == null);
				if (flag)
				{
					this._iconone = (value ? new uint?(this.iconone) : null);
				}
			}
		}

		private bool ShouldSerializeiconone()
		{
			return this.icononeSpecified;
		}

		private void Reseticonone()
		{
			this.icononeSpecified = false;
		}

		[ProtoMember(9, IsRequired = false, Name = "icontwo", DataFormat = DataFormat.TwosComplement)]
		public uint icontwo
		{
			get
			{
				return this._icontwo ?? 0U;
			}
			set
			{
				this._icontwo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool icontwoSpecified
		{
			get
			{
				return this._icontwo != null;
			}
			set
			{
				bool flag = value == (this._icontwo == null);
				if (flag)
				{
					this._icontwo = (value ? new uint?(this.icontwo) : null);
				}
			}
		}

		private bool ShouldSerializeicontwo()
		{
			return this.icontwoSpecified;
		}

		private void Reseticontwo()
		{
			this.icontwoSpecified = false;
		}

		[ProtoMember(10, IsRequired = false, Name = "wartime", DataFormat = DataFormat.TwosComplement)]
		public uint wartime
		{
			get
			{
				return this._wartime ?? 0U;
			}
			set
			{
				this._wartime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool wartimeSpecified
		{
			get
			{
				return this._wartime != null;
			}
			set
			{
				bool flag = value == (this._wartime == null);
				if (flag)
				{
					this._wartime = (value ? new uint?(this.wartime) : null);
				}
			}
		}

		private bool ShouldSerializewartime()
		{
			return this.wartimeSpecified;
		}

		private void Resetwartime()
		{
			this.wartimeSpecified = false;
		}

		[ProtoMember(11, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public IntegralState state
		{
			get
			{
				return this._state ?? IntegralState.integralready;
			}
			set
			{
				this._state = new IntegralState?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new IntegralState?(this.state) : null);
				}
			}
		}

		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _guildone;

		private ulong? _guildtwo;

		private bool? _isdo;

		private uint? _guildonescore;

		private uint? _guildtwoscore;

		private string _nameone;

		private string _nametwo;

		private uint? _iconone;

		private uint? _icontwo;

		private uint? _wartime;

		private IntegralState? _state;

		private IExtension extensionObject;
	}
}
