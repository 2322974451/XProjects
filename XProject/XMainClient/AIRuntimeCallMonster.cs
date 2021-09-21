using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A9D RID: 2717
	internal class AIRuntimeCallMonster : AIRunTimeNodeAction
	{
		// Token: 0x0600A502 RID: 42242 RVA: 0x001CAFA0 File Offset: 0x001C91A0
		public AIRuntimeCallMonster(XmlElement node) : base(node)
		{
			this._dist = float.Parse(node.GetAttribute("Shared_DistmValue"));
			this._dist_name = node.GetAttribute("Shared_DistName");
			this._angle = float.Parse(node.GetAttribute("Shared_AnglemValue"));
			this._angle_name = node.GetAttribute("Shared_AngleName");
			this._monster_id_name = node.GetAttribute("MonsterId2Name");
			this._monster_id = int.Parse(node.GetAttribute("MonsterId"));
			this._copy_monster_id = int.Parse(node.GetAttribute("CopyMonsterId"));
			this._max_monster_num = int.Parse(node.GetAttribute("MaxMonsterNum"));
			this._life_time = float.Parse(node.GetAttribute("LifeTime"));
			this._delay_time = float.Parse(node.GetAttribute("DelayTime"));
			string[] array = node.GetAttribute("Shared_PosmValue").Split(new char[]
			{
				':'
			});
			this._pos = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			this._pos_name = node.GetAttribute("Shared_PosName");
			this._born_type = int.Parse(node.GetAttribute("BornType"));
			array = node.GetAttribute("Pos1").Split(new char[]
			{
				':'
			});
			this._pos1 = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			array = node.GetAttribute("Pos2").Split(new char[]
			{
				':'
			});
			this._pos2 = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			array = node.GetAttribute("Pos3").Split(new char[]
			{
				':'
			});
			this._pos3 = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			array = node.GetAttribute("Pos4").Split(new char[]
			{
				':'
			});
			this._pos4 = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			this._force_place = (int.Parse(node.GetAttribute("ForcePlace")) != 0);
			this._delta_arg = float.Parse(node.GetAttribute("DeltaArg"));
		}

		// Token: 0x0600A503 RID: 42243 RVA: 0x001CB214 File Offset: 0x001C9414
		public override bool Update(XEntity entity)
		{
			CallMonsterData callMonsterData = new CallMonsterData();
			callMonsterData.mAIArgDist = entity.AI.AIData.GetFloatByName(this._dist_name, this._dist);
			callMonsterData.mAIArgAngle = entity.AI.AIData.GetFloatByName(this._angle_name, this._angle);
			callMonsterData.mAIArgMonsterId = entity.AI.AIData.GetIntByName(this._monster_id_name, this._monster_id);
			callMonsterData.mAIArgCopyMonsterId = this._copy_monster_id;
			callMonsterData.mAIArgLifeTime = this._life_time;
			callMonsterData.mAIArgDelayTime = this._delay_time;
			callMonsterData.mAIArgPos = entity.AI.AIData.GetVector3ByName(this._pos_name, this._pos);
			callMonsterData.mAIArgBornType = this._born_type;
			callMonsterData.mAIArgPos1 = this._pos1;
			callMonsterData.mAIArgPos2 = this._pos2;
			callMonsterData.mAIArgPos3 = this._pos3;
			callMonsterData.mAIArgPos4 = this._pos4;
			callMonsterData.mAIArgForcePlace = this._force_place;
			callMonsterData.mAIArgDeltaArg = this._delta_arg;
			return XSingleton<XAIOtherActions>.singleton.CallMonster(entity, callMonsterData);
		}

		// Token: 0x04003C39 RID: 15417
		private float _dist;

		// Token: 0x04003C3A RID: 15418
		private string _dist_name;

		// Token: 0x04003C3B RID: 15419
		private float _angle;

		// Token: 0x04003C3C RID: 15420
		private string _angle_name;

		// Token: 0x04003C3D RID: 15421
		private string _monster_id_name;

		// Token: 0x04003C3E RID: 15422
		private int _monster_id;

		// Token: 0x04003C3F RID: 15423
		private int _copy_monster_id;

		// Token: 0x04003C40 RID: 15424
		private int _max_monster_num;

		// Token: 0x04003C41 RID: 15425
		private float _life_time;

		// Token: 0x04003C42 RID: 15426
		private float _delay_time;

		// Token: 0x04003C43 RID: 15427
		private Vector3 _pos;

		// Token: 0x04003C44 RID: 15428
		private string _pos_name;

		// Token: 0x04003C45 RID: 15429
		private int _born_type;

		// Token: 0x04003C46 RID: 15430
		private Vector3 _pos1;

		// Token: 0x04003C47 RID: 15431
		private Vector3 _pos2;

		// Token: 0x04003C48 RID: 15432
		private Vector3 _pos3;

		// Token: 0x04003C49 RID: 15433
		private Vector3 _pos4;

		// Token: 0x04003C4A RID: 15434
		private bool _force_place;

		// Token: 0x04003C4B RID: 15435
		private float _delta_arg;
	}
}
