using System;

namespace XMainClient
{
	// Token: 0x02000DF3 RID: 3571
	internal class XLevelInfo
	{
		// Token: 0x0600C123 RID: 49443 RVA: 0x0028E74C File Offset: 0x0028C94C
		public XLevelInfo()
		{
			this.infoName = "";
			this.x = (this.y = (this.z = (this.face = (this.width = (this.height = (this.thickness = 0f))))));
			this.enable = false;
		}

		// Token: 0x0400515E RID: 20830
		public string infoName;

		// Token: 0x0400515F RID: 20831
		public float x;

		// Token: 0x04005160 RID: 20832
		public float y;

		// Token: 0x04005161 RID: 20833
		public float z;

		// Token: 0x04005162 RID: 20834
		public float face;

		// Token: 0x04005163 RID: 20835
		public float width;

		// Token: 0x04005164 RID: 20836
		public float height;

		// Token: 0x04005165 RID: 20837
		public float thickness;

		// Token: 0x04005166 RID: 20838
		public bool enable;
	}
}
