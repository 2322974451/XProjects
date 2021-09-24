using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamExtraInfo")]
	[Serializable]
	public class TeamExtraInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pptlimit", DataFormat = DataFormat.TwosComplement)]
		public uint pptlimit
		{
			get
			{
				return this._pptlimit ?? 0U;
			}
			set
			{
				this._pptlimit = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pptlimitSpecified
		{
			get
			{
				return this._pptlimit != null;
			}
			set
			{
				bool flag = value == (this._pptlimit == null);
				if (flag)
				{
					this._pptlimit = (value ? new uint?(this.pptlimit) : null);
				}
			}
		}

		private bool ShouldSerializepptlimit()
		{
			return this.pptlimitSpecified;
		}

		private void Resetpptlimit()
		{
			this.pptlimitSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "costindex", DataFormat = DataFormat.TwosComplement)]
		public uint costindex
		{
			get
			{
				return this._costindex ?? 0U;
			}
			set
			{
				this._costindex = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool costindexSpecified
		{
			get
			{
				return this._costindex != null;
			}
			set
			{
				bool flag = value == (this._costindex == null);
				if (flag)
				{
					this._costindex = (value ? new uint?(this.costindex) : null);
				}
			}
		}

		private bool ShouldSerializecostindex()
		{
			return this.costindexSpecified;
		}

		private void Resetcostindex()
		{
			this.costindexSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "league_teamname", DataFormat = DataFormat.Default)]
		public string league_teamname
		{
			get
			{
				return this._league_teamname ?? "";
			}
			set
			{
				this._league_teamname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool league_teamnameSpecified
		{
			get
			{
				return this._league_teamname != null;
			}
			set
			{
				bool flag = value == (this._league_teamname == null);
				if (flag)
				{
					this._league_teamname = (value ? this.league_teamname : null);
				}
			}
		}

		private bool ShouldSerializeleague_teamname()
		{
			return this.league_teamnameSpecified;
		}

		private void Resetleague_teamname()
		{
			this.league_teamnameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "rift", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamSynRift rift
		{
			get
			{
				return this._rift;
			}
			set
			{
				this._rift = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _pptlimit;

		private uint? _costindex;

		private string _league_teamname;

		private TeamSynRift _rift = null;

		private IExtension extensionObject;
	}
}
