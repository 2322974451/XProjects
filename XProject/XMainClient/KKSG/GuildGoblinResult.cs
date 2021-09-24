using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildGoblinResult")]
	[Serializable]
	public class GuildGoblinResult : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "getGuildBonus", DataFormat = DataFormat.Default)]
		public bool getGuildBonus
		{
			get
			{
				return this._getGuildBonus ?? false;
			}
			set
			{
				this._getGuildBonus = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getGuildBonusSpecified
		{
			get
			{
				return this._getGuildBonus != null;
			}
			set
			{
				bool flag = value == (this._getGuildBonus == null);
				if (flag)
				{
					this._getGuildBonus = (value ? new bool?(this.getGuildBonus) : null);
				}
			}
		}

		private bool ShouldSerializegetGuildBonus()
		{
			return this.getGuildBonusSpecified;
		}

		private void ResetgetGuildBonus()
		{
			this.getGuildBonusSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "curRank", DataFormat = DataFormat.TwosComplement)]
		public int curRank
		{
			get
			{
				return this._curRank ?? 0;
			}
			set
			{
				this._curRank = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curRankSpecified
		{
			get
			{
				return this._curRank != null;
			}
			set
			{
				bool flag = value == (this._curRank == null);
				if (flag)
				{
					this._curRank = (value ? new int?(this.curRank) : null);
				}
			}
		}

		private bool ShouldSerializecurRank()
		{
			return this.curRankSpecified;
		}

		private void ResetcurRank()
		{
			this.curRankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _getGuildBonus;

		private int? _curRank;

		private IExtension extensionObject;
	}
}
