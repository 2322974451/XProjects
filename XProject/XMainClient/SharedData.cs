using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AA8 RID: 2728
	[Serializable]
	internal class SharedData
	{
		// Token: 0x0600A515 RID: 42261 RVA: 0x001CB508 File Offset: 0x001C9708
		public SharedData()
		{
			this._entity_map = new Dictionary<uint, XGameObject>();
			this._trans_map = new Dictionary<uint, Transform>();
			this._float_map = new Dictionary<uint, float>();
			this._int_map = new Dictionary<uint, int>();
			this._string_map = new Dictionary<uint, string>();
			this._bool_map = new Dictionary<uint, bool>();
			this._vector3_map = new Dictionary<uint, Vector3>();
		}

		// Token: 0x0600A516 RID: 42262 RVA: 0x001CB5B8 File Offset: 0x001C97B8
		public SharedData(SharedData src)
		{
			this._entity_map = new Dictionary<uint, XGameObject>(src._entity_map);
			this._trans_map = new Dictionary<uint, Transform>(src._trans_map);
			this._float_map = new Dictionary<uint, float>(src._float_map);
			this._int_map = new Dictionary<uint, int>(src._int_map);
			this._string_map = new Dictionary<uint, string>(src._string_map);
			this._bool_map = new Dictionary<uint, bool>(src._bool_map);
			this._vector3_map = new Dictionary<uint, Vector3>(src._vector3_map);
		}

		// Token: 0x0600A517 RID: 42263 RVA: 0x001CB694 File Offset: 0x001C9894
		public Transform GetTransformByName(string name)
		{
			Transform transform = null;
			bool flag = this._trans_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out transform);
			Transform result;
			if (flag)
			{
				result = transform;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A518 RID: 42264 RVA: 0x001CB6CC File Offset: 0x001C98CC
		public void SetTransformByName(string name, Transform para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._trans_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		// Token: 0x0600A519 RID: 42265 RVA: 0x001CB704 File Offset: 0x001C9904
		public void SetXGameObjectByName(string name, XGameObject xgo)
		{
			bool flag = name != "";
			if (flag)
			{
				this._entity_map[XSingleton<XCommon>.singleton.XHash(name)] = xgo;
			}
		}

		// Token: 0x0600A51A RID: 42266 RVA: 0x001CB73C File Offset: 0x001C993C
		public XGameObject GetXGameObjectByName(string name)
		{
			XGameObject xgameObject = null;
			bool flag = this._entity_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out xgameObject);
			XGameObject result;
			if (flag)
			{
				result = xgameObject;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A51B RID: 42267 RVA: 0x001CB774 File Offset: 0x001C9974
		public float GetFloatByName(string name, float dvalue = 0f)
		{
			bool flag = name == "";
			float result;
			if (flag)
			{
				result = dvalue;
			}
			else
			{
				float num = 0f;
				bool flag2 = this._float_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out num);
				if (flag2)
				{
					result = num;
				}
				else
				{
					result = dvalue;
				}
			}
			return result;
		}

		// Token: 0x0600A51C RID: 42268 RVA: 0x001CB7C0 File Offset: 0x001C99C0
		public float GetFloatByName(uint hash, float dvalue = 0f)
		{
			float num = 0f;
			bool flag = this._float_map.TryGetValue(hash, out num);
			float result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = dvalue;
			}
			return result;
		}

		// Token: 0x0600A51D RID: 42269 RVA: 0x001CB7F0 File Offset: 0x001C99F0
		public void SetFloatByName(string name, float para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._float_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		// Token: 0x0600A51E RID: 42270 RVA: 0x001CB827 File Offset: 0x001C9A27
		public void SetFloatByName(uint hash, float para)
		{
			this._float_map[hash] = para;
		}

		// Token: 0x0600A51F RID: 42271 RVA: 0x001CB838 File Offset: 0x001C9A38
		public int GetIntByName(string name, int dvalue = 0)
		{
			int num = 0;
			bool flag = this._int_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = dvalue;
			}
			return result;
		}

		// Token: 0x0600A520 RID: 42272 RVA: 0x001CB870 File Offset: 0x001C9A70
		public int GetIntByName(uint hash, int dvalue = 0)
		{
			int num = 0;
			bool flag = this._int_map.TryGetValue(hash, out num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = dvalue;
			}
			return result;
		}

		// Token: 0x0600A521 RID: 42273 RVA: 0x001CB89C File Offset: 0x001C9A9C
		public void SetIntByName(string name, int para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._int_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		// Token: 0x0600A522 RID: 42274 RVA: 0x001CB8D1 File Offset: 0x001C9AD1
		public void SetIntByName(uint hash, int para)
		{
			this._int_map[hash] = para;
		}

		// Token: 0x0600A523 RID: 42275 RVA: 0x001CB8E4 File Offset: 0x001C9AE4
		public string GetStringByName(string name, string dvalue = "")
		{
			string text = "";
			bool flag = this._string_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out text);
			string result;
			if (flag)
			{
				result = text;
			}
			else
			{
				result = dvalue;
			}
			return result;
		}

		// Token: 0x0600A524 RID: 42276 RVA: 0x001CB920 File Offset: 0x001C9B20
		public string GetStringByName(uint hash, string dvalue = "")
		{
			string text = "";
			bool flag = this._string_map.TryGetValue(hash, out text);
			string result;
			if (flag)
			{
				result = text;
			}
			else
			{
				result = dvalue;
			}
			return result;
		}

		// Token: 0x0600A525 RID: 42277 RVA: 0x001CB950 File Offset: 0x001C9B50
		public void SetStringByName(string name, string para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._string_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		// Token: 0x0600A526 RID: 42278 RVA: 0x001CB987 File Offset: 0x001C9B87
		public void SetStringByName(uint hash, string para)
		{
			this._string_map[hash] = para;
		}

		// Token: 0x0600A527 RID: 42279 RVA: 0x001CB998 File Offset: 0x001C9B98
		public bool GetBoolByName(string name, bool dvalue = false)
		{
			bool flag = false;
			bool flag2 = name == "";
			bool result;
			if (flag2)
			{
				result = dvalue;
			}
			else
			{
				bool flag3 = this._bool_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out flag);
				if (flag3)
				{
					result = flag;
				}
				else
				{
					result = dvalue;
				}
			}
			return result;
		}

		// Token: 0x0600A528 RID: 42280 RVA: 0x001CB9E0 File Offset: 0x001C9BE0
		public bool GetBoolByName(uint hash, bool dvalue = false)
		{
			bool flag = false;
			bool flag2 = this._bool_map.TryGetValue(hash, out flag);
			return flag2 && flag;
		}

		// Token: 0x0600A529 RID: 42281 RVA: 0x001CBA0C File Offset: 0x001C9C0C
		public void SetBoolByName(string name, bool para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._bool_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		// Token: 0x0600A52A RID: 42282 RVA: 0x001CBA41 File Offset: 0x001C9C41
		public void SetBoolByName(uint hash, bool para)
		{
			this._bool_map[hash] = para;
		}

		// Token: 0x0600A52B RID: 42283 RVA: 0x001CBA54 File Offset: 0x001C9C54
		public Vector3 GetVector3ByName(string name, Vector3 dvalue)
		{
			bool flag = string.IsNullOrEmpty(name);
			Vector3 result;
			if (flag)
			{
				result = dvalue;
			}
			else
			{
				Vector3 zero = Vector3.zero;
				bool flag2 = this._vector3_map.TryGetValue(XSingleton<XCommon>.singleton.XHash(name), out zero);
				if (flag2)
				{
					result = zero;
				}
				else
				{
					result = Vector3.zero;
				}
			}
			return result;
		}

		// Token: 0x0600A52C RID: 42284 RVA: 0x001CBAA0 File Offset: 0x001C9CA0
		public Vector3 GetVector3ByName(uint hash)
		{
			Vector3 zero = Vector3.zero;
			bool flag = this._vector3_map.TryGetValue(hash, out zero);
			Vector3 result;
			if (flag)
			{
				result = zero;
			}
			else
			{
				result = Vector3.zero;
			}
			return result;
		}

		// Token: 0x0600A52D RID: 42285 RVA: 0x001CBAD4 File Offset: 0x001C9CD4
		public void SetVector3ByName(string name, Vector3 para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._vector3_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		// Token: 0x0600A52E RID: 42286 RVA: 0x001CBB09 File Offset: 0x001C9D09
		public void SetVector3ByName(uint hash, Vector3 para)
		{
			this._vector3_map[hash] = para;
		}

		// Token: 0x17002FE3 RID: 12259
		// (get) Token: 0x0600A52F RID: 42287 RVA: 0x001CBB1C File Offset: 0x001C9D1C
		public Dictionary<uint, XGameObject> EntityMap
		{
			get
			{
				return this._entity_map;
			}
		}

		// Token: 0x17002FE4 RID: 12260
		// (get) Token: 0x0600A530 RID: 42288 RVA: 0x001CBB34 File Offset: 0x001C9D34
		public Dictionary<uint, Transform> TransMap
		{
			get
			{
				return this._trans_map;
			}
		}

		// Token: 0x17002FE5 RID: 12261
		// (get) Token: 0x0600A531 RID: 42289 RVA: 0x001CBB4C File Offset: 0x001C9D4C
		public Dictionary<uint, float> FloatMap
		{
			get
			{
				return this._float_map;
			}
		}

		// Token: 0x17002FE6 RID: 12262
		// (get) Token: 0x0600A532 RID: 42290 RVA: 0x001CBB64 File Offset: 0x001C9D64
		public Dictionary<uint, int> IntMap
		{
			get
			{
				return this._int_map;
			}
		}

		// Token: 0x17002FE7 RID: 12263
		// (get) Token: 0x0600A533 RID: 42291 RVA: 0x001CBB7C File Offset: 0x001C9D7C
		public Dictionary<uint, string> StringMap
		{
			get
			{
				return this._string_map;
			}
		}

		// Token: 0x17002FE8 RID: 12264
		// (get) Token: 0x0600A534 RID: 42292 RVA: 0x001CBB94 File Offset: 0x001C9D94
		public Dictionary<uint, bool> BoolMap
		{
			get
			{
				return this._bool_map;
			}
		}

		// Token: 0x17002FE9 RID: 12265
		// (get) Token: 0x0600A535 RID: 42293 RVA: 0x001CBBAC File Offset: 0x001C9DAC
		public Dictionary<uint, Vector3> Vector3Map
		{
			get
			{
				return this._vector3_map;
			}
		}

		// Token: 0x04003C54 RID: 15444
		private Dictionary<uint, XGameObject> _entity_map = new Dictionary<uint, XGameObject>();

		// Token: 0x04003C55 RID: 15445
		private Dictionary<uint, Transform> _trans_map = new Dictionary<uint, Transform>();

		// Token: 0x04003C56 RID: 15446
		private Dictionary<uint, float> _float_map = new Dictionary<uint, float>();

		// Token: 0x04003C57 RID: 15447
		private Dictionary<uint, int> _int_map = new Dictionary<uint, int>();

		// Token: 0x04003C58 RID: 15448
		private Dictionary<uint, string> _string_map = new Dictionary<uint, string>();

		// Token: 0x04003C59 RID: 15449
		private Dictionary<uint, bool> _bool_map = new Dictionary<uint, bool>();

		// Token: 0x04003C5A RID: 15450
		private Dictionary<uint, Vector3> _vector3_map = new Dictionary<uint, Vector3>();
	}
}
