using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005AB RID: 1451
	[ProtoContract(Name = "GroupChatTeamInfo")]
	[Serializable]
	public class GroupChatTeamInfo : IExtensible
	{
		// Token: 0x17001840 RID: 6208
		// (get) Token: 0x06004E9B RID: 20123 RVA: 0x000957E0 File Offset: 0x000939E0
		// (set) Token: 0x06004E9C RID: 20124 RVA: 0x0009580D File Offset: 0x00093A0D
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

		// Token: 0x17001841 RID: 6209
		// (get) Token: 0x06004E9D RID: 20125 RVA: 0x0009581C File Offset: 0x00093A1C
		// (set) Token: 0x06004E9E RID: 20126 RVA: 0x0009583C File Offset: 0x00093A3C
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

		// Token: 0x06004E9F RID: 20127 RVA: 0x00095880 File Offset: 0x00093A80
		private bool ShouldSerializegroupchatID()
		{
			return this.groupchatIDSpecified;
		}

		// Token: 0x06004EA0 RID: 20128 RVA: 0x00095898 File Offset: 0x00093A98
		private void ResetgroupchatID()
		{
			this.groupchatIDSpecified = false;
		}

		// Token: 0x17001842 RID: 6210
		// (get) Token: 0x06004EA1 RID: 20129 RVA: 0x000958A4 File Offset: 0x00093AA4
		// (set) Token: 0x06004EA2 RID: 20130 RVA: 0x000958D1 File Offset: 0x00093AD1
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

		// Token: 0x17001843 RID: 6211
		// (get) Token: 0x06004EA3 RID: 20131 RVA: 0x000958E0 File Offset: 0x00093AE0
		// (set) Token: 0x06004EA4 RID: 20132 RVA: 0x00095900 File Offset: 0x00093B00
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

		// Token: 0x06004EA5 RID: 20133 RVA: 0x00095944 File Offset: 0x00093B44
		private bool ShouldSerializeleaderRoleID()
		{
			return this.leaderRoleIDSpecified;
		}

		// Token: 0x06004EA6 RID: 20134 RVA: 0x0009595C File Offset: 0x00093B5C
		private void ResetleaderRoleID()
		{
			this.leaderRoleIDSpecified = false;
		}

		// Token: 0x17001844 RID: 6212
		// (get) Token: 0x06004EA7 RID: 20135 RVA: 0x00095968 File Offset: 0x00093B68
		// (set) Token: 0x06004EA8 RID: 20136 RVA: 0x00095989 File Offset: 0x00093B89
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

		// Token: 0x17001845 RID: 6213
		// (get) Token: 0x06004EA9 RID: 20137 RVA: 0x00095994 File Offset: 0x00093B94
		// (set) Token: 0x06004EAA RID: 20138 RVA: 0x000959B0 File Offset: 0x00093BB0
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

		// Token: 0x06004EAB RID: 20139 RVA: 0x000959E0 File Offset: 0x00093BE0
		private bool ShouldSerializegroupchatName()
		{
			return this.groupchatNameSpecified;
		}

		// Token: 0x06004EAC RID: 20140 RVA: 0x000959F8 File Offset: 0x00093BF8
		private void ResetgroupchatName()
		{
			this.groupchatNameSpecified = false;
		}

		// Token: 0x17001846 RID: 6214
		// (get) Token: 0x06004EAD RID: 20141 RVA: 0x00095A04 File Offset: 0x00093C04
		// (set) Token: 0x06004EAE RID: 20142 RVA: 0x00095A30 File Offset: 0x00093C30
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

		// Token: 0x17001847 RID: 6215
		// (get) Token: 0x06004EAF RID: 20143 RVA: 0x00095A40 File Offset: 0x00093C40
		// (set) Token: 0x06004EB0 RID: 20144 RVA: 0x00095A60 File Offset: 0x00093C60
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

		// Token: 0x06004EB1 RID: 20145 RVA: 0x00095AA4 File Offset: 0x00093CA4
		private bool ShouldSerializecreatetype()
		{
			return this.createtypeSpecified;
		}

		// Token: 0x06004EB2 RID: 20146 RVA: 0x00095ABC File Offset: 0x00093CBC
		private void Resetcreatetype()
		{
			this.createtypeSpecified = false;
		}

		// Token: 0x17001848 RID: 6216
		// (get) Token: 0x06004EB3 RID: 20147 RVA: 0x00095AC8 File Offset: 0x00093CC8
		// (set) Token: 0x06004EB4 RID: 20148 RVA: 0x00095AF4 File Offset: 0x00093CF4
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

		// Token: 0x17001849 RID: 6217
		// (get) Token: 0x06004EB5 RID: 20149 RVA: 0x00095B04 File Offset: 0x00093D04
		// (set) Token: 0x06004EB6 RID: 20150 RVA: 0x00095B24 File Offset: 0x00093D24
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

		// Token: 0x06004EB7 RID: 20151 RVA: 0x00095B68 File Offset: 0x00093D68
		private bool ShouldSerializerolecount()
		{
			return this.rolecountSpecified;
		}

		// Token: 0x06004EB8 RID: 20152 RVA: 0x00095B80 File Offset: 0x00093D80
		private void Resetrolecount()
		{
			this.rolecountSpecified = false;
		}

		// Token: 0x1700184A RID: 6218
		// (get) Token: 0x06004EB9 RID: 20153 RVA: 0x00095B8C File Offset: 0x00093D8C
		// (set) Token: 0x06004EBA RID: 20154 RVA: 0x00095BB8 File Offset: 0x00093DB8
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

		// Token: 0x1700184B RID: 6219
		// (get) Token: 0x06004EBB RID: 20155 RVA: 0x00095BC8 File Offset: 0x00093DC8
		// (set) Token: 0x06004EBC RID: 20156 RVA: 0x00095BE8 File Offset: 0x00093DE8
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

		// Token: 0x06004EBD RID: 20157 RVA: 0x00095C2C File Offset: 0x00093E2C
		private bool ShouldSerializegroupcreatetime()
		{
			return this.groupcreatetimeSpecified;
		}

		// Token: 0x06004EBE RID: 20158 RVA: 0x00095C44 File Offset: 0x00093E44
		private void Resetgroupcreatetime()
		{
			this.groupcreatetimeSpecified = false;
		}

		// Token: 0x06004EBF RID: 20159 RVA: 0x00095C50 File Offset: 0x00093E50
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001370 RID: 4976
		private ulong? _groupchatID;

		// Token: 0x04001371 RID: 4977
		private ulong? _leaderRoleID;

		// Token: 0x04001372 RID: 4978
		private string _groupchatName;

		// Token: 0x04001373 RID: 4979
		private uint? _createtype;

		// Token: 0x04001374 RID: 4980
		private uint? _rolecount;

		// Token: 0x04001375 RID: 4981
		private uint? _groupcreatetime;

		// Token: 0x04001376 RID: 4982
		private IExtension extensionObject;
	}
}
