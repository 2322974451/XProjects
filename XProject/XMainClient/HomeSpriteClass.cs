using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class HomeSpriteClass
	{

		public HomeSpriteClass()
		{
			this.m_fxPath = "Effects/FX_Particle/Scene/Lzg_scene/rwts_01";
			this.m_transmitPath = "Effects/FX_Particle/NPC/Lzg_Boss/yjsf/yjsh_ss";
		}

		public PlantSprite.RowData Row
		{
			get
			{
				return this.m_row;
			}
		}

		public bool IsHadSprite
		{
			get
			{
				return this.m_spriteId > 0U;
			}
		}

		public uint SpriteId
		{
			get
			{
				return this.m_spriteId;
			}
		}

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

		public bool HadDriveEnd
		{
			get
			{
				bool flag = this.m_row != null && this.m_row.Dialogues != null;
				return !flag || (ulong)this.m_driveTimes >= (ulong)((long)(this.m_row.Dialogues.Length - 1));
			}
		}

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

		public void ClearInfo()
		{
			this.m_driveTimes = 0U;
			this.Destroy();
			this.animLoadCbValid = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			HomePlantDocument.Doc.SetHadRedDot();
		}

		public void SetSpriteBoxStatus(bool status)
		{
			bool flag = this.m_npc != null;
			if (flag)
			{
				this.m_npc.EngineObject.EnableBC = status;
			}
		}

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

		private void AddDriveTimes()
		{
			bool hadDriveEnd = this.HadDriveEnd;
			if (!hadDriveEnd)
			{
				this.m_driveTimes += 1U;
				this.GetPos();
			}
		}

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

		private PlantSprite.RowData m_row;

		private uint m_spriteId;

		private uint m_driveTimes = 0U;

		private Vector3 m_pos;

		private XNpc m_npc;

		private string m_fxPath = "";

		private XFx m_fx;

		private string m_transmitPath = "";

		private XFx m_transmitFx;

		private static List<Vector3> m_startPosList;

		private static List<Vector3> m_posList;

		private uint m_token = 0U;

		private bool animLoadCbValid = false;
	}
}
