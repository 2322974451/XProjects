using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarFinal")]
	[Serializable]
	public class ResWarFinal : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "guildname", DataFormat = DataFormat.Default)]
		public string guildname
		{
			get
			{
				return this._guildname ?? "";
			}
			set
			{
				this._guildname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildnameSpecified
		{
			get
			{
				return this._guildname != null;
			}
			set
			{
				bool flag = value == (this._guildname == null);
				if (flag)
				{
					this._guildname = (value ? this.guildname : null);
				}
			}
		}

		private bool ShouldSerializeguildname()
		{
			return this.guildnameSpecified;
		}

		private void Resetguildname()
		{
			this.guildnameSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "res", DataFormat = DataFormat.TwosComplement)]
		public uint res
		{
			get
			{
				return this._res ?? 0U;
			}
			set
			{
				this._res = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resSpecified
		{
			get
			{
				return this._res != null;
			}
			set
			{
				bool flag = value == (this._res == null);
				if (flag)
				{
					this._res = (value ? new uint?(this.res) : null);
				}
			}
		}

		private bool ShouldSerializeres()
		{
			return this.resSpecified;
		}

		private void Resetres()
		{
			this.resSpecified = false;
		}

		[ProtoMember(3, Name = "brief", DataFormat = DataFormat.Default)]
		public List<ItemBrief> brief
		{
			get
			{
				return this._brief;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "guildicon", DataFormat = DataFormat.TwosComplement)]
		public uint guildicon
		{
			get
			{
				return this._guildicon ?? 0U;
			}
			set
			{
				this._guildicon = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildiconSpecified
		{
			get
			{
				return this._guildicon != null;
			}
			set
			{
				bool flag = value == (this._guildicon == null);
				if (flag)
				{
					this._guildicon = (value ? new uint?(this.guildicon) : null);
				}
			}
		}

		private bool ShouldSerializeguildicon()
		{
			return this.guildiconSpecified;
		}

		private void Resetguildicon()
		{
			this.guildiconSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "guildid", DataFormat = DataFormat.TwosComplement)]
		public ulong guildid
		{
			get
			{
				return this._guildid ?? 0UL;
			}
			set
			{
				this._guildid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool guildidSpecified
		{
			get
			{
				return this._guildid != null;
			}
			set
			{
				bool flag = value == (this._guildid == null);
				if (flag)
				{
					this._guildid = (value ? new ulong?(this.guildid) : null);
				}
			}
		}

		private bool ShouldSerializeguildid()
		{
			return this.guildidSpecified;
		}

		private void Resetguildid()
		{
			this.guildidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _guildname;

		private uint? _res;

		private readonly List<ItemBrief> _brief = new List<ItemBrief>();

		private uint? _guildicon;

		private ulong? _guildid;

		private IExtension extensionObject;
	}
}
