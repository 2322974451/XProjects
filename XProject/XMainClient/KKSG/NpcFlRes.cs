using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004F1 RID: 1265
	[ProtoContract(Name = "NpcFlRes")]
	[Serializable]
	public class NpcFlRes : IExtensible
	{
		// Token: 0x170013FB RID: 5115
		// (get) Token: 0x06004150 RID: 16720 RVA: 0x0007C5D4 File Offset: 0x0007A7D4
		// (set) Token: 0x06004151 RID: 16721 RVA: 0x0007C600 File Offset: 0x0007A800
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x170013FC RID: 5116
		// (get) Token: 0x06004152 RID: 16722 RVA: 0x0007C610 File Offset: 0x0007A810
		// (set) Token: 0x06004153 RID: 16723 RVA: 0x0007C630 File Offset: 0x0007A830
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06004154 RID: 16724 RVA: 0x0007C674 File Offset: 0x0007A874
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06004155 RID: 16725 RVA: 0x0007C68C File Offset: 0x0007A88C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x170013FD RID: 5117
		// (get) Token: 0x06004156 RID: 16726 RVA: 0x0007C698 File Offset: 0x0007A898
		[ProtoMember(2, Name = "npclist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingOneNpc> npclist
		{
			get
			{
				return this._npclist;
			}
		}

		// Token: 0x170013FE RID: 5118
		// (get) Token: 0x06004157 RID: 16727 RVA: 0x0007C6B0 File Offset: 0x0007A8B0
		[ProtoMember(3, Name = "unitelist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingUnite> unitelist
		{
			get
			{
				return this._unitelist;
			}
		}

		// Token: 0x170013FF RID: 5119
		// (get) Token: 0x06004158 RID: 16728 RVA: 0x0007C6C8 File Offset: 0x0007A8C8
		// (set) Token: 0x06004159 RID: 16729 RVA: 0x0007C6F4 File Offset: 0x0007A8F4
		[ProtoMember(4, IsRequired = false, Name = "giveleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint giveleftcount
		{
			get
			{
				return this._giveleftcount ?? 0U;
			}
			set
			{
				this._giveleftcount = new uint?(value);
			}
		}

		// Token: 0x17001400 RID: 5120
		// (get) Token: 0x0600415A RID: 16730 RVA: 0x0007C704 File Offset: 0x0007A904
		// (set) Token: 0x0600415B RID: 16731 RVA: 0x0007C724 File Offset: 0x0007A924
		[XmlIgnore]
		[Browsable(false)]
		public bool giveleftcountSpecified
		{
			get
			{
				return this._giveleftcount != null;
			}
			set
			{
				bool flag = value == (this._giveleftcount == null);
				if (flag)
				{
					this._giveleftcount = (value ? new uint?(this.giveleftcount) : null);
				}
			}
		}

		// Token: 0x0600415C RID: 16732 RVA: 0x0007C768 File Offset: 0x0007A968
		private bool ShouldSerializegiveleftcount()
		{
			return this.giveleftcountSpecified;
		}

		// Token: 0x0600415D RID: 16733 RVA: 0x0007C780 File Offset: 0x0007A980
		private void Resetgiveleftcount()
		{
			this.giveleftcountSpecified = false;
		}

		// Token: 0x17001401 RID: 5121
		// (get) Token: 0x0600415E RID: 16734 RVA: 0x0007C78C File Offset: 0x0007A98C
		// (set) Token: 0x0600415F RID: 16735 RVA: 0x0007C7B8 File Offset: 0x0007A9B8
		[ProtoMember(5, IsRequired = false, Name = "buyleftcount", DataFormat = DataFormat.TwosComplement)]
		public uint buyleftcount
		{
			get
			{
				return this._buyleftcount ?? 0U;
			}
			set
			{
				this._buyleftcount = new uint?(value);
			}
		}

		// Token: 0x17001402 RID: 5122
		// (get) Token: 0x06004160 RID: 16736 RVA: 0x0007C7C8 File Offset: 0x0007A9C8
		// (set) Token: 0x06004161 RID: 16737 RVA: 0x0007C7E8 File Offset: 0x0007A9E8
		[XmlIgnore]
		[Browsable(false)]
		public bool buyleftcountSpecified
		{
			get
			{
				return this._buyleftcount != null;
			}
			set
			{
				bool flag = value == (this._buyleftcount == null);
				if (flag)
				{
					this._buyleftcount = (value ? new uint?(this.buyleftcount) : null);
				}
			}
		}

		// Token: 0x06004162 RID: 16738 RVA: 0x0007C82C File Offset: 0x0007AA2C
		private bool ShouldSerializebuyleftcount()
		{
			return this.buyleftcountSpecified;
		}

		// Token: 0x06004163 RID: 16739 RVA: 0x0007C844 File Offset: 0x0007AA44
		private void Resetbuyleftcount()
		{
			this.buyleftcountSpecified = false;
		}

		// Token: 0x17001403 RID: 5123
		// (get) Token: 0x06004164 RID: 16740 RVA: 0x0007C850 File Offset: 0x0007AA50
		// (set) Token: 0x06004165 RID: 16741 RVA: 0x0007C87C File Offset: 0x0007AA7C
		[ProtoMember(6, IsRequired = false, Name = "buycost", DataFormat = DataFormat.TwosComplement)]
		public uint buycost
		{
			get
			{
				return this._buycost ?? 0U;
			}
			set
			{
				this._buycost = new uint?(value);
			}
		}

		// Token: 0x17001404 RID: 5124
		// (get) Token: 0x06004166 RID: 16742 RVA: 0x0007C88C File Offset: 0x0007AA8C
		// (set) Token: 0x06004167 RID: 16743 RVA: 0x0007C8AC File Offset: 0x0007AAAC
		[XmlIgnore]
		[Browsable(false)]
		public bool buycostSpecified
		{
			get
			{
				return this._buycost != null;
			}
			set
			{
				bool flag = value == (this._buycost == null);
				if (flag)
				{
					this._buycost = (value ? new uint?(this.buycost) : null);
				}
			}
		}

		// Token: 0x06004168 RID: 16744 RVA: 0x0007C8F0 File Offset: 0x0007AAF0
		private bool ShouldSerializebuycost()
		{
			return this.buycostSpecified;
		}

		// Token: 0x06004169 RID: 16745 RVA: 0x0007C908 File Offset: 0x0007AB08
		private void Resetbuycost()
		{
			this.buycostSpecified = false;
		}

		// Token: 0x17001405 RID: 5125
		// (get) Token: 0x0600416A RID: 16746 RVA: 0x0007C914 File Offset: 0x0007AB14
		[ProtoMember(7, Name = "npcfavorrole", DataFormat = DataFormat.Default)]
		public List<NpcFlNpc2Role> npcfavorrole
		{
			get
			{
				return this._npcfavorrole;
			}
		}

		// Token: 0x17001406 RID: 5126
		// (get) Token: 0x0600416B RID: 16747 RVA: 0x0007C92C File Offset: 0x0007AB2C
		[ProtoMember(8, Name = "changenpclist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingOneNpc> changenpclist
		{
			get
			{
				return this._changenpclist;
			}
		}

		// Token: 0x17001407 RID: 5127
		// (get) Token: 0x0600416C RID: 16748 RVA: 0x0007C944 File Offset: 0x0007AB44
		[ProtoMember(9, Name = "changeunitelist", DataFormat = DataFormat.Default)]
		public List<NpcFeelingUnite> changeunitelist
		{
			get
			{
				return this._changeunitelist;
			}
		}

		// Token: 0x17001408 RID: 5128
		// (get) Token: 0x0600416D RID: 16749 RVA: 0x0007C95C File Offset: 0x0007AB5C
		// (set) Token: 0x0600416E RID: 16750 RVA: 0x0007C974 File Offset: 0x0007AB74
		[ProtoMember(10, IsRequired = false, Name = "role2npc", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief role2npc
		{
			get
			{
				return this._role2npc;
			}
			set
			{
				this._role2npc = value;
			}
		}

		// Token: 0x17001409 RID: 5129
		// (get) Token: 0x0600416F RID: 16751 RVA: 0x0007C980 File Offset: 0x0007AB80
		// (set) Token: 0x06004170 RID: 16752 RVA: 0x0007C998 File Offset: 0x0007AB98
		[ProtoMember(11, IsRequired = false, Name = "npc2role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ItemBrief npc2role
		{
			get
			{
				return this._npc2role;
			}
			set
			{
				this._npc2role = value;
			}
		}

		// Token: 0x1700140A RID: 5130
		// (get) Token: 0x06004171 RID: 16753 RVA: 0x0007C9A4 File Offset: 0x0007ABA4
		// (set) Token: 0x06004172 RID: 16754 RVA: 0x0007C9D0 File Offset: 0x0007ABD0
		[ProtoMember(12, IsRequired = false, Name = "npcflleveltop", DataFormat = DataFormat.TwosComplement)]
		public uint npcflleveltop
		{
			get
			{
				return this._npcflleveltop ?? 0U;
			}
			set
			{
				this._npcflleveltop = new uint?(value);
			}
		}

		// Token: 0x1700140B RID: 5131
		// (get) Token: 0x06004173 RID: 16755 RVA: 0x0007C9E0 File Offset: 0x0007ABE0
		// (set) Token: 0x06004174 RID: 16756 RVA: 0x0007CA00 File Offset: 0x0007AC00
		[XmlIgnore]
		[Browsable(false)]
		public bool npcflleveltopSpecified
		{
			get
			{
				return this._npcflleveltop != null;
			}
			set
			{
				bool flag = value == (this._npcflleveltop == null);
				if (flag)
				{
					this._npcflleveltop = (value ? new uint?(this.npcflleveltop) : null);
				}
			}
		}

		// Token: 0x06004175 RID: 16757 RVA: 0x0007CA44 File Offset: 0x0007AC44
		private bool ShouldSerializenpcflleveltop()
		{
			return this.npcflleveltopSpecified;
		}

		// Token: 0x06004176 RID: 16758 RVA: 0x0007CA5C File Offset: 0x0007AC5C
		private void Resetnpcflleveltop()
		{
			this.npcflleveltopSpecified = false;
		}

		// Token: 0x06004177 RID: 16759 RVA: 0x0007CA68 File Offset: 0x0007AC68
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001047 RID: 4167
		private ErrorCode? _errorcode;

		// Token: 0x04001048 RID: 4168
		private readonly List<NpcFeelingOneNpc> _npclist = new List<NpcFeelingOneNpc>();

		// Token: 0x04001049 RID: 4169
		private readonly List<NpcFeelingUnite> _unitelist = new List<NpcFeelingUnite>();

		// Token: 0x0400104A RID: 4170
		private uint? _giveleftcount;

		// Token: 0x0400104B RID: 4171
		private uint? _buyleftcount;

		// Token: 0x0400104C RID: 4172
		private uint? _buycost;

		// Token: 0x0400104D RID: 4173
		private readonly List<NpcFlNpc2Role> _npcfavorrole = new List<NpcFlNpc2Role>();

		// Token: 0x0400104E RID: 4174
		private readonly List<NpcFeelingOneNpc> _changenpclist = new List<NpcFeelingOneNpc>();

		// Token: 0x0400104F RID: 4175
		private readonly List<NpcFeelingUnite> _changeunitelist = new List<NpcFeelingUnite>();

		// Token: 0x04001050 RID: 4176
		private ItemBrief _role2npc = null;

		// Token: 0x04001051 RID: 4177
		private ItemBrief _npc2role = null;

		// Token: 0x04001052 RID: 4178
		private uint? _npcflleveltop;

		// Token: 0x04001053 RID: 4179
		private IExtension extensionObject;
	}
}
