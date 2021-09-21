using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FDF RID: 4063
	internal class UnFadeObject : IRenderObject
	{
		// Token: 0x170036D9 RID: 14041
		// (set) Token: 0x0600D309 RID: 54025 RVA: 0x00316B5F File Offset: 0x00314D5F
		public int InstanceID
		{
			set
			{
				this.m_instanceID = value;
			}
		}

		// Token: 0x170036DA RID: 14042
		// (set) Token: 0x0600D30A RID: 54026 RVA: 0x00316B69 File Offset: 0x00314D69
		public GameObject renderGO
		{
			set
			{
				this.m_renderGO = value;
				this.debugName = value.name;
			}
		}

		// Token: 0x0600D30B RID: 54027 RVA: 0x00316B80 File Offset: 0x00314D80
		public bool IsSameObj(int id)
		{
			return this.m_instanceID == id;
		}

		// Token: 0x0600D30C RID: 54028 RVA: 0x00316B9C File Offset: 0x00314D9C
		public void SetRenderLayer(int layer)
		{
			bool flag = this.m_renderGO != null;
			if (flag)
			{
				this.m_renderGO.layer = layer;
			}
		}

		// Token: 0x0600D30D RID: 54029 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetShader(int type)
		{
		}

		// Token: 0x0600D30E RID: 54030 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void ResetShader()
		{
		}

		// Token: 0x0600D30F RID: 54031 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetColor(byte r, byte g, byte b, byte a)
		{
		}

		// Token: 0x0600D310 RID: 54032 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetColor(Color32 c)
		{
		}

		// Token: 0x0600D311 RID: 54033 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void Update()
		{
		}

		// Token: 0x0600D312 RID: 54034 RVA: 0x00316BC9 File Offset: 0x00314DC9
		public void Clean()
		{
			this.m_instanceID = -1;
			this.m_renderGO = null;
			this.debugName = "";
			UnFadeObject.ReturnUFO(this);
		}

		// Token: 0x0600D313 RID: 54035 RVA: 0x00316BEC File Offset: 0x00314DEC
		public static UnFadeObject GetUFO(Renderer render)
		{
			bool flag = UnFadeObject.m_UFOCache.Count > 0;
			UnFadeObject unFadeObject;
			if (flag)
			{
				unFadeObject = UnFadeObject.m_UFOCache.Dequeue();
			}
			else
			{
				unFadeObject = new UnFadeObject();
			}
			bool flag2 = render != null;
			if (flag2)
			{
				unFadeObject.debugName = render.gameObject.name;
			}
			return unFadeObject;
		}

		// Token: 0x0600D314 RID: 54036 RVA: 0x00316C45 File Offset: 0x00314E45
		public static void ReturnUFO(UnFadeObject ufo)
		{
			UnFadeObject.m_UFOCache.Enqueue(ufo);
		}

		// Token: 0x04005FEE RID: 24558
		private static Queue<UnFadeObject> m_UFOCache = new Queue<UnFadeObject>();

		// Token: 0x04005FEF RID: 24559
		private int m_instanceID = -1;

		// Token: 0x04005FF0 RID: 24560
		private GameObject m_renderGO;

		// Token: 0x04005FF1 RID: 24561
		public string debugName;
	}
}
