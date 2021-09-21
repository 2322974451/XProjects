using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D32 RID: 3378
	internal class XTeamRift : XDataBase
	{
		// Token: 0x0600BB5C RID: 47964 RVA: 0x00267824 File Offset: 0x00265A24
		public void SetData(TeamSynRift riftInfo, ExpeditionTable.RowData rowData)
		{
			bool flag = riftInfo == null;
			if (!flag)
			{
				bool flag2 = riftInfo.floorinfo == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("floorinfo is null, while riftid == ", riftInfo.riftid.ToString(), null, null, null, null);
				}
				else
				{
					this.id = riftInfo.riftid;
					this.floor = riftInfo.floorinfo.floor;
					this.sceneID = riftInfo.floorinfo.sceneid;
					this.buffs.Clear();
					for (int i = 0; i < riftInfo.floorinfo.buffs.Count; i++)
					{
						MapIntItem mapIntItem = riftInfo.floorinfo.buffs[i];
						BuffDesc item = default(BuffDesc);
						item.BuffID = (int)mapIntItem.key;
						item.BuffLevel = (int)mapIntItem.value;
						this.buffs.Add(item);
					}
				}
			}
		}

		// Token: 0x0600BB5D RID: 47965 RVA: 0x00267917 File Offset: 0x00265B17
		public override void Recycle()
		{
			base.Recycle();
			this.id = 0U;
			this.floor = 0;
			this.sceneID = 0U;
			this.buffs.Clear();
		}

		// Token: 0x0600BB5E RID: 47966 RVA: 0x00267944 File Offset: 0x00265B44
		public void SetUI(GameObject go)
		{
			IXUILabel ixuilabel = go.transform.Find("Floor").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("TEAMTOWER_LEVEL", new object[]
			{
				this.floor.ToString()
			}));
		}

		// Token: 0x0600BB5F RID: 47967 RVA: 0x00267998 File Offset: 0x00265B98
		public string GetSceneName(string originName)
		{
			return XStringDefineProxy.GetString("SCENE_NAME_WITH_RIFT_FLOOR", new object[]
			{
				originName,
				this.floor.ToString()
			});
		}

		// Token: 0x04004BD5 RID: 19413
		public uint id;

		// Token: 0x04004BD6 RID: 19414
		public int floor;

		// Token: 0x04004BD7 RID: 19415
		public uint sceneID;

		// Token: 0x04004BD8 RID: 19416
		public List<BuffDesc> buffs = new List<BuffDesc>();
	}
}
