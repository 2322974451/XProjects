using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PetSysData")]
	[Serializable]
	public class PetSysData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "fightid", DataFormat = DataFormat.TwosComplement)]
		public ulong fightid
		{
			get
			{
				return this._fightid ?? 0UL;
			}
			set
			{
				this._fightid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool fightidSpecified
		{
			get
			{
				return this._fightid != null;
			}
			set
			{
				bool flag = value == (this._fightid == null);
				if (flag)
				{
					this._fightid = (value ? new ulong?(this.fightid) : null);
				}
			}
		}

		private bool ShouldSerializefightid()
		{
			return this.fightidSpecified;
		}

		private void Resetfightid()
		{
			this.fightidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "followid", DataFormat = DataFormat.TwosComplement)]
		public ulong followid
		{
			get
			{
				return this._followid ?? 0UL;
			}
			set
			{
				this._followid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool followidSpecified
		{
			get
			{
				return this._followid != null;
			}
			set
			{
				bool flag = value == (this._followid == null);
				if (flag)
				{
					this._followid = (value ? new ulong?(this.followid) : null);
				}
			}
		}

		private bool ShouldSerializefollowid()
		{
			return this.followidSpecified;
		}

		private void Resetfollowid()
		{
			this.followidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "petseats", DataFormat = DataFormat.TwosComplement)]
		public uint petseats
		{
			get
			{
				return this._petseats ?? 0U;
			}
			set
			{
				this._petseats = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool petseatsSpecified
		{
			get
			{
				return this._petseats != null;
			}
			set
			{
				bool flag = value == (this._petseats == null);
				if (flag)
				{
					this._petseats = (value ? new uint?(this.petseats) : null);
				}
			}
		}

		private bool ShouldSerializepetseats()
		{
			return this.petseatsSpecified;
		}

		private void Resetpetseats()
		{
			this.petseatsSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "lastfollowid", DataFormat = DataFormat.TwosComplement)]
		public ulong lastfollowid
		{
			get
			{
				return this._lastfollowid ?? 0UL;
			}
			set
			{
				this._lastfollowid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastfollowidSpecified
		{
			get
			{
				return this._lastfollowid != null;
			}
			set
			{
				bool flag = value == (this._lastfollowid == null);
				if (flag)
				{
					this._lastfollowid = (value ? new ulong?(this.lastfollowid) : null);
				}
			}
		}

		private bool ShouldSerializelastfollowid()
		{
			return this.lastfollowidSpecified;
		}

		private void Resetlastfollowid()
		{
			this.lastfollowidSpecified = false;
		}

		[ProtoMember(5, Name = "pets", DataFormat = DataFormat.Default)]
		public List<PetSingle> pets
		{
			get
			{
				return this._pets;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _fightid;

		private ulong? _followid;

		private uint? _petseats;

		private ulong? _lastfollowid;

		private readonly List<PetSingle> _pets = new List<PetSingle>();

		private IExtension extensionObject;
	}
}
