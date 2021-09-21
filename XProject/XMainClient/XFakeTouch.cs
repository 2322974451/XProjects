using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000EAB RID: 3755
	internal struct XFakeTouch
	{
		// Token: 0x170034E2 RID: 13538
		// (get) Token: 0x0600C80C RID: 51212 RVA: 0x002CC65A File Offset: 0x002CA85A
		// (set) Token: 0x0600C80D RID: 51213 RVA: 0x002CC662 File Offset: 0x002CA862
		public Vector2 deltaPosition { get; set; }

		// Token: 0x170034E3 RID: 13539
		// (get) Token: 0x0600C80E RID: 51214 RVA: 0x002CC66B File Offset: 0x002CA86B
		// (set) Token: 0x0600C80F RID: 51215 RVA: 0x002CC673 File Offset: 0x002CA873
		public float deltaTime { get; set; }

		// Token: 0x170034E4 RID: 13540
		// (get) Token: 0x0600C810 RID: 51216 RVA: 0x002CC67C File Offset: 0x002CA87C
		// (set) Token: 0x0600C811 RID: 51217 RVA: 0x002CC684 File Offset: 0x002CA884
		public int fingerId { get; set; }

		// Token: 0x170034E5 RID: 13541
		// (get) Token: 0x0600C812 RID: 51218 RVA: 0x002CC68D File Offset: 0x002CA88D
		// (set) Token: 0x0600C813 RID: 51219 RVA: 0x002CC695 File Offset: 0x002CA895
		public TouchPhase phase { get; set; }

		// Token: 0x170034E6 RID: 13542
		// (get) Token: 0x0600C814 RID: 51220 RVA: 0x002CC69E File Offset: 0x002CA89E
		// (set) Token: 0x0600C815 RID: 51221 RVA: 0x002CC6A6 File Offset: 0x002CA8A6
		public Vector2 position { get; set; }

		// Token: 0x170034E7 RID: 13543
		// (get) Token: 0x0600C816 RID: 51222 RVA: 0x002CC6AF File Offset: 0x002CA8AF
		// (set) Token: 0x0600C817 RID: 51223 RVA: 0x002CC6B7 File Offset: 0x002CA8B7
		public Vector2 rawPosition { get; set; }

		// Token: 0x170034E8 RID: 13544
		// (get) Token: 0x0600C818 RID: 51224 RVA: 0x002CC6C0 File Offset: 0x002CA8C0
		// (set) Token: 0x0600C819 RID: 51225 RVA: 0x002CC6C8 File Offset: 0x002CA8C8
		public int tapCount { get; set; }
	}
}
