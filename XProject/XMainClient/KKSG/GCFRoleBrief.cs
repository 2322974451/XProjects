using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFRoleBrief")]
	[Serializable]
	public class GCFRoleBrief : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(5, IsRequired = false, Name = "occupycount", DataFormat = DataFormat.TwosComplement)]
		public uint occupycount
		{
			get
			{
				return this._occupycount ?? 0U;
			}
			set
			{
				this._occupycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool occupycountSpecified
		{
			get
			{
				return this._occupycount != null;
			}
			set
			{
				bool flag = value == (this._occupycount == null);
				if (flag)
				{
					this._occupycount = (value ? new uint?(this.occupycount) : null);
				}
			}
		}

		private bool ShouldSerializeoccupycount()
		{
			return this.occupycountSpecified;
		}

		private void Resetoccupycount()
		{
			this.occupycountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "feats", DataFormat = DataFormat.TwosComplement)]
		public uint feats
		{
			get
			{
				return this._feats ?? 0U;
			}
			set
			{
				this._feats = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool featsSpecified
		{
			get
			{
				return this._feats != null;
			}
			set
			{
				bool flag = value == (this._feats == null);
				if (flag)
				{
					this._feats = (value ? new uint?(this.feats) : null);
				}
			}
		}

		private bool ShouldSerializefeats()
		{
			return this.featsSpecified;
		}

		private void Resetfeats()
		{
			this.featsSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _rank;

		private ulong? _roleID;

		private string _rolename;

		private uint? _killcount;

		private uint? _occupycount;

		private uint? _feats;

		private IExtension extensionObject;
	}
}
