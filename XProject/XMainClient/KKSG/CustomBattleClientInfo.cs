using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "CustomBattleClientInfo")]
	[Serializable]
	public class CustomBattleClientInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "queryinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleQueryInfo queryinfo
		{
			get
			{
				return this._queryinfo;
			}
			set
			{
				this._queryinfo = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "createinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleDataRole createinfo
		{
			get
			{
				return this._createinfo;
			}
			set
			{
				this._createinfo = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "joininfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public CustomBattleDataRole joininfo
		{
			get
			{
				return this._joininfo;
			}
			set
			{
				this._joininfo = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, Name = "searchinfo", DataFormat = DataFormat.Default)]
		public List<CustomBattleDataRole> searchinfo
		{
			get
			{
				return this._searchinfo;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private CustomBattleQueryInfo _queryinfo = null;

		private CustomBattleDataRole _createinfo = null;

		private CustomBattleDataRole _joininfo = null;

		private uint? _rank;

		private readonly List<CustomBattleDataRole> _searchinfo = new List<CustomBattleDataRole>();

		private IExtension extensionObject;
	}
}
