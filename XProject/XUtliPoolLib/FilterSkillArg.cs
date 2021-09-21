using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000073 RID: 115
	public class FilterSkillArg
	{
		// Token: 0x04000288 RID: 648
		public Transform mAIArgTarget;

		// Token: 0x04000289 RID: 649
		public bool mAIArgUseMP;

		// Token: 0x0400028A RID: 650
		public bool mAIArgUseName;

		// Token: 0x0400028B RID: 651
		public bool mAIArgUseHP;

		// Token: 0x0400028C RID: 652
		public bool mAIArgUseCoolDown;

		// Token: 0x0400028D RID: 653
		public bool mAIArgUseAttackField;

		// Token: 0x0400028E RID: 654
		public bool mAIArgUseCombo;

		// Token: 0x0400028F RID: 655
		public bool mAIArgUseInstall = false;

		// Token: 0x04000290 RID: 656
		public int mAIArgSkillType;

		// Token: 0x04000291 RID: 657
		public string mAIArgSkillName;

		// Token: 0x04000292 RID: 658
		public bool mAIArgDetectAllPlayInAttackField;

		// Token: 0x04000293 RID: 659
		public int mAIArgMaxSkillNum;
	}
}
