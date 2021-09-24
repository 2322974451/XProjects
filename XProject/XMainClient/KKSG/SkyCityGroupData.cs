using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityGroupData")]
	[Serializable]
	public class SkyCityGroupData : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "totaldamage", DataFormat = DataFormat.TwosComplement)]
		public double totaldamage
		{
			get
			{
				return this._totaldamage ?? 0.0;
			}
			set
			{
				this._totaldamage = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totaldamageSpecified
		{
			get
			{
				return this._totaldamage != null;
			}
			set
			{
				bool flag = value == (this._totaldamage == null);
				if (flag)
				{
					this._totaldamage = (value ? new double?(this.totaldamage) : null);
				}
			}
		}

		private bool ShouldSerializetotaldamage()
		{
			return this.totaldamageSpecified;
		}

		private void Resettotaldamage()
		{
			this.totaldamageSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _teamid;

		private uint? _killcount;

		private double? _totaldamage;

		private IExtension extensionObject;
	}
}
