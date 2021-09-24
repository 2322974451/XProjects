using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "LevelChanged")]
	[Serializable]
	public class LevelChanged : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "exp", DataFormat = DataFormat.TwosComplement)]
		public ulong exp
		{
			get
			{
				return this._exp ?? 0UL;
			}
			set
			{
				this._exp = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expSpecified
		{
			get
			{
				return this._exp != null;
			}
			set
			{
				bool flag = value == (this._exp == null);
				if (flag)
				{
					this._exp = (value ? new ulong?(this.exp) : null);
				}
			}
		}

		private bool ShouldSerializeexp()
		{
			return this.expSpecified;
		}

		private void Resetexp()
		{
			this.expSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "maxexp", DataFormat = DataFormat.TwosComplement)]
		public ulong maxexp
		{
			get
			{
				return this._maxexp ?? 0UL;
			}
			set
			{
				this._maxexp = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool maxexpSpecified
		{
			get
			{
				return this._maxexp != null;
			}
			set
			{
				bool flag = value == (this._maxexp == null);
				if (flag)
				{
					this._maxexp = (value ? new ulong?(this.maxexp) : null);
				}
			}
		}

		private bool ShouldSerializemaxexp()
		{
			return this.maxexpSpecified;
		}

		private void Resetmaxexp()
		{
			this.maxexpSpecified = false;
		}

		[ProtoMember(4, Name = "attrid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attrid
		{
			get
			{
				return this._attrid;
			}
		}

		[ProtoMember(5, Name = "attroldvalue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attroldvalue
		{
			get
			{
				return this._attroldvalue;
			}
		}

		[ProtoMember(6, Name = "attrnewvalue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> attrnewvalue
		{
			get
			{
				return this._attrnewvalue;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _level;

		private ulong? _exp;

		private ulong? _maxexp;

		private readonly List<uint> _attrid = new List<uint>();

		private readonly List<uint> _attroldvalue = new List<uint>();

		private readonly List<uint> _attrnewvalue = new List<uint>();

		private IExtension extensionObject;
	}
}
