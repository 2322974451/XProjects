using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarTopRoleData")]
	[Serializable]
	public class ArenaStarTopRoleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "historydata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ArenaStarHistData historydata
		{
			get
			{
				return this._historydata;
			}
			set
			{
				this._historydata = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public RoleOutLookBrief outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "season", DataFormat = DataFormat.TwosComplement)]
		public uint season
		{
			get
			{
				return this._season ?? 0U;
			}
			set
			{
				this._season = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool seasonSpecified
		{
			get
			{
				return this._season != null;
			}
			set
			{
				bool flag = value == (this._season == null);
				if (flag)
				{
					this._season = (value ? new uint?(this.season) : null);
				}
			}
		}

		private bool ShouldSerializeseason()
		{
			return this.seasonSpecified;
		}

		private void Resetseason()
		{
			this.seasonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ArenaStarHistData _historydata = null;

		private RoleOutLookBrief _outlook = null;

		private uint? _rank;

		private uint? _season;

		private IExtension extensionObject;
	}
}
