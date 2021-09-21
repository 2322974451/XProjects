using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C13 RID: 3091
	internal class GuildPassBoard : MonoBehaviour
	{
		// Token: 0x0600AF95 RID: 44949 RVA: 0x00214E80 File Offset: 0x00213080
		private void Awake()
		{
			this._billboard = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(GuildPassBoard.BUBBLE_TEMPLATE, Vector3.zero, base.transform.rotation, true, false);
			this.m_lblName = (this._billboard.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_sprName = (this._billboard.transform.FindChild("Name/p").GetComponent("XUISprite") as IXUISprite);
			this.m_lblPoint = (this._billboard.transform.FindChild("DoubleScore").GetComponent("XUILabel") as IXUILabel);
			this.m_sprPoint = (this._billboard.transform.FindChild("DoubleScore/p").GetComponent("XUISprite") as IXUISprite);
			this.m_lblMember = (this._billboard.transform.FindChild("PlayerNum").GetComponent("XUILabel") as IXUILabel);
			this.m_sprMember = (this._billboard.transform.FindChild("PlayerNum/p").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x0600AF96 RID: 44950 RVA: 0x00214FB1 File Offset: 0x002131B1
		private void OnDestroy()
		{
			this.DestroyGameObjects();
		}

		// Token: 0x0600AF97 RID: 44951 RVA: 0x00214FBC File Offset: 0x002131BC
		private void LateUpdate()
		{
			bool flag = this._billboard != null && XSingleton<XScene>.singleton.GameCamera.CameraTrans != null;
			if (flag)
			{
				this._billboard.transform.localPosition = Vector3.zero;
				this._billboard.transform.localScale = 0.01f * Vector3.one;
				this._billboard.transform.rotation = XSingleton<XScene>.singleton.GameCamera.CameraTrans.rotation;
			}
			bool flag2 = Time.frameCount % 15 == 0 && XSingleton<XScene>.singleton.GameCamera.UnityCamera != null;
			if (flag2)
			{
			}
		}

		// Token: 0x0600AF98 RID: 44952 RVA: 0x0021507C File Offset: 0x0021327C
		public void Init(uint ix, uint scid, GameObject parent)
		{
			this.index = ix;
			this.sceneid = scid;
			this.mOpen = true;
			this.mGoParent = parent;
			this._billboard.transform.parent = parent.transform;
			string name = XGuildTerritoryDocument.mGuildTransfer.GetByid(ix).name;
			this._transfer = GameObject.Find("cankao/Blockwall" + this.index + "/TransferGuildWall");
			this._donghua = GameObject.Find("cankao/Blockwall" + this.index + "/kqq_zd_donghua");
			this.UpdateOpenState(false);
			bool flag = this.m_lblName != null;
			if (flag)
			{
				this.m_lblName.SetText(name);
			}
			this.m_lblPoint.gameObject.SetActive(false);
			this.UpdateMember(0U, 8U);
		}

		// Token: 0x0600AF99 RID: 44953 RVA: 0x00215157 File Offset: 0x00213357
		public void DestroyGameObjects()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._billboard, true);
		}

		// Token: 0x0600AF9A RID: 44954 RVA: 0x00215167 File Offset: 0x00213367
		public void UpdateBoard(GCFZhanChBriefInfo info)
		{
			this.UpdatePoint(info.multipoint);
			this.UpdateMember(info.curusercount, info.maxusercount);
			this.UpdateOpenState(info.isopen);
		}

		// Token: 0x0600AF9B RID: 44955 RVA: 0x00215198 File Offset: 0x00213398
		public void UpdateOpenState(bool open)
		{
			bool flag = this.mOpen != open;
			if (flag)
			{
				this._transfer.SetActive(open);
				this._donghua.SetActive(!open);
				this.mOpen = open;
			}
		}

		// Token: 0x0600AF9C RID: 44956 RVA: 0x002151DC File Offset: 0x002133DC
		public void ResetOpenState()
		{
			bool flag = this._transfer != null;
			if (flag)
			{
				this._transfer.SetActive(true);
			}
			bool flag2 = this._donghua != null;
			if (flag2)
			{
				this._donghua.SetActive(true);
			}
		}

		// Token: 0x0600AF9D RID: 44957 RVA: 0x00215224 File Offset: 0x00213424
		private void UpdateMember(uint curr, uint cnt)
		{
			bool flag = this.m_lblMember != null;
			if (flag)
			{
				this.m_lblMember.SetText(XSingleton<XCommon>.singleton.StringCombine(curr.ToString(), "/", cnt.ToString()));
			}
		}

		// Token: 0x0600AF9E RID: 44958 RVA: 0x0021526C File Offset: 0x0021346C
		private void UpdatePoint(uint state)
		{
			bool flag = this.m_lblPoint != null;
			if (flag)
			{
				this.m_lblPoint.gameObject.SetActive(state >= 2U);
				this.m_lblPoint.SetText(XStringDefineProxy.GetString("Territtory_Score" + state));
			}
		}

		// Token: 0x0600AF9F RID: 44959 RVA: 0x002152C4 File Offset: 0x002134C4
		private void SetBillBoardDepth(float dis = 0f)
		{
			int num = -(int)(dis * 100f);
			bool flag = this.m_lblName != null && this.m_sprName != null;
			if (flag)
			{
				this.m_lblName.spriteDepth = num + 1;
				this.m_sprName.spriteDepth = num;
			}
			bool flag2 = this.m_lblMember != null && this.m_sprMember != null;
			if (flag2)
			{
				this.m_lblMember.spriteDepth = num + 1;
				this.m_sprMember.spriteDepth = num;
			}
			bool flag3 = this.m_lblPoint != null && this.m_sprPoint != null;
			if (flag3)
			{
				this.m_lblPoint.spriteDepth = num + 1;
				this.m_sprPoint.spriteDepth = num;
			}
		}

		// Token: 0x040042F1 RID: 17137
		private GameObject _billboard = null;

		// Token: 0x040042F2 RID: 17138
		private GameObject _transfer = null;

		// Token: 0x040042F3 RID: 17139
		private GameObject _donghua = null;

		// Token: 0x040042F4 RID: 17140
		public uint index = 0U;

		// Token: 0x040042F5 RID: 17141
		public uint sceneid = 0U;

		// Token: 0x040042F6 RID: 17142
		private IXUILabel m_lblName;

		// Token: 0x040042F7 RID: 17143
		private IXUISprite m_sprName;

		// Token: 0x040042F8 RID: 17144
		private IXUILabel m_lblPoint;

		// Token: 0x040042F9 RID: 17145
		private IXUISprite m_sprPoint;

		// Token: 0x040042FA RID: 17146
		private IXUILabel m_lblMember;

		// Token: 0x040042FB RID: 17147
		private IXUISprite m_sprMember;

		// Token: 0x040042FC RID: 17148
		private bool mOpen = false;

		// Token: 0x040042FD RID: 17149
		private GameObject mGoParent;

		// Token: 0x040042FE RID: 17150
		public static string BUBBLE_TEMPLATE = "UI/Guild/GuildTerritory/GuildTerritoryBillboard";
	}
}
