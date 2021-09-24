using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GVGBattleRankFrameBase : IGVGBattleMember
	{

		public void ReFreshData(GVGBattleInfo battleInfo)
		{
			this._battleInfo = battleInfo;
			bool flag = this._roles == null;
			if (flag)
			{
				this._roles = new List<GmfRole>();
			}
			else
			{
				this._roles.Clear();
			}
			bool flag2 = battleInfo.Group != null;
			if (flag2)
			{
				this._roles.AddRange(battleInfo.Group);
			}
			this._wrapContent.SetContentCount(this._roles.Count, false);
			this._wrapContent.RefreshAllVisibleContents();
		}

		public void Setup(GameObject sv, int index)
		{
			this._index = index;
			this._gameObject = sv;
			this._transform = sv.transform;
			this._scrollView = (this._transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrapContent = (this._transform.Find("RankList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnWrapContentUpdate));
		}

		private void _OnWrapContentUpdate(Transform t, int index)
		{
			bool flag = this._roles.Count <= index;
			if (!flag)
			{
				IXUIProgress ixuiprogress = t.Find("HpBar").GetComponent("XUIProgress") as IXUIProgress;
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("KillValue").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("DieValue").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = t.Find("job").GetComponent("XUISprite") as IXUISprite;
				GmfRole gmfRole = this._roles[index];
				ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(gmfRole.profession));
				ixuilabel.SetText(gmfRole.rolename);
				GmfCombat gmfCombat = null;
				bool flag2 = this._battleInfo != null && this._battleInfo.TryGetCombat(gmfRole.roleID, out gmfCombat);
				if (flag2)
				{
					ixuilabel2.SetText(gmfCombat.killcount.ToString());
					ixuilabel3.SetText(gmfCombat.deadcount.ToString());
				}
				else
				{
					ixuilabel2.SetText("0");
					ixuilabel3.SetText("0");
				}
				XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(gmfRole.roleID);
				float value = 1f;
				bool flag3 = entity != null && entity.Attributes != null;
				if (flag3)
				{
					int num = (int)entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Total);
					int num2 = (int)entity.Attributes.GetAttr(XAttributeDefine.XAttr_CurrentHP_Basic);
					bool flag4 = num2 < 0;
					if (flag4)
					{
						num2 = 0;
					}
					value = (float)num2 / (float)num;
				}
				ixuiprogress.value = value;
			}
		}

		public void OnUpdate()
		{
			bool flag = !this.IsActive();
			if (!flag)
			{
				this._wrapContent.RefreshAllVisibleContents();
			}
		}

		public void SetActive(bool active)
		{
			bool flag = this._transform != null;
			if (flag)
			{
				this._transform.gameObject.SetActive(active);
			}
		}

		public bool IsActive()
		{
			return this._transform != null && this._transform.gameObject.activeSelf;
		}

		public void Recycle()
		{
			bool flag = this._roles != null;
			if (flag)
			{
				this._roles.Clear();
				this._roles = null;
			}
		}

		private int _index = 0;

		private IXUIScrollView _scrollView;

		private IXUIWrapContent _wrapContent;

		private GameObject _gameObject;

		private Transform _transform;

		private List<GmfRole> _roles;

		private GVGBattleInfo _battleInfo;
	}
}
