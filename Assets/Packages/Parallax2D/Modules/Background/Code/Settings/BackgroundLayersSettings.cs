using System.Collections.Generic;
using UnityEngine;

namespace Parallax2D.Modules.Background.Code.Settings
{
  [System.Serializable]
  public class BackgroundLayersSettings
  {
    public string BackgroundName = "Background";
    public bool NineImage;
    public string Layer = "Background";
    public List<BackgroundLayerSetting> BackgroundLayerSettings;
  }

  [System.Serializable]
  public class BackgroundLayerSetting
  {
    public Sprite Sprite;
    public Vector2 ParallaxSpeedByLayer;
  }
}