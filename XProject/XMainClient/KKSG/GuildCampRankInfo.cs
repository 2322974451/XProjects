using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampRankInfo")]
	[Serializable]
	public class GuildCampRankInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
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
					this._rank = (value ? new int?(this.rank) : null);
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

		[ProtoMember(2, IsRequired = false, Name = "rankVar", DataFormat = DataFormat.TwosComplement)]
		public int rankVar
		{
			get
			{
				return this._rankVar ?? 0;
			}
			set
			{
				this._rankVar = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rankVarSpecified
		{
			get
			{
				return this._rankVar != null;
			}
			set
			{
				bool flag = value == (this._rankVar == null);
				if (flag)
				{
					this._rankVar = (value ? new int?(this.rankVar) : null);
				}
			}
		}

		private bool ShouldSerializerankVar()
		{
			return this.rankVarSpecified;
		}

		private void ResetrankVar()
		{
			this.rankVarSpecified = false;
		}

		[ProtoMember(3, Name = "roles", DataFormat = DataFormat.Default)]
		public List<RoleBriefInfo> roles
		{
			get
			{
				return this._roles;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _rank;

		private int? _rankVar;

		private readonly List<RoleBriefInfo> _roles = new List<RoleBriefInfo>();

		private IExtension extensionObject;
	}
}
