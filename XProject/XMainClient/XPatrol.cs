using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPatrol
	{

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

		public float NavGap
		{
			get
			{
				return this._nav_gap;
			}
		}

		public float NavNodeFinishTime { get; set; }

		public bool IsInNavGap { get; set; }

		public bool IsPingpong { get; set; }

		public bool IsLoop { get; set; }

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

		public void ToggleNavDir()
		{
			this._is_reverse_nav = !this._is_reverse_nav;
		}

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

		private List<GameObject> _nav_path = null;

		private int _path_index = 0;

		private List<Vector3> _nav_points = null;

		private List<float> _nav_gap_time = null;

		private int _nav_index = 0;

		private bool _is_reverse_nav = false;

		private float _nav_gap = 0f;

		public enum PathType
		{

			PT_PINGPONG = 1,

			PT_LOOP = 0,

			PT_NORMAL = 2
		}
	}
}
