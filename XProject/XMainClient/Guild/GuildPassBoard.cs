using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildPassBoard : MonoBehaviour
	{

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

		private void OnDestroy()
		{
			this.DestroyGameObjects();
		}

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

		public void DestroyGameObjects()
		{
			XResourceLoaderMgr.SafeDestroy(ref this._billboard, true);
		}

		public void UpdateBoard(GCFZhanChBriefInfo info)
		{
			this.UpdatePoint(info.multipoint);
			this.UpdateMember(info.curusercount, info.maxusercount);
			this.UpdateOpenState(info.isopen);
		}

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

		private void UpdateMember(uint curr, uint cnt)
		{
			bool flag = this.m_lblMember != null;
			if (flag)
			{
				this.m_lblMember.SetText(XSingleton<XCommon>.singleton.StringCombine(curr.ToString(), "/", cnt.ToString()));
			}
		}

		private void UpdatePoint(uint state)
		{
			bool flag = this.m_lblPoint != null;
			if (flag)
			{
				this.m_lblPoint.gameObject.SetActive(state >= 2U);
				this.m_lblPoint.SetText(XStringDefineProxy.GetString("Territtory_Score" + state));
			}
		}

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

		private GameObject _billboard = null;

		private GameObject _transfer = null;

		private GameObject _donghua = null;

		public uint index = 0U;

		public uint sceneid = 0U;

		private IXUILabel m_lblName;

		private IXUISprite m_sprName;

		private IXUILabel m_lblPoint;

		private IXUISprite m_sprPoint;

		private IXUILabel m_lblMember;

		private IXUISprite m_sprMember;

		private bool mOpen = false;

		private GameObject mGoParent;

		public static string BUBBLE_TEMPLATE = "UI/Guild/GuildTerritory/GuildTerritoryBillboard";
	}
}
