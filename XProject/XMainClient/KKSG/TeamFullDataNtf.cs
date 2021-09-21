using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000F6 RID: 246
	[ProtoContract(Name = "TeamFullDataNtf")]
	[Serializable]
	public class TeamFullDataNtf : IExtensible
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x00020660 File Offset: 0x0001E860
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x0002068C File Offset: 0x0001E88C
		[ProtoMember(1, IsRequired = false, Name = "hasTeam", DataFormat = DataFormat.Default)]
		public bool hasTeam
		{
			get
			{
				return this._hasTeam ?? false;
			}
			set
			{
				this._hasTeam = new bool?(value);
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x0002069C File Offset: 0x0001E89C
		// (set) Token: 0x06000FC1 RID: 4033 RVA: 0x000206BC File Offset: 0x0001E8BC
		[XmlIgnore]
		[Browsable(false)]
		public bool hasTeamSpecified
		{
			get
			{
				return this._hasTeam != null;
			}
			set
			{
				bool flag = value == (this._hasTeam == null);
				if (flag)
				{
					this._hasTeam = (value ? new bool?(this.hasTeam) : null);
				}
			}
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00020700 File Offset: 0x0001E900
		private bool ShouldSerializehasTeam()
		{
			return this.hasTeamSpecified;
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00020718 File Offset: 0x0001E918
		private void ResethasTeam()
		{
			this.hasTeamSpecified = false;
		}

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00020724 File Offset: 0x0001E924
		// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x0002073C File Offset: 0x0001E93C
		[ProtoMember(2, IsRequired = false, Name = "teamBrief", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public TeamBrief teamBrief
		{
			get
			{
				return this._teamBrief;
			}
			set
			{
				this._teamBrief = value;
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x00020748 File Offset: 0x0001E948
		[ProtoMember(3, Name = "members", DataFormat = DataFormat.Default)]
		public List<TeamMember> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x00020760 File Offset: 0x0001E960
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003EE RID: 1006
		private bool? _hasTeam;

		// Token: 0x040003EF RID: 1007
		private TeamBrief _teamBrief = null;

		// Token: 0x040003F0 RID: 1008
		private readonly List<TeamMember> _members = new List<TeamMember>();

		// Token: 0x040003F1 RID: 1009
		private IExtension extensionObject;
	}
}
