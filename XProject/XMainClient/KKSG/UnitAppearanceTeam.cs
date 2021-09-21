using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200057F RID: 1407
	[ProtoContract(Name = "UnitAppearanceTeam")]
	[Serializable]
	public class UnitAppearanceTeam : IExtensible
	{
		// Token: 0x1700166E RID: 5742
		// (get) Token: 0x06004910 RID: 18704 RVA: 0x0008ADD8 File Offset: 0x00088FD8
		// (set) Token: 0x06004911 RID: 18705 RVA: 0x0008AE04 File Offset: 0x00089004
		[ProtoMember(1, IsRequired = false, Name = "teamid", DataFormat = DataFormat.TwosComplement)]
		public uint teamid
		{
			get
			{
				return this._teamid ?? 0U;
			}
			set
			{
				this._teamid = new uint?(value);
			}
		}

		// Token: 0x1700166F RID: 5743
		// (get) Token: 0x06004912 RID: 18706 RVA: 0x0008AE14 File Offset: 0x00089014
		// (set) Token: 0x06004913 RID: 18707 RVA: 0x0008AE34 File Offset: 0x00089034
		[XmlIgnore]
		[Browsable(false)]
		public bool teamidSpecified
		{
			get
			{
				return this._teamid != null;
			}
			set
			{
				bool flag = value == (this._teamid == null);
				if (flag)
				{
					this._teamid = (value ? new uint?(this.teamid) : null);
				}
			}
		}

		// Token: 0x06004914 RID: 18708 RVA: 0x0008AE78 File Offset: 0x00089078
		private bool ShouldSerializeteamid()
		{
			return this.teamidSpecified;
		}

		// Token: 0x06004915 RID: 18709 RVA: 0x0008AE90 File Offset: 0x00089090
		private void Resetteamid()
		{
			this.teamidSpecified = false;
		}

		// Token: 0x17001670 RID: 5744
		// (get) Token: 0x06004916 RID: 18710 RVA: 0x0008AE9C File Offset: 0x0008909C
		// (set) Token: 0x06004917 RID: 18711 RVA: 0x0008AEC8 File Offset: 0x000890C8
		[ProtoMember(2, IsRequired = false, Name = "haspassword", DataFormat = DataFormat.Default)]
		public bool haspassword
		{
			get
			{
				return this._haspassword ?? false;
			}
			set
			{
				this._haspassword = new bool?(value);
			}
		}

		// Token: 0x17001671 RID: 5745
		// (get) Token: 0x06004918 RID: 18712 RVA: 0x0008AED8 File Offset: 0x000890D8
		// (set) Token: 0x06004919 RID: 18713 RVA: 0x0008AEF8 File Offset: 0x000890F8
		[XmlIgnore]
		[Browsable(false)]
		public bool haspasswordSpecified
		{
			get
			{
				return this._haspassword != null;
			}
			set
			{
				bool flag = value == (this._haspassword == null);
				if (flag)
				{
					this._haspassword = (value ? new bool?(this.haspassword) : null);
				}
			}
		}

		// Token: 0x0600491A RID: 18714 RVA: 0x0008AF3C File Offset: 0x0008913C
		private bool ShouldSerializehaspassword()
		{
			return this.haspasswordSpecified;
		}

		// Token: 0x0600491B RID: 18715 RVA: 0x0008AF54 File Offset: 0x00089154
		private void Resethaspassword()
		{
			this.haspasswordSpecified = false;
		}

		// Token: 0x0600491C RID: 18716 RVA: 0x0008AF60 File Offset: 0x00089160
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001243 RID: 4675
		private uint? _teamid;

		// Token: 0x04001244 RID: 4676
		private bool? _haspassword;

		// Token: 0x04001245 RID: 4677
		private IExtension extensionObject;
	}
}
