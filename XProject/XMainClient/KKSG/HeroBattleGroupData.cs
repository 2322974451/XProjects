using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroBattleGroupData")]
	[Serializable]
	public class HeroBattleGroupData : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "headcount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(3, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _teamid;

		private uint? _headcount;

		private uint? _point;

		private IExtension extensionObject;
	}
}
