using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArenaStarHistData")]
	[Serializable]
	public class ArenaStarHistData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rankOneNum", DataFormat = DataFormat.TwosComplement)]
		public uint rankOneNum
		{
			get
			{
				return this._rankOneNum ?? 0U;
			}
			set
			{
				this._rankOneNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankOneNumSpecified
		{
			get
			{
				return this._rankOneNum != null;
			}
			set
			{
				bool flag = value == (this._rankOneNum == null);
				if (flag)
				{
					this._rankOneNum = (value ? new uint?(this.rankOneNum) : null);
				}
			}
		}

		private bool ShouldSerializerankOneNum()
		{
			return this.rankOneNumSpecified;
		}

		private void ResetrankOneNum()
		{
			this.rankOneNumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "rankTenNum", DataFormat = DataFormat.TwosComplement)]
		public uint rankTenNum
		{
			get
			{
				return this._rankTenNum ?? 0U;
			}
			set
			{
				this._rankTenNum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankTenNumSpecified
		{
			get
			{
				return this._rankTenNum != null;
			}
			set
			{
				bool flag = value == (this._rankTenNum == null);
				if (flag)
				{
					this._rankTenNum = (value ? new uint?(this.rankTenNum) : null);
				}
			}
		}

		private bool ShouldSerializerankTenNum()
		{
			return this.rankTenNumSpecified;
		}

		private void ResetrankTenNum()
		{
			this.rankTenNumSpecified = false;
		}

		[ProtoMember(3, Name = "rankRecent", DataFormat = DataFormat.Default)]
		public List<RankOnce> rankRecent
		{
			get
			{
				return this._rankRecent;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _rankOneNum;

		private uint? _rankTenNum;

		private readonly List<RankOnce> _rankRecent = new List<RankOnce>();

		private IExtension extensionObject;
	}
}
