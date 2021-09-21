// Decompiled with JetBrains decompiler
// Type: XMainClient.AIRuntimeSetDest
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
  internal class AIRuntimeSetDest : AIRunTimeNodeAction
  {
    private string _final_dest_name;
    private string _target_name;
    private string _nav_name;
    private string _born_pos_name;
    private Vector3 _born_pos;
    private string _tick_count_name;
    private float _random_max;
    private float _adjust_angle;
    private string _adjust_length_name;
    private float _adjust_value;
    private int _adjust_dir;
    private int _set_dest_type;

    public AIRuntimeSetDest(XmlElement node)
      : base(node)
    {
      this._final_dest_name = node.GetAttribute("Shared_FinalDestName");
      this._target_name = node.GetAttribute("Shared_TargetName");
      this._nav_name = node.GetAttribute("Shared_NavName");
      this._born_pos_name = node.GetAttribute("Shared_BornPosName");
      this._tick_count_name = node.GetAttribute("Shared_TickCountName");
      this._random_max = float.Parse(node.GetAttribute("RandomMax"));
      this._adjust_angle = float.Parse(node.GetAttribute("AdjustAngle"));
      this._adjust_length_name = node.GetAttribute("Shared_AdjustLengthName");
      this._adjust_value = float.Parse(node.GetAttribute("Shared_AdjustLengthmValue"));
      this._adjust_dir = int.Parse(node.GetAttribute("AdjustDir"));
      this._set_dest_type = int.Parse(node.GetAttribute("SetDestType"));
      string attribute = node.GetAttribute("Shared_BornPosmValue");
      this._born_pos = new Vector3(float.Parse(attribute.Split(':')[0]), float.Parse(attribute.Split(':')[1]), float.Parse(attribute.Split(':')[2]));
    }

    public override bool Update(XEntity entity)
    {
      Vector3 para = entity.AI.AIData.GetVector3ByName(this._final_dest_name, Vector3.zero);
      XGameObject xgameObjectByName = entity.AI.AIData.GetXGameObjectByName(this._target_name);
      Transform transformByName = entity.AI.AIData.GetTransformByName(this._nav_name);
      Vector3 vector3_1 = entity.AI.AIData.GetVector3ByName(this._born_pos_name, Vector3.zero);
      int intByName = entity.AI.AIData.GetIntByName(this._tick_count_name);
      float floatByName = entity.AI.AIData.GetFloatByName(this._adjust_length_name, this._adjust_value);
      if (string.IsNullOrEmpty(this._born_pos_name))
        vector3_1 = this._born_pos;
      Vector3 vector3_2 = new Vector3(1f, 0.0f, 1f);
      XFastEnumIntEqualityComparer<SetDestWay>.ToInt(SetDestWay.Target);
      if (this._set_dest_type == XFastEnumIntEqualityComparer<SetDestWay>.ToInt(SetDestWay.Target))
      {
        if (xgameObjectByName == null)
          return false;
        para = xgameObjectByName.Position;
      }
      else if (this._set_dest_type == XFastEnumIntEqualityComparer<SetDestWay>.ToInt(SetDestWay.BornPos))
        para = vector3_1;
      else if (this._set_dest_type == XFastEnumIntEqualityComparer<SetDestWay>.ToInt(SetDestWay.NavPos))
      {
        if ((Object) transformByName == (Object) null)
          return false;
        para = transformByName.position;
      }
      if ((double) floatByName != 0.0)
      {
        Vector3 vector3_3 = Vector3.zero;
        if (this._adjust_dir == XFastEnumIntEqualityComparer<AdjustDirection>.ToInt(AdjustDirection.TargetDir))
          vector3_3 = entity.EngineObject.Position - para;
        else if (this._adjust_dir == XFastEnumIntEqualityComparer<AdjustDirection>.ToInt(AdjustDirection.TargetFace) && xgameObjectByName != null)
          vector3_3 = xgameObjectByName.Forward.normalized;
        else if (this._adjust_dir == XFastEnumIntEqualityComparer<AdjustDirection>.ToInt(AdjustDirection.SelfFace))
          vector3_3 = entity.EngineObject.Forward.normalized;
        Vector3 vector3_4 = Quaternion.Euler(new Vector3(0.0f, (float) ((double) (intByName % 2) * (double) this._adjust_angle * 2.0) - this._adjust_angle, 0.0f)) * vector3_3;
        Vector3 pos = para + vector3_4.normalized * floatByName;
        if (!XSingleton<XAIGeneralMgr>.singleton.IsPointInMap(pos))
        {
          for (int index = 0; index < 18; ++index)
          {
            float num1 = this._adjust_angle + (float) (index * 10);
            Vector3 vector3_5 = Quaternion.Euler(new Vector3(0.0f, (float) ((double) (intByName % 2) * (double) num1 * 2.0) - num1, 0.0f)) * vector3_3;
            pos = para + vector3_5.normalized * floatByName;
            if (!XSingleton<XAIGeneralMgr>.singleton.IsPointInMap(pos))
            {
              float num2 = this._adjust_angle - (float) (index * 10);
              Vector3 vector3_6 = Quaternion.Euler(new Vector3(0.0f, (float) ((double) (intByName % 2) * (double) num2 * 2.0) - num2, 0.0f)) * vector3_3;
              pos = para + vector3_6.normalized * floatByName;
              if (XSingleton<XAIGeneralMgr>.singleton.IsPointInMap(pos))
                break;
            }
            else
              break;
          }
        }
        para = pos;
      }
      if ((double) this._random_max > 0.0)
      {
        vector3_2.x = XSingleton<XCommon>.singleton.RandomFloat(-0.5f, 0.5f);
        vector3_2.z = XSingleton<XCommon>.singleton.RandomFloat(-0.5f, 0.5f);
        para += this._random_max * vector3_2.normalized;
      }
      entity.AI.AIData.SetVector3ByName(this._final_dest_name, para);
      return true;
    }
  }
}
