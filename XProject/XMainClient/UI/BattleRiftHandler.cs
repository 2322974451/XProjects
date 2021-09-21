using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016D2 RID: 5842
	internal class BattleRiftHandler : DlgHandlerBase
	{
		// Token: 0x1700373E RID: 14142
		// (get) Token: 0x0600F0F3 RID: 61683 RVA: 0x00351A5C File Offset: 0x0034FC5C
		protected override string FileName
		{
			get
			{
				return "Battle/TeamMysteriousBattleDlg";
			}
		}

		// Token: 0x0600F0F4 RID: 61684 RVA: 0x00351A74 File Offset: 0x0034FC74
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
			this.m_lblFloor = (base.transform.FindChild("Floor").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTime1 = (base.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_lblTime2 = (base.transform.FindChild("Time2").GetComponent("XUILabel") as IXUILabel);
			this.m_lbltip = (base.transform.FindChild("Buff/Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_progress = (base.transform.FindChild("Progress Bar").GetComponent("XUIProgress") as IXUIProgress);
			for (int i = 0; i < 5; i++)
			{
				this.m_goBuff[i] = base.transform.FindChild("Buff/BossBuff" + i).gameObject;
			}
		}

		// Token: 0x0600F0F5 RID: 61685 RVA: 0x00351B8C File Offset: 0x0034FD8C
		protected override void OnShow()
		{
			base.OnShow();
			this.ParseData();
			bool flag = this._doc.scene_rift_data != null;
			if (flag)
			{
				this.Refresh((float)this._doc.scene_rift_data.floor, this._doc.scene_rift_data.buffIDs);
			}
			this.m_lbltip.SetVisible(false);
		}

		// Token: 0x0600F0F6 RID: 61686 RVA: 0x00351BF1 File Offset: 0x0034FDF1
		public void Refresh(float floor, List<Buff> buffs)
		{
			this.m_lblFloor.SetText(floor.ToString());
			this.RefreshBuff(buffs);
		}

		// Token: 0x0600F0F7 RID: 61687 RVA: 0x00351C10 File Offset: 0x0034FE10
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = Time.time - this.dtime > 1f && this._doc != null && !this._doc.stop_timer;
			if (flag)
			{
				this.dtime = Time.time;
				this.s_time += 1U;
				this.RefreshTime();
			}
		}

		// Token: 0x0600F0F8 RID: 61688 RVA: 0x00351C7C File Offset: 0x0034FE7C
		private void RefreshTime()
		{
			float value = 1f - this.s_time / this.all_time;
			this.m_progress.value = value;
			this.m_lblTime1.SetText(this.TranNum2Date(this.all_time - this.s_time));
			bool flag = this.s_time < this.tri_time;
			if (flag)
			{
				this.m_lblTime2.SetText(this.TranNum2Date(this.tri_time - this.s_time));
			}
			else
			{
				bool flag2 = this.s_time < this.tri_time + this.dob_time;
				if (flag2)
				{
					this.m_lblTime2.SetText(this.TranNum2Date(this.tri_time + this.dob_time - this.s_time));
				}
				else
				{
					this.m_lblTime2.SetText(this.TranNum2Date(this.all_time - this.s_time));
				}
			}
		}

		// Token: 0x0600F0F9 RID: 61689 RVA: 0x00351D68 File Offset: 0x0034FF68
		private void ParseData()
		{
			this.sceneid = XSingleton<XScene>.singleton.SceneID;
			SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.sceneid);
			for (int i = 0; i < (int)sceneData.LoseCondition.count; i++)
			{
				bool flag = sceneData.LoseCondition[i, 0] == 3;
				if (flag)
				{
					this.all_time = (uint)sceneData.LoseCondition[i, 1];
				}
			}
			for (int j = 0; j < XLevelRewardDocument.Table.Table.Length; j++)
			{
				bool flag2 = XLevelRewardDocument.Table.Table[j].scendid == this.sceneid;
				if (flag2)
				{
					this.tri_time = XLevelRewardDocument.Table.Table[j].star3[2];
					this.dob_time = XLevelRewardDocument.Table.Table[j].star2[2] - this.tri_time;
					break;
				}
			}
		}

		// Token: 0x0600F0FA RID: 61690 RVA: 0x00351E68 File Offset: 0x00350068
		private string TranNum2Date(uint num)
		{
			uint num2 = num / 60U;
			uint num3 = num % 60U;
			return num2.ToString("D2") + ":" + num3.ToString("D2");
		}

		// Token: 0x0600F0FB RID: 61691 RVA: 0x00351EA8 File Offset: 0x003500A8
		private void RefreshBuff(List<Buff> buffs)
		{
			int num = buffs.Count + 2;
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			Rift.RowData rowData = this._doc.currRiftRow;
			bool flag = specificDocument.MyTeam != null && specificDocument.MyTeam.teamBrief != null && specificDocument.MyTeam.teamBrief.rift != null;
			if (flag)
			{
				XTeamRift rift = specificDocument.MyTeam.teamBrief.rift;
				rowData = this._doc.GetRiftData(rift.floor, (int)rift.id);
			}
			this.RefreshBuff(this.m_goBuff[0], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftAttr"), rowData.attack + "%");
			this.RefreshBuff(this.m_goBuff[1], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftHP"), rowData.hp + "%");
			for (int i = 2; i < num; i++)
			{
				RiftBuffSuitMonsterType.RowData buffSuitRow = this._doc.GetBuffSuitRow((uint)buffs[i - 2].buffID, buffs[i - 2].buffLevel);
				this.m_goBuff[i].SetActive(true);
				this.RefreshBuff(this.m_goBuff[i], buffSuitRow.atlas, buffSuitRow.icon, string.Empty);
				IXUISprite ixuisprite = this.m_goBuff[i].transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)(i - 2));
				ixuisprite.RegisterSpritePressEventHandler(new SpritePressEventHandler(this.OnBuffPress));
			}
			for (int j = num; j < this.m_goBuff.Length; j++)
			{
				this.m_goBuff[j].SetActive(false);
			}
		}

		// Token: 0x0600F0FC RID: 61692 RVA: 0x00352098 File Offset: 0x00350298
		private bool OnBuffPress(IXUISprite spr, bool ispress)
		{
			int index = (int)spr.ID;
			Buff buff = this._doc.scene_rift_data.buffIDs[index];
			RiftBuffSuitMonsterType.RowData buffSuitRow = this._doc.GetBuffSuitRow((uint)buff.buffID, buff.buffLevel);
			this.m_lbltip.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(buffSuitRow.scription));
			this.m_lbltip.SetVisible(ispress);
			return true;
		}

		// Token: 0x0600F0FD RID: 61693 RVA: 0x0035210C File Offset: 0x0035030C
		private void RefreshBuff(GameObject go, string atlas, string sp, string text)
		{
			IXUILabel ixuilabel = go.transform.FindChild("value").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(text);
			bool flag = string.IsNullOrEmpty(atlas);
			if (flag)
			{
				ixuisprite.SetSprite(sp);
			}
			else
			{
				ixuisprite.SetSprite(sp, atlas, false);
			}
		}

		// Token: 0x040066D2 RID: 26322
		private XRiftDocument _doc;

		// Token: 0x040066D3 RID: 26323
		private const int max_buff = 5;

		// Token: 0x040066D4 RID: 26324
		public uint s_time = 0U;

		// Token: 0x040066D5 RID: 26325
		private uint all_time = 0U;

		// Token: 0x040066D6 RID: 26326
		private uint tri_time = 0U;

		// Token: 0x040066D7 RID: 26327
		private uint dob_time = 0U;

		// Token: 0x040066D8 RID: 26328
		private uint sceneid;

		// Token: 0x040066D9 RID: 26329
		public IXUIProgress m_progress;

		// Token: 0x040066DA RID: 26330
		public IXUILabel m_lblFloor;

		// Token: 0x040066DB RID: 26331
		public IXUILabel m_lblTime1;

		// Token: 0x040066DC RID: 26332
		public IXUILabel m_lblTime2;

		// Token: 0x040066DD RID: 26333
		private IXUILabel m_lbltip;

		// Token: 0x040066DE RID: 26334
		public GameObject[] m_goBuff = new GameObject[5];

		// Token: 0x040066DF RID: 26335
		private float dtime = 0f;
	}
}
