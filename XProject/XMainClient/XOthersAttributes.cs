using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F3C RID: 3900
	internal class XOthersAttributes : XAttributes
	{
		// Token: 0x1700364C RID: 13900
		// (get) Token: 0x0600CF6E RID: 53102 RVA: 0x00302DE4 File Offset: 0x00300FE4
		public override uint ID
		{
			get
			{
				return XOthersAttributes.uuID;
			}
		}

		// Token: 0x0600CF6F RID: 53103 RVA: 0x00302DFB File Offset: 0x00300FFB
		public XOthersAttributes()
		{
			this._security_Statistics = new XSecurityStatistics();
		}

		// Token: 0x1700364D RID: 13901
		// (get) Token: 0x0600CF70 RID: 53104 RVA: 0x00302E10 File Offset: 0x00301010
		// (set) Token: 0x0600CF71 RID: 53105 RVA: 0x00302E18 File Offset: 0x00301018
		public float NormalAttackProb { get; set; }

		// Token: 0x1700364E RID: 13902
		// (get) Token: 0x0600CF72 RID: 53106 RVA: 0x00302E21 File Offset: 0x00301021
		// (set) Token: 0x0600CF73 RID: 53107 RVA: 0x00302E29 File Offset: 0x00301029
		public float EnterFightRange { get; set; }

		// Token: 0x1700364F RID: 13903
		// (get) Token: 0x0600CF74 RID: 53108 RVA: 0x00302E32 File Offset: 0x00301032
		// (set) Token: 0x0600CF75 RID: 53109 RVA: 0x00302E3A File Offset: 0x0030103A
		public float FloatingMax { get; set; }

		// Token: 0x17003650 RID: 13904
		// (get) Token: 0x0600CF76 RID: 53110 RVA: 0x00302E43 File Offset: 0x00301043
		// (set) Token: 0x0600CF77 RID: 53111 RVA: 0x00302E4B File Offset: 0x0030104B
		public float FloatingMin { get; set; }

		// Token: 0x17003651 RID: 13905
		// (get) Token: 0x0600CF78 RID: 53112 RVA: 0x00302E54 File Offset: 0x00301054
		// (set) Token: 0x0600CF79 RID: 53113 RVA: 0x00302E5C File Offset: 0x0030105C
		public float AIStartTime { get; set; }

		// Token: 0x17003652 RID: 13906
		// (get) Token: 0x0600CF7A RID: 53114 RVA: 0x00302E65 File Offset: 0x00301065
		// (set) Token: 0x0600CF7B RID: 53115 RVA: 0x00302E6D File Offset: 0x0030106D
		public float AIActionGap { get; set; }

		// Token: 0x17003653 RID: 13907
		// (get) Token: 0x0600CF7C RID: 53116 RVA: 0x00302E76 File Offset: 0x00301076
		// (set) Token: 0x0600CF7D RID: 53117 RVA: 0x00302E7E File Offset: 0x0030107E
		public bool Blocked { get; set; }

		// Token: 0x17003654 RID: 13908
		// (get) Token: 0x0600CF7E RID: 53118 RVA: 0x00302E87 File Offset: 0x00301087
		// (set) Token: 0x0600CF7F RID: 53119 RVA: 0x00302E8F File Offset: 0x0030108F
		public bool IsWander { get; set; }

		// Token: 0x17003655 RID: 13909
		// (get) Token: 0x0600CF80 RID: 53120 RVA: 0x00302E98 File Offset: 0x00301098
		// (set) Token: 0x0600CF81 RID: 53121 RVA: 0x00302EA0 File Offset: 0x003010A0
		public bool IsFixedInCD { get; set; }

		// Token: 0x17003656 RID: 13910
		// (get) Token: 0x0600CF82 RID: 53122 RVA: 0x00302EA9 File Offset: 0x003010A9
		// (set) Token: 0x0600CF83 RID: 53123 RVA: 0x00302EB1 File Offset: 0x003010B1
		public bool Outline { get; set; }

		// Token: 0x17003657 RID: 13911
		// (get) Token: 0x0600CF84 RID: 53124 RVA: 0x00302EBA File Offset: 0x003010BA
		// (set) Token: 0x0600CF85 RID: 53125 RVA: 0x00302EC2 File Offset: 0x003010C2
		public int UseMyMesh { get; set; }

		// Token: 0x17003658 RID: 13912
		// (get) Token: 0x0600CF86 RID: 53126 RVA: 0x00302ECB File Offset: 0x003010CB
		// (set) Token: 0x0600CF87 RID: 53127 RVA: 0x00302ED3 File Offset: 0x003010D3
		public int SummonGroup { get; set; }

		// Token: 0x17003659 RID: 13913
		// (get) Token: 0x0600CF88 RID: 53128 RVA: 0x00302EDC File Offset: 0x003010DC
		// (set) Token: 0x0600CF89 RID: 53129 RVA: 0x00302EE4 File Offset: 0x003010E4
		public bool EndShow { get; set; }

		// Token: 0x1700365A RID: 13914
		// (get) Token: 0x0600CF8A RID: 53130 RVA: 0x00302EED File Offset: 0x003010ED
		// (set) Token: 0x0600CF8B RID: 53131 RVA: 0x00302EF5 File Offset: 0x003010F5
		public bool GeneralCutScene { get; set; }

		// Token: 0x1700365B RID: 13915
		// (get) Token: 0x0600CF8C RID: 53132 RVA: 0x00302EFE File Offset: 0x003010FE
		// (set) Token: 0x0600CF8D RID: 53133 RVA: 0x00302F06 File Offset: 0x00301106
		public bool SameBillBoardByMaster { get; set; }

		// Token: 0x1700365C RID: 13916
		// (get) Token: 0x0600CF8E RID: 53134 RVA: 0x00302F0F File Offset: 0x0030110F
		// (set) Token: 0x0600CF8F RID: 53135 RVA: 0x00302F17 File Offset: 0x00301117
		public uint Fov { get; set; }

		// Token: 0x1700365D RID: 13917
		// (get) Token: 0x0600CF90 RID: 53136 RVA: 0x00302F20 File Offset: 0x00301120
		// (set) Token: 0x0600CF91 RID: 53137 RVA: 0x00302F28 File Offset: 0x00301128
		public uint FashionTemplate { get; set; }

		// Token: 0x1700365E RID: 13918
		// (get) Token: 0x0600CF92 RID: 53138 RVA: 0x00302F31 File Offset: 0x00301131
		// (set) Token: 0x0600CF93 RID: 53139 RVA: 0x00302F39 File Offset: 0x00301139
		public short LinkCombo { get; set; }

		// Token: 0x1700365F RID: 13919
		// (get) Token: 0x0600CF94 RID: 53140 RVA: 0x00302F44 File Offset: 0x00301144
		public override uint Tag
		{
			get
			{
				return this.m_Tag;
			}
		}

		// Token: 0x0600CF95 RID: 53141 RVA: 0x00302F5C File Offset: 0x0030115C
		public override void InitAttribute(XEntityStatistics.RowData data)
		{
			base.InitAttribute(data);
			this.Init(data);
		}

		// Token: 0x0600CF96 RID: 53142 RVA: 0x00302F70 File Offset: 0x00301170
		private void Init(XEntityStatistics.RowData data)
		{
			this.NormalAttackProb = data.AttackProb;
			this.EnterFightRange = data.Sight;
			this.IsWander = data.IsWander;
			this.Blocked = data.Block;
			base.BeLocked = data.BeLocked;
			this.AIStartTime = data.AIStartTime;
			this.AIActionGap = data.AIActionGap;
			this.IsFixedInCD = data.IsFixedInCD;
			this.Outline = data.Highlight;
			this.UseMyMesh = (int)data.UseMyMesh;
			this.FloatingMin = ((data.FloatHeight != null && data.FloatHeight.Length != 0) ? data.FloatHeight[0] : 0f);
			this.FloatingMax = ((data.FloatHeight != null && data.FloatHeight.Length != 0) ? data.FloatHeight[1] : 0f);
			this.EndShow = data.EndShow;
			base.SoloShow = data.SoloShow;
			this.GeneralCutScene = data.UsingGeneralCutscene;
			this.SameBillBoardByMaster = data.SameBillBoard;
			this.FashionTemplate = (uint)data.FashionTemplate;
			this.Fov = (uint)data.Fov;
			this.SummonGroup = (int)data.SummonGroup;
			this.LinkCombo = data.LinkCombo;
			this._inborn_buff = data.InBornBuff;
			this._CreateTag(data);
		}

		// Token: 0x0600CF97 RID: 53143 RVA: 0x003030CC File Offset: 0x003012CC
		private void _CreateTag(XEntityStatistics.RowData data)
		{
			this.m_Tag = 0U;
			bool flag = data.Tag == null;
			if (!flag)
			{
				for (int i = 0; i < data.Tag.Length; i++)
				{
					this.m_Tag |= 1U << (int)data.Tag[i];
				}
			}
		}

		// Token: 0x04005D3B RID: 23867
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Others_Attributes");

		// Token: 0x04005D4E RID: 23886
		private uint m_Tag;
	}
}
