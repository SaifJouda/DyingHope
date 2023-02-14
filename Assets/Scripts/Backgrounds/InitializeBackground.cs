using Parallax2D.Modules.Background.Code.Behaviours;
using UnityEngine;

namespace Parallax2D.Example.Code
{
  public class InitializeBackground : MonoBehaviour
  {
    public Transform Player;
    public BackgroundMain BackgroundMain;
    
    private void Awake() => 
      BackgroundMain.Construct(Player);
  }
}