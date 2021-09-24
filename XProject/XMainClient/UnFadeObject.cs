using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class UnFadeObject : IRenderObject
	{

		public int InstanceID
		{
			set
			{
				this.m_instanceID = value;
			}
		}

		public GameObject renderGO
		{
			set
			{
				this.m_renderGO = value;
				this.debugName = value.name;
			}
		}

		public bool IsSameObj(int id)
		{
			return this.m_instanceID == id;
		}

		public void SetRenderLayer(int layer)
		{
			bool flag = this.m_renderGO != null;
			if (flag)
			{
				this.m_renderGO.layer = layer;
			}
		}

		public void SetShader(int type)
		{
		}

		public void ResetShader()
		{
		}

		public void SetColor(byte r, byte g, byte b, byte a)
		{
		}

		public void SetColor(Color32 c)
		{
		}

		public void Update()
		{
		}

		public void Clean()
		{
			this.m_instanceID = -1;
			this.m_renderGO = null;
			this.debugName = "";
			UnFadeObject.ReturnUFO(this);
		}

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

		public static void ReturnUFO(UnFadeObject ufo)
		{
			UnFadeObject.m_UFOCache.Enqueue(ufo);
		}

		private static Queue<UnFadeObject> m_UFOCache = new Queue<UnFadeObject>();

		private int m_instanceID = -1;

		private GameObject m_renderGO;

		public string debugName;
	}
}
