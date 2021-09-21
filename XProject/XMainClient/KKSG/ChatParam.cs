using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A2 RID: 1442
	[ProtoContract(Name = "ChatParam")]
	[Serializable]
	public class ChatParam : IExtensible
	{
		// Token: 0x17001818 RID: 6168
		// (get) Token: 0x06004E1C RID: 19996 RVA: 0x00094A8C File Offset: 0x00092C8C
		// (set) Token: 0x06004E1D RID: 19997 RVA: 0x00094AA4 File Offset: 0x00092CA4
		[ProtoMember(1, IsRequired = false, Name = "role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamRole role
		{
			get
			{
				return this._role;
			}
			set
			{
				this._role = value;
			}
		}

		// Token: 0x17001819 RID: 6169
		// (get) Token: 0x06004E1E RID: 19998 RVA: 0x00094AB0 File Offset: 0x00092CB0
		// (set) Token: 0x06004E1F RID: 19999 RVA: 0x00094AC8 File Offset: 0x00092CC8
		[ProtoMember(2, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamItem item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		// Token: 0x1700181A RID: 6170
		// (get) Token: 0x06004E20 RID: 20000 RVA: 0x00094AD4 File Offset: 0x00092CD4
		// (set) Token: 0x06004E21 RID: 20001 RVA: 0x00094AEC File Offset: 0x00092CEC
		[ProtoMember(3, IsRequired = false, Name = "num", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamNum num
		{
			get
			{
				return this._num;
			}
			set
			{
				this._num = value;
			}
		}

		// Token: 0x1700181B RID: 6171
		// (get) Token: 0x06004E22 RID: 20002 RVA: 0x00094AF8 File Offset: 0x00092CF8
		// (set) Token: 0x06004E23 RID: 20003 RVA: 0x00094B10 File Offset: 0x00092D10
		[ProtoMember(4, IsRequired = false, Name = "guild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamGuild guild
		{
			get
			{
				return this._guild;
			}
			set
			{
				this._guild = value;
			}
		}

		// Token: 0x1700181C RID: 6172
		// (get) Token: 0x06004E24 RID: 20004 RVA: 0x00094B1C File Offset: 0x00092D1C
		// (set) Token: 0x06004E25 RID: 20005 RVA: 0x00094B34 File Offset: 0x00092D34
		[ProtoMember(5, IsRequired = false, Name = "team", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamTeam team
		{
			get
			{
				return this._team;
			}
			set
			{
				this._team = value;
			}
		}

		// Token: 0x1700181D RID: 6173
		// (get) Token: 0x06004E26 RID: 20006 RVA: 0x00094B40 File Offset: 0x00092D40
		// (set) Token: 0x06004E27 RID: 20007 RVA: 0x00094B58 File Offset: 0x00092D58
		[ProtoMember(6, IsRequired = false, Name = "link", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamLink link
		{
			get
			{
				return this._link;
			}
			set
			{
				this._link = value;
			}
		}

		// Token: 0x1700181E RID: 6174
		// (get) Token: 0x06004E28 RID: 20008 RVA: 0x00094B64 File Offset: 0x00092D64
		// (set) Token: 0x06004E29 RID: 20009 RVA: 0x00094B7C File Offset: 0x00092D7C
		[ProtoMember(7, IsRequired = false, Name = "spectate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamSpectate spectate
		{
			get
			{
				return this._spectate;
			}
			set
			{
				this._spectate = value;
			}
		}

		// Token: 0x1700181F RID: 6175
		// (get) Token: 0x06004E2A RID: 20010 RVA: 0x00094B88 File Offset: 0x00092D88
		// (set) Token: 0x06004E2B RID: 20011 RVA: 0x00094BA0 File Offset: 0x00092DA0
		[ProtoMember(8, IsRequired = false, Name = "dragonguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamDragonGuild dragonguild
		{
			get
			{
				return this._dragonguild;
			}
			set
			{
				this._dragonguild = value;
			}
		}

		// Token: 0x06004E2C RID: 20012 RVA: 0x00094BAC File Offset: 0x00092DAC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400134E RID: 4942
		private ChatParamRole _role = null;

		// Token: 0x0400134F RID: 4943
		private ChatParamItem _item = null;

		// Token: 0x04001350 RID: 4944
		private ChatParamNum _num = null;

		// Token: 0x04001351 RID: 4945
		private ChatParamGuild _guild = null;

		// Token: 0x04001352 RID: 4946
		private ChatParamTeam _team = null;

		// Token: 0x04001353 RID: 4947
		private ChatParamLink _link = null;

		// Token: 0x04001354 RID: 4948
		private ChatParamSpectate _spectate = null;

		// Token: 0x04001355 RID: 4949
		private ChatParamDragonGuild _dragonguild = null;

		// Token: 0x04001356 RID: 4950
		private IExtension extensionObject;
	}
}
