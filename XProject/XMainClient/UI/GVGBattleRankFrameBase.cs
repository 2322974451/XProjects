using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016E8 RID: 5864
	internal class GVGBattleRankFrameBase : IGVGBattleMember
	{
		// Token: 0x0600F1EF RID: 61935 RVA: 0x00359138 File Offset: 0x00357338
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

		// Token: 0x0600F1F0 RID: 61936 RVA: 0x003591B8 File Offset: 0x003573B8
		public void Setup(GameObject sv, int index)
		{
			this._index = index;
			this._gameObject = sv;
			this._transform = sv.transform;
			this._scrollView = (this._transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this._wrapContent = (this._transform.Find("RankList").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._wrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnWrapContentUpdate));
		}

		// Token: 0x0600F1F1 RID: 61937 RVA: 0x00359238 File Offset: 0x00357438
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

		// Token: 0x0600F1F2 RID: 61938 RVA: 0x0035940C File Offset: 0x0035760C
		public void OnUpdate()
		{
			bool flag = !this.IsActive();
			if (!flag)
			{
				this._wrapContent.RefreshAllVisibleContents();
			}
		}

		// Token: 0x0600F1F3 RID: 61939 RVA: 0x00359438 File Offset: 0x00357638
		public void SetActive(bool active)
		{
			bool flag = this._transform != null;
			if (flag)
			{
				this._transform.gameObject.SetActive(active);
			}
		}

		// Token: 0x0600F1F4 RID: 61940 RVA: 0x00359468 File Offset: 0x00357668
		public bool IsActive()
		{
			return this._transform != null && this._transform.gameObject.activeSelf;
		}

		// Token: 0x0600F1F5 RID: 61941 RVA: 0x0035949C File Offset: 0x0035769C
		public void Recycle()
		{
			bool flag = this._roles != null;
			if (flag)
			{
				this._roles.Clear();
				this._roles = null;
			}
		}

		// Token: 0x0400677A RID: 26490
		private int _index = 0;

		// Token: 0x0400677B RID: 26491
		private IXUIScrollView _scrollView;

		// Token: 0x0400677C RID: 26492
		private IXUIWrapContent _wrapContent;

		// Token: 0x0400677D RID: 26493
		private GameObject _gameObject;

		// Token: 0x0400677E RID: 26494
		private Transform _transform;

		// Token: 0x0400677F RID: 26495
		private List<GmfRole> _roles;

		// Token: 0x04006780 RID: 26496
		private GVGBattleInfo _battleInfo;
	}
}
