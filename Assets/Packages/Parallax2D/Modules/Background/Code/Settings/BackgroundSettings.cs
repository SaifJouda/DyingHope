using Parallax2D.Modules.Background.Code.Behaviours;
using UnityEditor;
using UnityEngine;

namespace Parallax2D.Modules.Background.Code.Settings
{
  [CreateAssetMenu(fileName = "BackgroundSettings", menuName = "BackgroundSettings", order = 0)]
  public class BackgroundSettings : ScriptableObject
  {
    public BackgroundLayersSettings BackgroundLayersSettings;

    private const string BackgroundLayer = "BackgroundLayer";
    private const string BackgroundLayers = "BackgroundLayers";
    private const string BackgroundLayersContainer = "BackgroundLayersContainer";
    private static string PathToSavePrefabs => $"{Application.dataPath}/Parallax2D/Modules/Background/Prefabs/";

    [ContextMenu("Create Parallax and Save Prefab")]
    public void Create()
    {
      var backgroundContainer = new GameObject(BackgroundLayersSettings.BackgroundName).transform;
      var backGroundLayerContainer = new GameObject(BackgroundLayersContainer).transform;

      var backgroundMain = backgroundContainer.gameObject.AddComponent<BackgroundMain>();
      backGroundLayerContainer.SetParent(backgroundContainer);
      backgroundMain.NineImage = BackgroundLayersSettings.NineImage;

      for (var index = 0; index < BackgroundLayersSettings.BackgroundLayerSettings.Count; index++)
      {
        var backgroundLayerSetting = BackgroundLayersSettings.BackgroundLayerSettings[index];
        CreatedOneLayer(backGroundLayerContainer, backgroundLayerSetting, backgroundMain,
          BackgroundLayersSettings.NineImage, index);
      }

      var assetPath = $"{PathToSavePrefabs}{backgroundContainer.name}.prefab";
      PrefabUtility.SaveAsPrefabAsset(backgroundContainer.gameObject, assetPath);
    }

    private void CreatedOneLayer(Transform backGroundLayerContainer, BackgroundLayerSetting backgroundLayerSetting,
      BackgroundMain backgroundMain, bool nineImage, int layer)
    {
      var backgroundLayers = new GameObject(BackgroundLayers).transform;
      backgroundLayers.SetParent(backGroundLayerContainer);

      var backgroundMovement = backgroundLayers.gameObject.AddComponent<BackgroundMovement>();
      backgroundMovement.Speed = backgroundLayerSetting.ParallaxSpeedByLayer;
      backgroundMain.BackgroundMovements.Add(backgroundMovement);

      if (!nineImage)
        CreateLayer(backgroundLayerSetting, backgroundLayers, backgroundMovement, layer, BackgroundLayersSettings.Layer, 1);
      else
        for (var index = 0; index < 3; index++)
          CreateLayer(backgroundLayerSetting, backgroundLayers, backgroundMovement, layer, BackgroundLayersSettings.Layer, index);
    }

    private static void CreateLayer(
      BackgroundLayerSetting backgroundLayerSetting,
      Transform backgroundLayers,
      BackgroundMovement backgroundMovement,
      int layer, 
      string layerName,
      float indexY)
    {
      for (var index = 0; index < 3; index++)
      {
        var backgroundLayer = new GameObject(BackgroundLayer).transform;
        backgroundLayer.SetParent(backgroundLayers);

        var checkInBounds = backgroundLayer.gameObject.AddComponent<CheckPosition>();
        backgroundMovement.CheckPosition.Add(checkInBounds);

        var spriteRenderer = backgroundLayer.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = backgroundLayerSetting.Sprite;
        spriteRenderer.sortingLayerName = layerName;
        spriteRenderer.sortingOrder = layer;

        var boundHalfX = spriteRenderer.bounds.extents.x;
        var boundHalfY = spriteRenderer.bounds.extents.y;

        var positionX = (boundHalfX * 2) * (index - 1);
        var positionY = (boundHalfY * 2) * (indexY - 1);
        backgroundLayer.transform.position = new Vector3(positionX, positionY, 0);
      }
    }
  }
}