using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AAD RID: 2733
	internal class AIRunTimeBehaviorTree : IXBehaviorTree, IXInterface
	{
		// Token: 0x17002FEB RID: 12267
		// (get) Token: 0x0600A540 RID: 42304 RVA: 0x001CBE80 File Offset: 0x001CA080
		// (set) Token: 0x0600A541 RID: 42305 RVA: 0x001CBE98 File Offset: 0x001CA098
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

		// Token: 0x17002FEC RID: 12268
		// (get) Token: 0x0600A542 RID: 42306 RVA: 0x001CBEA4 File Offset: 0x001CA0A4
		// (set) Token: 0x0600A543 RID: 42307 RVA: 0x001CBEBC File Offset: 0x001CA0BC
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

		// Token: 0x17002FED RID: 12269
		// (get) Token: 0x0600A544 RID: 42308 RVA: 0x001CBEC8 File Offset: 0x001CA0C8
		public SharedData Data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x17002FEE RID: 12270
		// (get) Token: 0x0600A545 RID: 42309 RVA: 0x001CBEE0 File Offset: 0x001CA0E0
		// (set) Token: 0x0600A546 RID: 42310 RVA: 0x001CBEE8 File Offset: 0x001CA0E8
		public bool Deprecated { get; set; }

		// Token: 0x0600A547 RID: 42311 RVA: 0x001CBEF4 File Offset: 0x001CA0F4
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

		// Token: 0x0600A548 RID: 42312 RVA: 0x001CBF68 File Offset: 0x001CA168
		public SharedData DeepClone(SharedData source)
		{
			return new SharedData(source);
		}

		// Token: 0x0600A549 RID: 42313 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnStartSkill(uint skillid)
		{
		}

		// Token: 0x0600A54A RID: 42314 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnEndSkill(uint skillid)
		{
		}

		// Token: 0x0600A54B RID: 42315 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void OnSkillHurt()
		{
		}

		// Token: 0x0600A54C RID: 42316 RVA: 0x001CBF80 File Offset: 0x001CA180
		public void EnableBehaviorTree(bool enable)
		{
			this._enable = enable;
		}

		// Token: 0x0600A54D RID: 42317 RVA: 0x001C5366 File Offset: 0x001C3566
		public void SetManual(bool enable)
		{
		}

		// Token: 0x0600A54E RID: 42318 RVA: 0x001CBF8C File Offset: 0x001CA18C
		public float OnGetHeartRate()
		{
			return this._data.GetFloatByName("heartrate", 0f);
		}

		// Token: 0x0600A54F RID: 42319 RVA: 0x001CBFB4 File Offset: 0x001CA1B4
		public void TickBehaviorTree()
		{
			bool enable = this._enable;
			if (enable)
			{
				this._root.Update(this._host);
			}
		}

		// Token: 0x0600A550 RID: 42320 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetNavPoint(Transform navpoint)
		{
		}

		// Token: 0x0600A551 RID: 42321 RVA: 0x001CBFDE File Offset: 0x001CA1DE
		public void SetIntByName(string name, int value)
		{
			this._data.SetIntByName(name, value);
		}

		// Token: 0x0600A552 RID: 42322 RVA: 0x001CBFEF File Offset: 0x001CA1EF
		public void SetFloatByName(string name, float value)
		{
			this._data.SetFloatByName(name, value);
		}

		// Token: 0x0600A553 RID: 42323 RVA: 0x001CC000 File Offset: 0x001CA200
		public void SetBoolByName(string name, bool value)
		{
			this._data.SetBoolByName(name, value);
		}

		// Token: 0x0600A554 RID: 42324 RVA: 0x001CC011 File Offset: 0x001CA211
		public void SetVector3ByName(string name, Vector3 value)
		{
			this._data.SetVector3ByName(name, value);
		}

		// Token: 0x0600A555 RID: 42325 RVA: 0x001CC022 File Offset: 0x001CA222
		public void SetTransformByName(string name, Transform value)
		{
			this._data.SetTransformByName(name, value);
		}

		// Token: 0x0600A556 RID: 42326 RVA: 0x001CC033 File Offset: 0x001CA233
		public void SetXGameObjectByName(string name, XGameObject value)
		{
			this._data.SetXGameObjectByName(name, value);
		}

		// Token: 0x0600A557 RID: 42327 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void SetVariable(string name, object value)
		{
		}

		// Token: 0x04003C66 RID: 15462
		private AIRunTimeRootNode _root = null;

		// Token: 0x04003C67 RID: 15463
		private SharedData _data = null;

		// Token: 0x04003C68 RID: 15464
		private string _tree_name;

		// Token: 0x04003C69 RID: 15465
		private XEntity _host = null;

		// Token: 0x04003C6A RID: 15466
		private bool _enable = false;
	}
}
