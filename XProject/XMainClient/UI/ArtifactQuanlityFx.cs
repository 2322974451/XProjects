using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactQuanlityFx
	{

		public void SetData(ulong key, Transform tra, string path)
		{
			this.Reset();
			this.m_isUsing = true;
			this.m_key = key;
			this.m_fx = XSingleton<XFxMgr>.singleton.CreateUIFx(path, tra, false);
		}

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

		public bool IsCanReuse(ulong key)
		{
			return this.m_isUsing && this.m_key == key;
		}

		private bool m_isUsing = false;

		private ulong m_key = 0UL;

		private XFx m_fx = null;
	}
}
