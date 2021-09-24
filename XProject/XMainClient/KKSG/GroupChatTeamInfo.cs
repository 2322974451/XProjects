using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GroupChatTeamInfo")]
	[Serializable]
	public class GroupChatTeamInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "groupchatID", DataFormat = DataFormat.TwosComplement)]
		public ulong groupchatID
		{
			get
			{
				return this._groupchatID ?? 0UL;
			}
			set
			{
				this._groupchatID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatIDSpecified
		{
			get
			{
				return this._groupchatID != null;
			}
			set
			{
				bool flag = value == (this._groupchatID == null);
				if (flag)
				{
					this._groupchatID = (value ? new ulong?(this.groupchatID) : null);
				}
			}
		}

		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leaderRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong leaderRoleID
		{
			get
			{
				return this._leaderRoleID ?? 0UL;
			}
			set
			{
				this._leaderRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderRoleIDSpecified
		{
			get
			{
				return this._leaderRoleID != null;
			}
			set
			{
				bool flag = value == (this._leaderRoleID == null);
				if (flag)
				{
					this._leaderRoleID = (value ? new ulong?(this.leaderRoleID) : null);
				}
			}
		}

		private bool ShouldSerializeleaderRoleID()
		{
			return this.leaderRoleIDSpecified;
		}

		private void ResetleaderRoleID()
		{
			this.leaderRoleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "groupchatName", DataFormat = DataFormat.Default)]
		public string groupchatName
		{
			get
			{
				return this._groupchatName ?? "";
			}
			set
			{
				this._groupchatName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupchatNameSpecified
		{
			get
			{
				return this._groupchatName != null;
			}
			set
			{
				bool flag = value == (this._groupchatName == null);
				if (flag)
				{
					this._groupchatName = (value ? this.groupchatName : null);
				}
			}
		}

		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "createtype", DataFormat = DataFormat.TwosComplement)]
		public uint createtype
		{
			get
			{
				return this._createtype ?? 0U;
			}
			set
			{
				this._createtype = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool createtypeSpecified
		{
			get
			{
				return this._createtype != null;
			}
			set
			{
				bool flag = value == (this._createtype == null);
				if (flag)
				{
					this._createtype = (value ? new uint?(this.createtype) : null);
				}
			}
		}

		private bool ShouldSerializecreatetype()
		{
			return this.createtypeSpecified;
		}

		private void Resetcreatetype()
		{
			this.createtypeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "rolecount", DataFormat = DataFormat.TwosComplement)]
		public uint rolecount
		{
			get
			{
				return this._rolecount ?? 0U;
			}
			set
			{
				this._rolecount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool rolecountSpecified
		{
			get
			{
				return this._rolecount != null;
			}
			set
			{
				bool flag = value == (this._rolecount == null);
				if (flag)
				{
					this._rolecount = (value ? new uint?(this.rolecount) : null);
				}
			}
		}

		private bool ShouldSerializerolecount()
		{
			return this.rolecountSpecified;
		}

		private void Resetrolecount()
		{
			this.rolecountSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "groupcreatetime", DataFormat = DataFormat.TwosComplement)]
		public uint groupcreatetime
		{
			get
			{
				return this._groupcreatetime ?? 0U;
			}
			set
			{
				this._groupcreatetime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupcreatetimeSpecified
		{
			get
			{
				return this._groupcreatetime != null;
			}
			set
			{
				bool flag = value == (this._groupcreatetime == null);
				if (flag)
				{
					this._groupcreatetime = (value ? new uint?(this.groupcreatetime) : null);
				}
			}
		}

		private bool ShouldSerializegroupcreatetime()
		{
			return this.groupcreatetimeSpecified;
		}

		private void Resetgroupcreatetime()
		{
			this.groupcreatetimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _groupchatID;

		private ulong? _leaderRoleID;

		private string _groupchatName;

		private uint? _createtype;

		private uint? _rolecount;

		private uint? _groupcreatetime;

		private IExtension extensionObject;
	}
}
