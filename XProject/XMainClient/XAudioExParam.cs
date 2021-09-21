using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000DA8 RID: 3496
	internal class XAudioExParam
	{
		// Token: 0x0600BDAF RID: 48559 RVA: 0x00276FBB File Offset: 0x002751BB
		public XAudioExParam(XEntity e)
		{
			this._caster = e;
			this._3dPos = Vector3.zero;
		}

		// Token: 0x0600BDB0 RID: 48560 RVA: 0x00276FD7 File Offset: 0x002751D7
		public XAudioExParam(Vector3 pos)
		{
			this._caster = null;
			this._3dPos = pos;
		}

		// Token: 0x0600BDB1 RID: 48561 RVA: 0x00276FEF File Offset: 0x002751EF
		public XAudioExParam(string param, float v)
		{
			this._caster = null;
			this._3dPos = Vector3.zero;
			this._fmodParam = param;
			this._fmodValue = v;
		}

		// Token: 0x04004D52 RID: 19794
		public XEntity _caster;

		// Token: 0x04004D53 RID: 19795
		public Vector3 _3dPos;

		// Token: 0x04004D54 RID: 19796
		public string _fmodParam;

		// Token: 0x04004D55 RID: 19797
		public float _fmodValue;
	}
}
