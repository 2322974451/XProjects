using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeCallMonster : AIRunTimeNodeAction
	{

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

		private float _dist;

		private string _dist_name;

		private float _angle;

		private string _angle_name;

		private string _monster_id_name;

		private int _monster_id;

		private int _copy_monster_id;

		private int _max_monster_num;

		private float _life_time;

		private float _delay_time;

		private Vector3 _pos;

		private string _pos_name;

		private int _born_type;

		private Vector3 _pos1;

		private Vector3 _pos2;

		private Vector3 _pos3;

		private Vector3 _pos4;

		private bool _force_place;

		private float _delta_arg;
	}
}
