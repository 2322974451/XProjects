using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017B0 RID: 6064
	internal class ArtifactQuanlityFx
	{
		// Token: 0x0600FADA RID: 64218 RVA: 0x003A170C File Offset: 0x0039F90C
		public void SetData(ulong key, Transform tra, string path)
		{
			this.Reset();
			this.m_isUsing = true;
			this.m_key = key;
			this.m_fx = XSingleton<XFxMgr>.singleton.CreateUIFx(path, tra, false);
		}

		// Token: 0x0600FADB RID: 64219 RVA: 0x003A1738 File Offset: 0x0039F938
		public void Reset()
		{
			this.m_key = 0UL;
			this.m_isUsing = false;
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
		}

		// Token: 0x0600FADC RID: 64220 RVA: 0x003A1780 File Offset: 0x0039F980
		public bool IsCanReuse(ulong key)
		{
			return this.m_isUsing && this.m_key == key;
		}

		// Token: 0x04006E05 RID: 28165
		private bool m_isUsing = false;

		// Token: 0x04006E06 RID: 28166
		private ulong m_key = 0UL;

		// Token: 0x04006E07 RID: 28167
		private XFx m_fx = null;
	}
}
