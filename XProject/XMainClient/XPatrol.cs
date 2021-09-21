using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F30 RID: 3888
	internal class XPatrol
	{
		// Token: 0x170035F0 RID: 13808
		// (get) Token: 0x0600CE21 RID: 52769 RVA: 0x002FB4A8 File Offset: 0x002F96A8
		private List<Vector3> nav_points
		{
			get
			{
				bool flag = this._nav_points == null;
				if (flag)
				{
					this._nav_points = ListPool<Vector3>.Get();
				}
				return this._nav_points;
			}
		}

		// Token: 0x170035F1 RID: 13809
		// (get) Token: 0x0600CE22 RID: 52770 RVA: 0x002FB4DC File Offset: 0x002F96DC
		private List<float> nav_gap_time
		{
			get
			{
				bool flag = this._nav_gap_time == null;
				if (flag)
				{
					this._nav_gap_time = ListPool<float>.Get();
				}
				return this._nav_gap_time;
			}
		}

		// Token: 0x170035F2 RID: 13810
		// (get) Token: 0x0600CE23 RID: 52771 RVA: 0x002FB510 File Offset: 0x002F9710
		// (set) Token: 0x0600CE24 RID: 52772 RVA: 0x002FB528 File Offset: 0x002F9728
		public int PathIndex
		{
			get
			{
				return this._path_index;
			}
			set
			{
				this._path_index = value;
			}
		}

		// Token: 0x170035F3 RID: 13811
		// (get) Token: 0x0600CE25 RID: 52773 RVA: 0x002FB534 File Offset: 0x002F9734
		// (set) Token: 0x0600CE26 RID: 52774 RVA: 0x002FB54C File Offset: 0x002F974C
		public int NavIndex
		{
			get
			{
				return this._nav_index;
			}
			set
			{
				this._nav_index = value;
			}
		}

		// Token: 0x170035F4 RID: 13812
		// (get) Token: 0x0600CE27 RID: 52775 RVA: 0x002FB558 File Offset: 0x002F9758
		public float NavGap
		{
			get
			{
				return this._nav_gap;
			}
		}

		// Token: 0x170035F5 RID: 13813
		// (get) Token: 0x0600CE28 RID: 52776 RVA: 0x002FB570 File Offset: 0x002F9770
		// (set) Token: 0x0600CE29 RID: 52777 RVA: 0x002FB578 File Offset: 0x002F9778
		public float NavNodeFinishTime { get; set; }

		// Token: 0x170035F6 RID: 13814
		// (get) Token: 0x0600CE2A RID: 52778 RVA: 0x002FB581 File Offset: 0x002F9781
		// (set) Token: 0x0600CE2B RID: 52779 RVA: 0x002FB589 File Offset: 0x002F9789
		public bool IsInNavGap { get; set; }

		// Token: 0x170035F7 RID: 13815
		// (get) Token: 0x0600CE2C RID: 52780 RVA: 0x002FB592 File Offset: 0x002F9792
		// (set) Token: 0x0600CE2D RID: 52781 RVA: 0x002FB59A File Offset: 0x002F979A
		public bool IsPingpong { get; set; }

		// Token: 0x170035F8 RID: 13816
		// (get) Token: 0x0600CE2E RID: 52782 RVA: 0x002FB5A3 File Offset: 0x002F97A3
		// (set) Token: 0x0600CE2F RID: 52783 RVA: 0x002FB5AB File Offset: 0x002F97AB
		public bool IsLoop { get; set; }

		// Token: 0x0600CE30 RID: 52784 RVA: 0x002FB5B4 File Offset: 0x002F97B4
		public void Destroy()
		{
			bool flag = this._nav_points != null;
			if (flag)
			{
				ListPool<Vector3>.Release(this._nav_points);
			}
			bool flag2 = this._nav_gap_time != null;
			if (flag2)
			{
				ListPool<float>.Release(this._nav_gap_time);
			}
		}

		// Token: 0x0600CE31 RID: 52785 RVA: 0x002FB5F8 File Offset: 0x002F97F8
		public void ToggleNavDir()
		{
			this._is_reverse_nav = !this._is_reverse_nav;
		}

		// Token: 0x0600CE32 RID: 52786 RVA: 0x002FB60C File Offset: 0x002F980C
		public Vector3 GetCurNavigationPoint()
		{
			bool flag = this.nav_points.Count == 0;
			Vector3 result;
			if (flag)
			{
				result = Vector3.zero;
			}
			else
			{
				bool flag2 = this._nav_index >= this.nav_points.Count;
				if (flag2)
				{
					result = this.nav_points[this.nav_points.Count - 1];
				}
				else
				{
					result = this.nav_points[this._nav_index];
				}
			}
			return result;
		}

		// Token: 0x0600CE33 RID: 52787 RVA: 0x002FB680 File Offset: 0x002F9880
		public float GetCurNavGap()
		{
			bool flag = this.nav_gap_time.Count == 0;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				bool flag2 = this._nav_index >= this.nav_gap_time.Count;
				if (flag2)
				{
					result = this.nav_gap_time[this.nav_gap_time.Count - 1];
				}
				else
				{
					result = this.nav_gap_time[this._nav_index];
				}
			}
			return result;
		}

		// Token: 0x0600CE34 RID: 52788 RVA: 0x002FB6F4 File Offset: 0x002F98F4
		public Vector3 GetNextNavPos()
		{
			bool flag = this.nav_points.Count == 0;
			Vector3 result;
			if (flag)
			{
				result = Vector3.zero;
			}
			else
			{
				bool isPingpong = this.IsPingpong;
				if (isPingpong)
				{
					bool is_reverse_nav = this._is_reverse_nav;
					if (is_reverse_nav)
					{
						bool flag2 = this._nav_index == 0;
						if (flag2)
						{
							this._is_reverse_nav = false;
							this._nav_index = 1;
						}
						else
						{
							this._nav_index--;
						}
					}
					else
					{
						bool flag3 = this._nav_index == this.nav_points.Count - 1;
						if (flag3)
						{
							this._is_reverse_nav = true;
							this._nav_index--;
						}
						else
						{
							this._nav_index++;
						}
					}
				}
				else
				{
					bool flag4 = !this._is_reverse_nav;
					if (flag4)
					{
						bool flag5 = this._nav_index >= this.nav_points.Count - 1;
						if (flag5)
						{
							bool isLoop = this.IsLoop;
							if (isLoop)
							{
								this._nav_index = 0;
							}
						}
						else
						{
							this._nav_index++;
						}
					}
					else
					{
						bool flag6 = this._nav_index <= 0;
						if (flag6)
						{
							bool isLoop2 = this.IsLoop;
							if (isLoop2)
							{
								this._nav_index = this.nav_points.Count - 1;
							}
						}
						else
						{
							this._nav_index--;
						}
					}
				}
				bool flag7 = this._nav_index < 0;
				if (flag7)
				{
					this._nav_index = 0;
				}
				bool flag8 = this._nav_index >= this.nav_points.Count;
				if (flag8)
				{
					this._nav_index = this.nav_points.Count - 1;
				}
				result = this.GetCurNavigationPoint();
			}
			return result;
		}

		// Token: 0x0600CE35 RID: 52789 RVA: 0x002FB8A0 File Offset: 0x002F9AA0
		public void InitNavPath(string path, XPatrol.PathType type)
		{
			this._nav_path = XSingleton<XLevelAIMgr>.singleton.PathList;
			this._path_index = 0;
			this.nav_points.Clear();
			this.nav_gap_time.Clear();
			string[] array = path.Split(XGlobalConfig.AllSeparators);
			bool flag = array.Length % 4 != 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Format error: ", path, null, null, null, null);
			}
			else
			{
				for (int i = 0; i < array.Length; i += 4)
				{
					this.nav_points.Add(new Vector3(float.Parse(array[i]), float.Parse(array[i + 1]), float.Parse(array[i + 2])));
					this.nav_gap_time.Add(float.Parse(array[i + 3]));
				}
				this.IsPingpong = (type == XPatrol.PathType.PT_PINGPONG);
				this.IsLoop = (type == XPatrol.PathType.PT_LOOP);
				this._nav_gap = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AINavGap"));
				this.NavNodeFinishTime = 0f;
				this.IsInNavGap = false;
			}
		}

		// Token: 0x0600CE36 RID: 52790 RVA: 0x002FB9AC File Offset: 0x002F9BAC
		public void InitNavPath(XEntityStatistics.RowData raw)
		{
			this._nav_path = XSingleton<XLevelAIMgr>.singleton.PathList;
			this._path_index = 0;
			this.nav_points.Clear();
			this.nav_gap_time.Clear();
			bool flag = raw != null;
			if (flag)
			{
				this._nav_index = 0;
				for (int i = 0; i < raw.navigation.Count; i++)
				{
					this.nav_points.Add(new Vector3(raw.navigation[i, 0], raw.navigation[i, 1], raw.navigation[i, 2]));
					this.nav_gap_time.Add(raw.navigation[i, 3]);
				}
				this.IsPingpong = (raw.IsNavPingpong == 1);
				this.IsLoop = (raw.IsNavPingpong == 0);
			}
			this._nav_gap = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("AINavGap"));
			this.NavNodeFinishTime = 0f;
			this.IsInNavGap = false;
		}

		// Token: 0x0600CE37 RID: 52791 RVA: 0x002FBAB8 File Offset: 0x002F9CB8
		public Transform GetFromNavPath(int index)
		{
			bool flag = this._nav_path == null || this._nav_path.Count == 0;
			Transform result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = index < 0;
				if (flag2)
				{
					result = this._nav_path[0].transform;
				}
				else
				{
					bool flag3 = index >= this._nav_path.Count;
					if (flag3)
					{
						result = this._nav_path[this._nav_path.Count - 1].transform;
					}
					else
					{
						result = this._nav_path[index].transform;
					}
				}
			}
			return result;
		}

		// Token: 0x04005BDE RID: 23518
		private List<GameObject> _nav_path = null;

		// Token: 0x04005BDF RID: 23519
		private int _path_index = 0;

		// Token: 0x04005BE0 RID: 23520
		private List<Vector3> _nav_points = null;

		// Token: 0x04005BE1 RID: 23521
		private List<float> _nav_gap_time = null;

		// Token: 0x04005BE2 RID: 23522
		private int _nav_index = 0;

		// Token: 0x04005BE3 RID: 23523
		private bool _is_reverse_nav = false;

		// Token: 0x04005BE4 RID: 23524
		private float _nav_gap = 0f;

		// Token: 0x020019F1 RID: 6641
		public enum PathType
		{
			// Token: 0x040080AD RID: 32941
			PT_PINGPONG = 1,
			// Token: 0x040080AE RID: 32942
			PT_LOOP = 0,
			// Token: 0x040080AF RID: 32943
			PT_NORMAL = 2
		}
	}
}
