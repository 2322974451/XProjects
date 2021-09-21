using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006F3 RID: 1779
	[ProtoContract(Name = "LeagueBattleOneRole")]
	[Serializable]
	public class LeagueBattleOneRole : IExtensible
	{
		// Token: 0x170025E0 RID: 9696
		// (get) Token: 0x06007799 RID: 30617 RVA: 0x000E4CB0 File Offset: 0x000E2EB0
		// (set) Token: 0x0600779A RID: 30618 RVA: 0x000E4CC8 File Offset: 0x000E2EC8
		[ProtoMember(1, IsRequired = false, Name = "basedata", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public LeagueBattleRoleBrief basedata
		{
			get
			{
				return this._basedata;
			}
			set
			{
				this._basedata = value;
			}
		}

		// Token: 0x170025E1 RID: 9697
		// (get) Token: 0x0600779B RID: 30619 RVA: 0x000E4CD4 File Offset: 0x000E2ED4
		// (set) Token: 0x0600779C RID: 30620 RVA: 0x000E4D00 File Offset: 0x000E2F00
		[ProtoMember(2, IsRequired = false, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public LeagueBattleRoleState state
		{
			get
			{
				return this._state ?? LeagueBattleRoleState.LBRoleState_None;
			}
			set
			{
				this._state = new LeagueBattleRoleState?(value);
			}
		}

		// Token: 0x170025E2 RID: 9698
		// (get) Token: 0x0600779D RID: 30621 RVA: 0x000E4D10 File Offset: 0x000E2F10
		// (set) Token: 0x0600779E RID: 30622 RVA: 0x000E4D30 File Offset: 0x000E2F30
		[XmlIgnore]
		[Browsable(false)]
		public bool stateSpecified
		{
			get
			{
				return this._state != null;
			}
			set
			{
				bool flag = value == (this._state == null);
				if (flag)
				{
					this._state = (value ? new LeagueBattleRoleState?(this.state) : null);
				}
			}
		}

		// Token: 0x0600779F RID: 30623 RVA: 0x000E4D74 File Offset: 0x000E2F74
		private bool ShouldSerializestate()
		{
			return this.stateSpecified;
		}

		// Token: 0x060077A0 RID: 30624 RVA: 0x000E4D8C File Offset: 0x000E2F8C
		private void Resetstate()
		{
			this.stateSpecified = false;
		}

		// Token: 0x170025E3 RID: 9699
		// (get) Token: 0x060077A1 RID: 30625 RVA: 0x000E4D98 File Offset: 0x000E2F98
		// (set) Token: 0x060077A2 RID: 30626 RVA: 0x000E4DC4 File Offset: 0x000E2FC4
		[ProtoMember(3, IsRequired = false, Name = "index", DataFormat = DataFormat.TwosComplement)]
		public int index
		{
			get
			{
				return this._index ?? 0;
			}
			set
			{
				this._index = new int?(value);
			}
		}

		// Token: 0x170025E4 RID: 9700
		// (get) Token: 0x060077A3 RID: 30627 RVA: 0x000E4DD4 File Offset: 0x000E2FD4
		// (set) Token: 0x060077A4 RID: 30628 RVA: 0x000E4DF4 File Offset: 0x000E2FF4
		[XmlIgnore]
		[Browsable(false)]
		public bool indexSpecified
		{
			get
			{
				return this._index != null;
			}
			set
			{
				bool flag = value == (this._index == null);
				if (flag)
				{
					this._index = (value ? new int?(this.index) : null);
				}
			}
		}

		// Token: 0x060077A5 RID: 30629 RVA: 0x000E4E38 File Offset: 0x000E3038
		private bool ShouldSerializeindex()
		{
			return this.indexSpecified;
		}

		// Token: 0x060077A6 RID: 30630 RVA: 0x000E4E50 File Offset: 0x000E3050
		private void Resetindex()
		{
			this.indexSpecified = false;
		}

		// Token: 0x060077A7 RID: 30631 RVA: 0x000E4E5C File Offset: 0x000E305C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001C4D RID: 7245
		private LeagueBattleRoleBrief _basedata = null;

		// Token: 0x04001C4E RID: 7246
		private LeagueBattleRoleState? _state;

		// Token: 0x04001C4F RID: 7247
		private int? _index;

		// Token: 0x04001C50 RID: 7248
		private IExtension extensionObject;
	}
}
