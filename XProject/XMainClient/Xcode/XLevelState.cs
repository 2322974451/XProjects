using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelState
	{

		public void AddEntityDieCount(ulong entityID)
		{
		}

		public void AddLevelSpawnEntityCount(ulong entityID)
		{
			bool flag = !this._entity_in_level_spawn.ContainsKey(entityID);
			if (flag)
			{
				this._entity_in_level_spawn.Add(entityID, 1);
			}
			else
			{
				Dictionary<ulong, int> entity_in_level_spawn = this._entity_in_level_spawn;
				entity_in_level_spawn[entityID]++;
			}
		}

		public bool CheckEntityInLevelSpawn(ulong entityID)
		{
			int num = 0;
			bool flag = this._entity_in_level_spawn.TryGetValue(entityID, out num);
			return flag && num > 0;
		}

		public void Reset()
		{
			this._current_scene_id = 0U;
			this._total_monster = 0;
			this._total_kill = 0;
			this._remain_monster = 0;
			this._before_force_kill = 0;
			this._after_force_kill = 0;
			this._entity_in_level_spawn.Clear();
			this._entity_die.Clear();
			this._boss_kill = 0;
			this._boss_total = 0;
			this._boss_rush_kill = 0;
			this._BossWave = 0;
			this._lastDieEntityPos = Vector3.zero;
			this._lastDieEntityHeight = 0f;
			this._refuseRevive = false;
			this._revive_count = 0U;
			this._player_continue_index = 0;
			this._abnormal_monster = 0;
			this._boss_exist_time = 0;
			this._monster_exist_time = 0;
			this._my_team_alive = 1U;
			this._op_team_alive = 0U;
			this._max_combo = 0U;
			this._player_behit = 0U;
			this._start_time = 0f;
			this._end_time = 0f;
			this._box_enemy_kill = 0;
			this._key_npc_die = false;
			this._enemy_in_fight = 0U;
			this._total_damage = 0f;
			this._total_hurt = 0f;
			this._total_heal = 0f;
			this._monster_refresh_time.Clear();
			this.sceneType = XSingleton<XScene>.singleton.SceneType;
		}

		public uint _current_scene_id;

		public int _total_monster = 0;

		public int _total_kill = 0;

		public int _before_force_kill = 0;

		public int _after_force_kill = 0;

		public Dictionary<ulong, int> _entity_in_level_spawn = new Dictionary<ulong, int>();

		public Dictionary<ulong, int> _entity_die = new Dictionary<ulong, int>();

		public int _boss_total = 0;

		public int _boss_kill = 0;

		public int _remain_monster = 0;

		public int _boss_rush_kill = 0;

		public int _abnormal_monster = 0;

		public int _boss_exist_time = 0;

		public int _monster_exist_time = 0;

		public int _BossWave = 0;

		public Vector3 _lastDieEntityPos;

		public float _lastDieEntityHeight = 0f;

		public bool _refuseRevive = false;

		public int _player_continue_index = 0;

		public uint _my_team_alive = 0U;

		public uint _op_team_alive = 0U;

		public uint _revive_count = 0U;

		public uint _death_count = 0U;

		public uint _max_combo;

		public uint _player_behit;

		public float _start_time;

		public float _end_time;

		public bool _key_npc_die;

		public uint _enemy_in_fight;

		public int _box_enemy_kill = 0;

		public float _total_damage = 0f;

		public float _total_hurt = 0f;

		public float _total_heal = 0f;

		public List<uint> _monster_refresh_time = new List<uint>();

		private SceneType sceneType;
	}
}
