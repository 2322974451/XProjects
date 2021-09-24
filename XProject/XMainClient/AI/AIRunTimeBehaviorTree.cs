using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeBehaviorTree : IXBehaviorTree, IXInterface
	{

		public XEntity Host
		{
			get
			{
				return this._host;
			}
			set
			{
				this._host = value;
			}
		}

		public AIRunTimeRootNode Root
		{
			get
			{
				return this._root;
			}
			set
			{
				this._root = value;
			}
		}

		public SharedData Data
		{
			get
			{
				return this._data;
			}
		}

		public bool Deprecated { get; set; }

		public bool SetBehaviorTree(string name)
		{
			bool flag = string.IsNullOrEmpty(name);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._tree_name = name;
				this._root = XSingleton<AIRunTimeTreeMgr>.singleton.GetBehavior(name);
				this._data = this.DeepClone(this._root.Data);
				this._data.SetBoolByName("IsFighting", true);
				this._data.SetBoolByName("HitStatus", true);
				result = true;
			}
			return result;
		}

		public SharedData DeepClone(SharedData source)
		{
			return new SharedData(source);
		}

		public void OnStartSkill(uint skillid)
		{
		}

		public void OnEndSkill(uint skillid)
		{
		}

		public void OnSkillHurt()
		{
		}

		public void EnableBehaviorTree(bool enable)
		{
			this._enable = enable;
		}

		public void SetManual(bool enable)
		{
		}

		public float OnGetHeartRate()
		{
			return this._data.GetFloatByName("heartrate", 0f);
		}

		public void TickBehaviorTree()
		{
			bool enable = this._enable;
			if (enable)
			{
				this._root.Update(this._host);
			}
		}

		public void SetNavPoint(Transform navpoint)
		{
		}

		public void SetIntByName(string name, int value)
		{
			this._data.SetIntByName(name, value);
		}

		public void SetFloatByName(string name, float value)
		{
			this._data.SetFloatByName(name, value);
		}

		public void SetBoolByName(string name, bool value)
		{
			this._data.SetBoolByName(name, value);
		}

		public void SetVector3ByName(string name, Vector3 value)
		{
			this._data.SetVector3ByName(name, value);
		}

		public void SetTransformByName(string name, Transform value)
		{
			this._data.SetTransformByName(name, value);
		}

		public void SetXGameObjectByName(string name, XGameObject value)
		{
			this._data.SetXGameObjectByName(name, value);
		}

		public void SetVariable(string name, object value)
		{
		}

		private AIRunTimeRootNode _root = null;

		private SharedData _data = null;

		private string _tree_name;

		private XEntity _host = null;

		private bool _enable = false;
	}
}
