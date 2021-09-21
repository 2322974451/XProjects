using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000061 RID: 97
	[ProtoContract(Name = "TeamChanged")]
	[Serializable]
	public class TeamChanged : IExtensible
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x0000F540 File Offset: 0x0000D740
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x0000F558 File Offset: 0x0000D758
		[ProtoMember(1, IsRequired = false, Name = "teamBrief", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0000F564 File Offset: 0x0000D764
		[ProtoMember(2, Name = "leaveMember", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> leaveMember
		{
			get
			{
				return this._leaveMember;
			}
		}

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x0600069C RID: 1692 RVA: 0x0000F57C File Offset: 0x0000D77C
		[ProtoMember(3, Name = "addMember", DataFormat = DataFormat.Default)]
		public List<TeamMember> addMember
		{
			get
			{
				return this._addMember;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0000F594 File Offset: 0x0000D794
		[ProtoMember(4, Name = "chgstateMember", DataFormat = DataFormat.Default)]
		public List<TeamMember> chgstateMember
		{
			get
			{
				return this._chgstateMember;
			}
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0000F5AC File Offset: 0x0000D7AC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040001A9 RID: 425
		private TeamBrief _teamBrief = null;

		// Token: 0x040001AA RID: 426
		private readonly List<ulong> _leaveMember = new List<ulong>();

		// Token: 0x040001AB RID: 427
		private readonly List<TeamMember> _addMember = new List<TeamMember>();

		// Token: 0x040001AC RID: 428
		private readonly List<TeamMember> _chgstateMember = new List<TeamMember>();

		// Token: 0x040001AD RID: 429
		private IExtension extensionObject;
	}
}
