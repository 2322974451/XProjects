using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTeamRift : XDataBase
	{

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

		public override void Recycle()
		{
			base.Recycle();
			this.id = 0U;
			this.floor = 0;
			this.sceneID = 0U;
			this.buffs.Clear();
		}

		public void SetUI(GameObject go)
		{
			IXUILabel ixuilabel = go.transform.Find("Floor").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("TEAMTOWER_LEVEL", new object[]
			{
				this.floor.ToString()
			}));
		}

		public string GetSceneName(string originName)
		{
			return XStringDefineProxy.GetString("SCENE_NAME_WITH_RIFT_FLOOR", new object[]
			{
				originName,
				this.floor.ToString()
			});
		}

		public uint id;

		public int floor;

		public uint sceneID;

		public List<BuffDesc> buffs = new List<BuffDesc>();
	}
}
