using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C30 RID: 3120
	internal class HomeSpriteClass
	{
		// Token: 0x0600B0B7 RID: 45239 RVA: 0x0021C628 File Offset: 0x0021A828
		public HomeSpriteClass()
		{
			this.m_fxPath = "Effects/FX_Particle/Scene/Lzg_scene/rwts_01";
			this.m_transmitPath = "Effects/FX_Particle/NPC/Lzg_Boss/yjsf/yjsh_ss";
		}

		// Token: 0x17003136 RID: 12598
		// (get) Token: 0x0600B0B8 RID: 45240 RVA: 0x0021C680 File Offset: 0x0021A880
		public PlantSprite.RowData Row
		{
			get
			{
				return this.m_row;
			}
		}

		// Token: 0x17003137 RID: 12599
		// (get) Token: 0x0600B0B9 RID: 45241 RVA: 0x0021C698 File Offset: 0x0021A898
		public bool IsHadSprite
		{
			get
			{
				return this.m_spriteId > 0U;
			}
		}

		// Token: 0x17003138 RID: 12600
		// (get) Token: 0x0600B0BA RID: 45242 RVA: 0x0021C6B4 File Offset: 0x0021A8B4
		public uint SpriteId
		{
			get
			{
				return this.m_spriteId;
			}
		}

		// Token: 0x0600B0BB RID: 45243 RVA: 0x0021C6CC File Offset: 0x0021A8CC
		public void SetSpriteInfo(uint spriteId)
		{
			this.m_spriteId = spriteId;
			this.m_driveTimes = 0U;
			bool flag = spriteId > 0U;
			if (flag)
			{
				HomePlantDocument.Doc.SetHadRedDot();
				this.m_row = HomePlantDocument.PlantSpriteTable.GetBySpriteID(spriteId);
				bool flag2 = this.m_row == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("data error,spriteId =" + spriteId.ToString(), null, null, null, null, null);
				}
				this.GetStartPos();
				SceneType sceneType = XSingleton<XScene>.singleton.SceneType;
				bool flag3 = sceneType == SceneType.SCENE_FAMILYGARDEN;
				if (flag3)
				{
					this.LoadNpc();
				}
			}
		}

		// Token: 0x17003139 RID: 12601
		// (get) Token: 0x0600B0BC RID: 45244 RVA: 0x0021C760 File Offset: 0x0021A960
		public bool HadDriveEnd
		{
			get
			{
				bool flag = this.m_row != null && this.m_row.Dialogues != null;
				return !flag || (ulong)this.m_driveTimes >= (ulong)((long)(this.m_row.Dialogues.Length - 1));
			}
		}

		// Token: 0x0600B0BD RID: 45245 RVA: 0x0021C7B0 File Offset: 0x0021A9B0
		public void SetNextStepOperation()
		{
			HomePlantDocument.Doc.SetFarmlandBoxStatus(true);
			bool hadDriveEnd = this.HadDriveEnd;
			if (hadDriveEnd)
			{
				HomePlantDocument.Doc.DriveTroubleMaker();
			}
			else
			{
				this.SetToNextPos();
			}
		}

		// Token: 0x0600B0BE RID: 45246 RVA: 0x0021C7E8 File Offset: 0x0021A9E8
		public string GetDialogue()
		{
			bool flag = this.m_row == null && this.m_row.Dialogues != null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				bool flag2 = (ulong)this.m_driveTimes >= (ulong)((long)this.m_row.Dialogues.Length);
				if (flag2)
				{
					result = "";
				}
				else
				{
					result = this.m_row.Dialogues[(int)this.m_driveTimes];
				}
			}
			return result;
		}

		// Token: 0x0600B0BF RID: 45247 RVA: 0x0021C857 File Offset: 0x0021AA57
		public void ClearInfo()
		{
			this.m_driveTimes = 0U;
			this.Destroy();
			this.animLoadCbValid = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			HomePlantDocument.Doc.SetHadRedDot();
		}

		// Token: 0x0600B0C0 RID: 45248 RVA: 0x0021C88C File Offset: 0x0021AA8C
		public void SetSpriteBoxStatus(bool status)
		{
			bool flag = this.m_npc != null;
			if (flag)
			{
				this.m_npc.EngineObject.EnableBC = status;
			}
		}

		// Token: 0x0600B0C1 RID: 45249 RVA: 0x0021C8BC File Offset: 0x0021AABC
		private void AnimLoadCallback(XAnimationClip clip)
		{
			bool flag = this.animLoadCbValid;
			if (flag)
			{
				float interval = 0f;
				bool flag2 = clip != null;
				if (flag2)
				{
					interval = clip.length - 0.034f;
				}
				this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.NpcMove), null);
				this.animLoadCbValid = false;
			}
		}

		// Token: 0x0600B0C2 RID: 45250 RVA: 0x0021C91C File Offset: 0x0021AB1C
		private void SetToNextPos()
		{
			bool flag = this.m_npc == null;
			if (!flag)
			{
				bool flag2 = this.m_fx != null;
				if (flag2)
				{
					this.m_fx.SetActive(false);
				}
				bool flag3 = this.m_transmitFx == null;
				if (flag3)
				{
					this.m_transmitFx = XSingleton<XFxMgr>.singleton.CreateFx(this.m_transmitPath, null, true);
				}
				this.m_transmitFx.SetActive(true);
				bool flag4 = this.m_transmitFx != null && this.m_npc != null;
				if (flag4)
				{
					this.m_transmitFx.Play(this.m_npc.EngineObject, new Vector3(-0.05f, this.m_npc.Height, 0f), Vector3.one, 1f, false, false, "", 0f);
				}
				this.animLoadCbValid = true;
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
				this.m_npc.ShowUp(new OverrideAnimCallback(this.AnimLoadCallback));
			}
		}

		// Token: 0x0600B0C3 RID: 45251 RVA: 0x0021CA1C File Offset: 0x0021AC1C
		private void NpcMove(object o = null)
		{
			this.AddDriveTimes();
			this.m_npc.EngineObject.Position = this.m_pos;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			bool flag = this.m_transmitFx != null && this.m_npc != null;
			if (flag)
			{
				this.m_transmitFx.SetActive(false);
				this.m_transmitFx.SetActive(true);
				this.m_transmitFx.Play(this.m_npc.EngineObject, new Vector3(-0.05f, this.m_npc.Height, 0f), Vector3.one, 1f, false, false, "", 0f);
				this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.TransmitEffectEnd), null);
			}
		}

		// Token: 0x0600B0C4 RID: 45252 RVA: 0x0021CAFC File Offset: 0x0021ACFC
		private void TransmitEffectEnd(object o = null)
		{
			this.SetSpriteBoxStatus(true);
			bool flag = this.m_transmitFx != null;
			if (flag)
			{
				this.m_transmitFx.SetActive(false);
			}
			bool flag2 = this.m_fx != null;
			if (flag2)
			{
				this.m_fx.SetActive(true);
				bool flag3 = this.m_fx != null && this.m_npc != null;
				if (flag3)
				{
					this.m_fx.Play(this.m_npc.EngineObject, new Vector3(-0.05f, this.m_npc.Height + 0.6f, 0f), Vector3.one, 1f, false, false, "", 0f);
				}
			}
		}

		// Token: 0x0600B0C5 RID: 45253 RVA: 0x0021CBB0 File Offset: 0x0021ADB0
		private void LoadNpc()
		{
			bool flag = this.m_npc != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.DestroyNpc(this.m_spriteId);
				this.m_npc = null;
			}
			this.m_npc = XSingleton<XEntityMgr>.singleton.CreateNpc(this.m_spriteId, true);
			bool flag2 = this.m_npc != null;
			if (flag2)
			{
				this.m_npc.EngineObject.Position = this.m_pos;
			}
			bool flag3 = this.m_fx == null;
			if (flag3)
			{
				this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.m_fxPath, null, true);
			}
			this.m_fx.SetActive(true);
			bool flag4 = this.m_fx != null && this.m_npc != null;
			if (flag4)
			{
				this.m_fx.Play(this.m_npc.EngineObject, new Vector3(-0.05f, this.m_npc.Height + 0.6f, 0f), Vector3.one, 1f, false, false, "", 0f);
			}
		}

		// Token: 0x0600B0C6 RID: 45254 RVA: 0x0021CCBC File Offset: 0x0021AEBC
		private void Destroy()
		{
			bool flag = this.m_npc != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.DestroyNpc(this.m_spriteId);
				this.m_npc = null;
				this.m_spriteId = 0U;
			}
			bool flag2 = this.m_fx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
			bool flag3 = this.m_transmitFx != null;
			if (flag3)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_transmitFx, true);
				this.m_transmitFx = null;
			}
		}

		// Token: 0x0600B0C7 RID: 45255 RVA: 0x0021CD48 File Offset: 0x0021AF48
		private void AddDriveTimes()
		{
			bool hadDriveEnd = this.HadDriveEnd;
			if (!hadDriveEnd)
			{
				this.m_driveTimes += 1U;
				this.GetPos();
			}
		}

		// Token: 0x0600B0C8 RID: 45256 RVA: 0x0021CD78 File Offset: 0x0021AF78
		private void GetStartPos()
		{
			bool flag = HomeSpriteClass.m_startPosList == null || HomeSpriteClass.m_startPosList.Count == 0;
			if (flag)
			{
				this.m_pos = Vector3.zero;
			}
			else
			{
				int index = Random.Range(0, HomeSpriteClass.m_startPosList.Count);
				this.m_pos = HomeSpriteClass.m_startPosList[index];
			}
		}

		// Token: 0x0600B0C9 RID: 45257 RVA: 0x0021CDD4 File Offset: 0x0021AFD4
		private void GetPos()
		{
			bool flag = HomeSpriteClass.m_startPosList == null || HomeSpriteClass.m_startPosList.Count == 0;
			if (flag)
			{
				this.m_pos = Vector3.zero;
			}
			else
			{
				int index;
				bool flag2;
				do
				{
					index = Random.Range(0, HomeSpriteClass.m_startPosList.Count);
					flag2 = (this.m_pos != HomeSpriteClass.m_startPosList[index]);
				}
				while (!flag2);
				this.m_pos = HomeSpriteClass.m_startPosList[index];
			}
		}

		// Token: 0x0600B0CA RID: 45258 RVA: 0x0021CE54 File Offset: 0x0021B054
		public static void InitPosList()
		{
			HomeSpriteClass.m_startPosList = new List<Vector3>();
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("TroublemakerStartPos");
			string[] array = value.Split(XGlobalConfig.AllSeparators);
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < array.Length; i += 3)
			{
				bool flag = !string.IsNullOrEmpty(array[i]) && !string.IsNullOrEmpty(array[i + 1]) && !string.IsNullOrEmpty(array[i + 2]);
				if (flag)
				{
					zero.x = float.Parse(array[i]);
					zero.y = float.Parse(array[i + 1]);
					zero.z = float.Parse(array[i + 2]);
					HomeSpriteClass.m_startPosList.Add(zero);
				}
			}
			HomeSpriteClass.m_posList = new List<Vector3>();
			value = XSingleton<XGlobalConfig>.singleton.GetValue("TroublemakerPos");
			array = value.Split(XGlobalConfig.AllSeparators);
			for (int j = 0; j < array.Length; j += 3)
			{
				bool flag2 = !string.IsNullOrEmpty(array[j]) && !string.IsNullOrEmpty(array[j + 1]) && !string.IsNullOrEmpty(array[j + 2]);
				if (flag2)
				{
					zero.x = float.Parse(array[j]);
					zero.y = float.Parse(array[j + 1]);
					zero.z = float.Parse(array[j + 2]);
					HomeSpriteClass.m_startPosList.Add(zero);
				}
			}
		}

		// Token: 0x040043F1 RID: 17393
		private PlantSprite.RowData m_row;

		// Token: 0x040043F2 RID: 17394
		private uint m_spriteId;

		// Token: 0x040043F3 RID: 17395
		private uint m_driveTimes = 0U;

		// Token: 0x040043F4 RID: 17396
		private Vector3 m_pos;

		// Token: 0x040043F5 RID: 17397
		private XNpc m_npc;

		// Token: 0x040043F6 RID: 17398
		private string m_fxPath = "";

		// Token: 0x040043F7 RID: 17399
		private XFx m_fx;

		// Token: 0x040043F8 RID: 17400
		private string m_transmitPath = "";

		// Token: 0x040043F9 RID: 17401
		private XFx m_transmitFx;

		// Token: 0x040043FA RID: 17402
		private static List<Vector3> m_startPosList;

		// Token: 0x040043FB RID: 17403
		private static List<Vector3> m_posList;

		// Token: 0x040043FC RID: 17404
		private uint m_token = 0U;

		// Token: 0x040043FD RID: 17405
		private bool animLoadCbValid = false;
	}
}
