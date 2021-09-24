using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	[Serializable]
	internal class SharedData
	{

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

		public void SetTransformByName(string name, Transform para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._trans_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		public void SetXGameObjectByName(string name, XGameObject xgo)
		{
			bool flag = name != "";
			if (flag)
			{
				this._entity_map[XSingleton<XCommon>.singleton.XHash(name)] = xgo;
			}
		}

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

		public void SetFloatByName(string name, float para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._float_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		public void SetFloatByName(uint hash, float para)
		{
			this._float_map[hash] = para;
		}

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

		public void SetIntByName(string name, int para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._int_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		public void SetIntByName(uint hash, int para)
		{
			this._int_map[hash] = para;
		}

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

		public void SetStringByName(string name, string para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._string_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		public void SetStringByName(uint hash, string para)
		{
			this._string_map[hash] = para;
		}

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

		public bool GetBoolByName(uint hash, bool dvalue = false)
		{
			bool flag = false;
			bool flag2 = this._bool_map.TryGetValue(hash, out flag);
			return flag2 && flag;
		}

		public void SetBoolByName(string name, bool para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._bool_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		public void SetBoolByName(uint hash, bool para)
		{
			this._bool_map[hash] = para;
		}

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

		public void SetVector3ByName(string name, Vector3 para)
		{
			bool flag = name != "";
			if (flag)
			{
				this._vector3_map[XSingleton<XCommon>.singleton.XHash(name)] = para;
			}
		}

		public void SetVector3ByName(uint hash, Vector3 para)
		{
			this._vector3_map[hash] = para;
		}

		public Dictionary<uint, XGameObject> EntityMap
		{
			get
			{
				return this._entity_map;
			}
		}

		public Dictionary<uint, Transform> TransMap
		{
			get
			{
				return this._trans_map;
			}
		}

		public Dictionary<uint, float> FloatMap
		{
			get
			{
				return this._float_map;
			}
		}

		public Dictionary<uint, int> IntMap
		{
			get
			{
				return this._int_map;
			}
		}

		public Dictionary<uint, string> StringMap
		{
			get
			{
				return this._string_map;
			}
		}

		public Dictionary<uint, bool> BoolMap
		{
			get
			{
				return this._bool_map;
			}
		}

		public Dictionary<uint, Vector3> Vector3Map
		{
			get
			{
				return this._vector3_map;
			}
		}

		private Dictionary<uint, XGameObject> _entity_map = new Dictionary<uint, XGameObject>();

		private Dictionary<uint, Transform> _trans_map = new Dictionary<uint, Transform>();

		private Dictionary<uint, float> _float_map = new Dictionary<uint, float>();

		private Dictionary<uint, int> _int_map = new Dictionary<uint, int>();

		private Dictionary<uint, string> _string_map = new Dictionary<uint, string>();

		private Dictionary<uint, bool> _bool_map = new Dictionary<uint, bool>();

		private Dictionary<uint, Vector3> _vector3_map = new Dictionary<uint, Vector3>();
	}
}
