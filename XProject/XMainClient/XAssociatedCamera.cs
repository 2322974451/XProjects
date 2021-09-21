using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D84 RID: 3460
	public class XAssociatedCamera : IAssociatedCamera, IXInterface
	{
		// Token: 0x0600BCC2 RID: 48322 RVA: 0x0026EB7C File Offset: 0x0026CD7C
		public Camera Get()
		{
			return XSingleton<XScene>.singleton.AssociatedCamera;
		}

		// Token: 0x1700331B RID: 13083
		// (get) Token: 0x0600BCC3 RID: 48323 RVA: 0x0026EB98 File Offset: 0x0026CD98
		// (set) Token: 0x0600BCC4 RID: 48324 RVA: 0x0026EBA0 File Offset: 0x0026CDA0
		public bool Deprecated { get; set; }
	}
}
