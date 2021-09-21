using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B2E RID: 2862
	internal class XSkillPreViewMgr : XSingleton<XSkillPreViewMgr>
	{
		// Token: 0x0600A798 RID: 42904 RVA: 0x001DAD68 File Offset: 0x001D8F68
		public void GetSkillBlackHouse(ref GameObject blackHouse, ref Camera blackHouseCamera)
		{
			bool flag = this.BlackHouse == null;
			if (flag)
			{
				this.BlackHouse = (XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab("Common/SkillBlackHouse", true, false) as GameObject);
				this.BlackHouseCamera = this.BlackHouse.transform.FindChild("BasePoint/Camera").GetComponent<Camera>();
				this.BlackHouseCamera.enabled = false;
			}
			blackHouse = this.BlackHouse;
			blackHouseCamera = this.BlackHouseCamera;
		}

		// Token: 0x0600A799 RID: 42905 RVA: 0x001DADE4 File Offset: 0x001D8FE4
		public void ResetDummyPos(XDummy dummy)
		{
			bool flag = dummy == null;
			if (!flag)
			{
				Transform transform = this.BlackHouse.transform.FindChild(string.Format("BasePoint", new object[0]));
				bool flag2 = transform != null;
				if (flag2)
				{
					bool flag3 = dummy.EngineObject == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Dummy is null!!!", null, null, null, null, null);
						return;
					}
					dummy.EngineObject.Position = transform.position;
					dummy.EngineObject.SetParentTrans(transform.transform);
					dummy.EngineObject.SetLocalPRS(Vector3.zero, true, Quaternion.identity, true, Vector3.one, true);
				}
				bool flag4 = dummy.Buffs == null;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Dummy Buffs is null!!!", null, null, null, null, null);
				}
				else
				{
					dummy.Buffs.ClearBuff();
					dummy.Buffs.ClearBuffFx();
				}
			}
		}

		// Token: 0x0600A79A RID: 42906 RVA: 0x001DAED8 File Offset: 0x001D90D8
		public void ShowSkill(XDummy dummy, uint skillID, uint statisticsID = 0U)
		{
			this.ResetDummyPos(dummy);
			bool flag = dummy.Audio != null;
			if (flag)
			{
				dummy.Audio.Set3DPos(XSingleton<XScene>.singleton.GameCamera.CameraTrans.position);
			}
			SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(skillID, 0U, statisticsID);
			string name = (skillConfig.PreviewScript == "") ? skillConfig.SkillScript : skillConfig.PreviewScript;
			XAttackShowArgs @event = XEventPool<XAttackShowArgs>.GetEvent();
			@event.name = name;
			@event.Firer = dummy;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x0600A79B RID: 42907 RVA: 0x001DAF6C File Offset: 0x001D916C
		public void SkillShowBegin(XDummy dummy, Camera camera)
		{
			bool flag = dummy == null;
			if (!flag)
			{
				this.ResetDummyPos(dummy);
				bool flag2 = dummy.Audio != null;
				if (flag2)
				{
					dummy.Audio.Set3DPos(XSingleton<XScene>.singleton.GameCamera.CameraTrans.position);
				}
				XAttackShowBeginArgs @event = XEventPool<XAttackShowBeginArgs>.GetEvent();
				@event.Firer = dummy;
				@event.XCamera = camera.transform.gameObject;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
			}
		}

		// Token: 0x0600A79C RID: 42908 RVA: 0x001DAFE4 File Offset: 0x001D91E4
		public void SkillShowEnd(XDummy dummy)
		{
			XAttackShowEndArgs @event = XEventPool<XAttackShowEndArgs>.GetEvent();
			@event.ForceQuit = true;
			@event.Firer = dummy;
			XSingleton<XEventMgr>.singleton.FireEvent(@event);
		}

		// Token: 0x04003DFF RID: 15871
		public Camera BlackHouseCamera;

		// Token: 0x04003E00 RID: 15872
		public GameObject BlackHouse;
	}
}
