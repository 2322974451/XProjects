using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MobaBattleTeamRoleData")]
	[Serializable]
	public class MobaBattleTeamRoleData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "team1", DataFormat = DataFormat.TwosComplement)]
		public uint team1
		{
			get
			{
				return this._team1 ?? 0U;
			}
			set
			{
				this._team1 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool team1Specified
		{
			get
			{
				return this._team1 != null;
			}
			set
			{
				bool flag = value == (this._team1 == null);
				if (flag)
				{
					this._team1 = (value ? new uint?(this.team1) : null);
				}
			}
		}

		private bool ShouldSerializeteam1()
		{
			return this.team1Specified;
		}

		private void Resetteam1()
		{
			this.team1Specified = false;
		}

		[ProtoMember(2, Name = "datalist1", DataFormat = DataFormat.Default)]
		public List<MobaRoleData> datalist1
		{
			get
			{
				return this._datalist1;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "team2", DataFormat = DataFormat.TwosComplement)]
		public uint team2
		{
			get
			{
				return this._team2 ?? 0U;
			}
			set
			{
				this._team2 = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool team2Specified
		{
			get
			{
				return this._team2 != null;
			}
			set
			{
				bool flag = value == (this._team2 == null);
				if (flag)
				{
					this._team2 = (value ? new uint?(this.team2) : null);
				}
			}
		}

		private bool ShouldSerializeteam2()
		{
			return this.team2Specified;
		}

		private void Resetteam2()
		{
			this.team2Specified = false;
		}

		[ProtoMember(4, Name = "datalist2", DataFormat = DataFormat.Default)]
		public List<MobaRoleData> datalist2
		{
			get
			{
				return this._datalist2;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _team1;

		private readonly List<MobaRoleData> _datalist1 = new List<MobaRoleData>();

		private uint? _team2;

		private readonly List<MobaRoleData> _datalist2 = new List<MobaRoleData>();

		private IExtension extensionObject;
	}
}
