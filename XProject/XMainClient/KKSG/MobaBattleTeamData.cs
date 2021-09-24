using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleTeamData")]
	[Serializable]
	public class MobaBattleTeamData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "grouplevel", DataFormat = DataFormat.TwosComplement)]
		public uint grouplevel
		{
			get
			{
				return this._grouplevel ?? 0U;
			}
			set
			{
				this._grouplevel = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool grouplevelSpecified
		{
			get
			{
				return this._grouplevel != null;
			}
			set
			{
				bool flag = value == (this._grouplevel == null);
				if (flag)
				{
					this._grouplevel = (value ? new uint?(this.grouplevel) : null);
				}
			}
		}

		private bool ShouldSerializegrouplevel()
		{
			return this.grouplevelSpecified;
		}

		private void Resetgrouplevel()
		{
			this.grouplevelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "headcount", DataFormat = DataFormat.TwosComplement)]
		public uint headcount
		{
			get
			{
				return this._headcount ?? 0U;
			}
			set
			{
				this._headcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool headcountSpecified
		{
			get
			{
				return this._headcount != null;
			}
			set
			{
				bool flag = value == (this._headcount == null);
				if (flag)
				{
					this._headcount = (value ? new uint?(this.headcount) : null);
				}
			}
		}

		private bool ShouldSerializeheadcount()
		{
			return this.headcountSpecified;
		}

		private void Resetheadcount()
		{
			this.headcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _teamid;

		private uint? _grouplevel;

		private uint? _headcount;

		private IExtension extensionObject;
	}
}
