using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B16 RID: 2838
	internal class XLevelState
	{
		// Token: 0x0600A6FC RID: 42748 RVA: 0x001C5366 File Offset: 0x001C3566
		public void AddEntityDieCount(ulong entityID)
		{
		}

		// Token: 0x0600A6FD RID: 42749 RVA: 0x001D70F8 File Offset: 0x001D52F8
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

		// Token: 0x0600A6FE RID: 42750 RVA: 0x001D7148 File Offset: 0x001D5348
		public bool CheckEntityInLevelSpawn(ulong entityID)
		{
			int num = 0;
			bool flag = this._entity_in_level_spawn.TryGetValue(entityID, out num);
			return flag && num > 0;
		}

		// Token: 0x0600A6FF RID: 42751 RVA: 0x001D7178 File Offset: 0x001D5378
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

		// Token: 0x04003D6D RID: 15725
		public uint _current_scene_id;

		// Token: 0x04003D6E RID: 15726
		public int _total_monster = 0;

		// Token: 0x04003D6F RID: 15727
		public int _total_kill = 0;

		// Token: 0x04003D70 RID: 15728
		public int _before_force_kill = 0;

		// Token: 0x04003D71 RID: 15729
		public int _after_force_kill = 0;

		// Token: 0x04003D72 RID: 15730
		public Dictionary<ulong, int> _entity_in_level_spawn = new Dictionary<ulong, int>();

		// Token: 0x04003D73 RID: 15731
		public Dictionary<ulong, int> _entity_die = new Dictionary<ulong, int>();

		// Token: 0x04003D74 RID: 15732
		public int _boss_total = 0;

		// Token: 0x04003D75 RID: 15733
		public int _boss_kill = 0;

		// Token: 0x04003D76 RID: 15734
		public int _remain_monster = 0;

		// Token: 0x04003D77 RID: 15735
		public int _boss_rush_kill = 0;

		// Token: 0x04003D78 RID: 15736
		public int _abnormal_monster = 0;

		// Token: 0x04003D79 RID: 15737
		public int _boss_exist_time = 0;

		// Token: 0x04003D7A RID: 15738
		public int _monster_exist_time = 0;

		// Token: 0x04003D7B RID: 15739
		public int _BossWave = 0;

		// Token: 0x04003D7C RID: 15740
		public Vector3 _lastDieEntityPos;

		// Token: 0x04003D7D RID: 15741
		public float _lastDieEntityHeight = 0f;

		// Token: 0x04003D7E RID: 15742
		public bool _refuseRevive = false;

		// Token: 0x04003D7F RID: 15743
		public int _player_continue_index = 0;

		// Token: 0x04003D80 RID: 15744
		public uint _my_team_alive = 0U;

		// Token: 0x04003D81 RID: 15745
		public uint _op_team_alive = 0U;

		// Token: 0x04003D82 RID: 15746
		public uint _revive_count = 0U;

		// Token: 0x04003D83 RID: 15747
		public uint _death_count = 0U;

		// Token: 0x04003D84 RID: 15748
		public uint _max_combo;

		// Token: 0x04003D85 RID: 15749
		public uint _player_behit;

		// Token: 0x04003D86 RID: 15750
		public float _start_time;

		// Token: 0x04003D87 RID: 15751
		public float _end_time;

		// Token: 0x04003D88 RID: 15752
		public bool _key_npc_die;

		// Token: 0x04003D89 RID: 15753
		public uint _enemy_in_fight;

		// Token: 0x04003D8A RID: 15754
		public int _box_enemy_kill = 0;

		// Token: 0x04003D8B RID: 15755
		public float _total_damage = 0f;

		// Token: 0x04003D8C RID: 15756
		public float _total_hurt = 0f;

		// Token: 0x04003D8D RID: 15757
		public float _total_heal = 0f;

		// Token: 0x04003D8E RID: 15758
		public List<uint> _monster_refresh_time = new List<uint>();

		// Token: 0x04003D8F RID: 15759
		private SceneType sceneType;
	}
}
